namespace SMTRandoApp.SMTROM;

internal partial class ROMWriter {
	public byte[] Stream { get; } = new byte[ROMSIZE];
	public ROMVersion Version { get; }

	public DemonShuffler Demons { get; }
	public ItemShuffler Items { get; }
	public SkillShuffler Skills { get; }
	public AreaShuffler World { get; }

	private readonly Dictionary<string, Address> criticalLabels = new();

	public ROMWriter(byte[] s, ROMVersion version) {
		Array.Copy(s, Stream, s.Length);
		Version = version;

		Demons = new DemonShuffler(this);
		Items = new ItemShuffler(this);
		Skills = new SkillShuffler(this);
		World = new AreaShuffler(this);
	}

	public void AddCriticalLabel(string s, Address a) {
		criticalLabels[s] = a;
	}

	private static readonly string sep = "".PadRight(100, '=');
	// TODO always save spoiler in app data
	// delete spoilers that are too old?
	public void WriteSpoiler() {
		StringBuilder s = new();


		Demons.ForEveryone(p => {
			s.AppendLine();
			s.AppendLine();

			var f = p as Demon;

			s.AppendLine($"ID: ${p.ID:X3} - {p.Name} ({p.EnglishName} | {p.JapaneseName})");

			if (f is not null) {
				s.AppendLine($"\tLevel: {f.Level}\t\tHP: {f.HitPoints}\t\tMP: {f.MagicPower}\t\tXP: {f.Experience}");
				s.AppendLine($"\tSTR: {f.STR}\t\tINT: {f.INT}\t\tMAG: {f.MAG}\t\tSTM: {f.STM}\t\tSPD: {f.SPD}\t\tLUK: {f.LUK}");
				s.AppendLine($"\tMoveset: {Skills.GetSkillName(f.Move1)}\t\t {Skills.GetSkillName(f.Move2)}\t\t {Skills.GetSkillName(f.Move3)}");
			}


		});

		s.AppendLine();
		s.AppendLine(sep);
		s.AppendLine();

		Items.ForAllRealItems(i => {
			if (i.ItemType is ItemType.NotAnItem) return;

			s.AppendLine($"ID: ${i.ID:X2} - {i.Name} ({i.EnglishName} [{i.DisplayName}] | {i.JapaneseName})");

			if (!i.IsKeyItem) {
				s.AppendLine($"\tBuy: {i.BuyPrice}\t\tSell: {i.SellPrice}");
			}

			if (i.IsEquipment) {
				s.AppendLine($"\tPow: {i.Power,3}\t\tAux: {i.AuxPow,3}\t\tStat3: {i.Stat3,3}");
				s.AppendLine($"\tBonuses  \tSTR: {i.STRBonus}\t\tINT: {i.INTBonus}\t\tMAG: {i.MAGBonus}\t\tVIT: {i.VITBonus}\t\tSPD: {i.SPDBonus}\t\tLUK: {i.LUKBonus}");

				s.Append($"\tWho can equip: ");

				if (i.WearableBy is TargetAudience.NoOne) {
					s.AppendLine("Nobody");
				} else if (i.WearableBy is TargetAudience.Everyone) {
					s.AppendLine("Everyone");
				} else {
					string gender = (i.WearableBy & TargetAudience.BothGenders) switch {
						TargetAudience.BothGenders => "characters",
						TargetAudience.Male => "males",
						TargetAudience.Female => "females",
						_ => "losers"
					};

					string alignment = (i.WearableBy & TargetAudience.AllReligions) switch {
						TargetAudience.NoOne => "Loserful",
						TargetAudience.AllReligions => "All",
						_ => CombinementAlignment(i.WearableBy)
					};

					s.AppendLine($"{alignment} {gender}");

					static string CombinementAlignment(TargetAudience ta) {
						List<string> rett = new();

						if (ta.HasFlag(TargetAudience.Law)) {
							rett.Add("Lawful");
						}

						if (ta.HasFlag(TargetAudience.Neutral)) {
							rett.Add("Neutral");
						}

						if (ta.HasFlag(TargetAudience.Chaos)) {
							rett.Add("Chaotic");
						}

						return string.Join('/', rett);
					}
				}



			}


		});

		Debug.Print(s.ToString());
	}


	/*================================================================================================*\
	 * RANDOMIZATION ROUTINES
	\*================================================================================================*/

	public void DoTranslation(TranslateOption dnamet, TranslateOption classt,
			TranslateOption skillt, TranslateOption itemt) {
		PatchAllEnglishText();

		Address WriteTo = criticalLabels["Bank09FreeSpace"];

		WriteNamesWithLabels(criticalLabels[DEMONNAMEPOINTERS], ref WriteTo, dnamet.RunTranslation(this));
		WriteNamesWithLabels(criticalLabels[CLASSNAMEPOINTERS], ref WriteTo, classt.RunTranslation(this));
		WriteNamesWithLabels(criticalLabels[SKILLNAMEPOINTERS], ref WriteTo, skillt.RunTranslation(this));
		WriteNamesWithLabels(criticalLabels[ITEMNAMEPOINTERS], ref WriteTo, itemt.RunTranslation(this));

		// clean up the shared names pointers
		Demons.ForEveryone(p => {
			Address sharedPointer;

			switch (p) {
				case FancyItem fi:
					sharedPointer = criticalLabels[ITEMNAMEPOINTERS] + (fi.SharedName * 2);
					break;

				case Demon d when d.SharedName is not 0xFF:
					sharedPointer = criticalLabels[DEMONNAMEPOINTERS] + (d.SharedName * 2);
					break;

				default:
					return;
			}

			Write16(criticalLabels[DEMONNAMEPOINTERS] + (2 * p.ID), Read16(sharedPointer, 1));
		});


	}

	public int Length => Stream.Length;

	/// <summary>
	/// Read or write a single byte at offset <paramref name="a"/>.
	/// </summary>
	public byte this[Address a] {
		get => Stream[SNESToPC(a)];
		set => Stream[SNESToPC(a)] = value;
	}

	/*================================================================================================*\
	 * WRITE ROUTINES
	\*================================================================================================*/
	/// <summary>
	/// 
	/// </summary>
	public Address GetLabel(string s) => criticalLabels[s];

	public void Write8(Address address, params byte[] bytes) {
		int addr = SNESToPC(address);
		foreach (byte b in bytes) {
			Stream[addr++] = b;
		}
	}

	public void Write8Continuous(ref Address address, params byte[] bytes) {
		int addr = SNESToPC(address);
		foreach (byte b in bytes) {
			Stream[addr++] = b;
		}
		address += bytes.Length;
	}


	public void NOPOut(Address address, int count) {
		for (int a = SNESToPC(address), i = 0; i < count; a++, i++) {
			Stream[a] = 0xEA;
		}
	}

	public byte[] Read8(Address address, int count) {
		int addr = SNESToPC(address);

		return Stream[addr..(addr + count)];
	}

	public void Write16(Address address, params ushort[] words) {
		int addr = SNESToPC(address);
		foreach (var s in words) {
			Stream[addr++] = (byte) s;
			Stream[addr++] = (byte) (s >> 8);
		}
	}

	public void Write16Continuous(ref Address address, params ushort[] words) {
		int a = SNESToPC(address);
		foreach (var s in words) {
			Stream[a++] = (byte) s;
			Stream[a++] = (byte) (s >> 8);
		}
		address += 2 * words.Length;
	}

	public void Write16i(Address address, params int[] words) {
		int addr = SNESToPC(address);
		foreach (var s in words) {
			Stream[addr++] = (byte) s;
			Stream[addr++] = (byte) (s >> 8);
		}
	}

	public void Write16iContinuous(ref Address address, params int[] words) {
		int addr = SNESToPC(address);
		foreach (var s in words) {
			Stream[addr++] = (byte) s;
			Stream[addr++] = (byte) (s >> 8);
		}
		address += 2 * words.Length;
	}

	public ushort Read16(Address address) {
		int a = SNESToPC(address);
		return (ushort) (Stream[a] | (Stream[a + 1] << 8));
	}

	public ushort[] Read16(Address address, int count) {
		ushort[] ret = new ushort[count];
		for (int a = SNESToPC(address), i = 0; i < count; a += 2, i++) {
			ret[i] = (ushort) (Stream[a] | (Stream[a + 1] << 8));
		}
		return ret;
	}

	public void Write24(Address address, params int[] longs) {
		int addr = SNESToPC(address);
		foreach (int s in longs) {
			Stream[addr++] = (byte) s;
			Stream[addr++] = (byte) (s >> 8);
			Stream[addr++] = (byte) (s >> 16);
		}
	}

	public int[] Read24(Address address, int count) {
		int[] ret = new int[count];
		for (int a = SNESToPC(address), i = 0; i < count; a += 3, i++) {
			ret[i] = Stream[a] | (Stream[a + 1] << 8) | (Stream[a + 2] << 16);
		}
		return ret;
	}

	public void Write32(Address address, params uint[] dlongs) {
		int addr = SNESToPC(address);
		foreach (uint s in dlongs) {
			Stream[addr++] = (byte) s;
			Stream[addr++] = (byte) (s >> 8);
			Stream[addr++] = (byte) (s >> 16);
			Stream[addr++] = (byte) (s >> 24);
		}
	}

	public uint[] Read32(Address address, int count) {
		uint[] ret = new uint[count];
		for (int a = SNESToPC(address), i = 0; i < count; a += 4, i++) {
			ret[i] = (uint) (Stream[a] | (Stream[a + 1] << 8) |
				(Stream[a + 2] << 16) | (Stream[a + 2] << 24));
		}
		return ret;
	}

	private int SNESToPC(Address a) {
		int address = a[Version];

		if ((address & 0xFFFF) < 0x8000) {
			throw new ArgumentOutOfRangeException(nameof(address), "Illegal ROM write");
		}

		return address & 0x7FFF | (address & 0x7F0000) >> 1;
	}

	public ROMWriter Clone() => new(Stream, Version);
}
