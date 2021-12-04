namespace SMTRandoApp.Randomization;

internal partial class DemonShuffler {
	public const int DEMONCOUNT = 0x0136;

	private readonly ROMWriter rom;
	private readonly Personality[] ListOf = new Personality[DEMONCOUNT];

	public DemonShuffler(ROMWriter r) {
		ListOf = Personality.GetFreshList();
		rom = r;
	}

	public void ForAllDemons(Action<Demon> act) {
		foreach (var p in ListOf) {
			if (p is Demon d) {
				act(d);
			}
		}
	}

	public Demon[] GetListOfNormalDemonsInLevelRange(int low, int high) {
		return ListOf.Select(p => p as Demon).Where(d => d is not null && d.ID < 0xFF && d.Level >= low && d.Level <= high).ToArray();
	}

	public void ForEveryone(Action<Personality> act) {
		foreach (var p in ListOf) {
			if (p is not UselessJerk) {
				act(p);
			}
		}
	}


	public void WriteDemonData() {
		ForAllDemons(d => rom.Write8(DEMONSTATS + (d.ID * 24), d.GetStats()));
	}

	public Demon GetRandomUnusedDemonInLevelRange(int low, int high) {
		var allChoices = GetListOfNormalDemonsInLevelRange(low, high);

		// if we fail, try again at a slightly lower level
		// no need to ask for uniqueness if this happens
		if (!allChoices.Any()) {
			return GetRandomDemonInLevelRange(low - 5, low - 1);
		}

		var validChoices = Array.FindAll(allChoices, d => !d.BeenUsed);

		// if no valid unused demons found, just pick from the main list
		if (!validChoices.Any()) {
			validChoices = allChoices;
		}

		return validChoices.GetRandomElement();
	}

	public Demon GetRandomDemonInLevelRange(int low, int high) {
		if (low < 0) {
			return ListOf[ZombieID] as Demon; // give up and return zombie
		}

		var allChoices = GetListOfNormalDemonsInLevelRange(low, high);

		// if we fail, try again at a slightly lower level
		if (!allChoices.Any()) {
			return GetRandomDemonInLevelRange(low - 5, low - 1);
		}

		return allChoices.GetRandomElement();
	}


	// Demon experience
	public static readonly ShuffleOption[] DemonExperienceShuffles = {
		new ("Vanilla", null),

		new ("Random", rom => rom.Demons.RandomizeDemonExperience()),

		new ("Fast", rom => {
			rom.Demons.RandomizeDemonExperience();
			rom.Write8(EXPREWRITE, 0x0A, 0xEA, 0xEA, 0xEA); // ASL NOP NOP NOP
		}),

		new ("Expedient", rom => {
			rom.Demons.RandomizeDemonExperience();
			rom.Write8(EXPREWRITE, 0x0A, 0x0A, 0x0A, 0x0A); // ASL ASL ASL ASL
		}),
	};


	private void RandomizeDemonExperience() {
		ForAllDemons(d => d.Experience = GetRandomByte(0x01, 0x0F));
	}

	// Demon palettes
	public static readonly ShuffleOption[] DemonPaletteShuffles = {
		new ("Vanilla", null),

		new ("Random", rom => rom.Demons.ForAllDemons(p => rom[DEMONPALETTES + (p.ID * 8)] = GetRandomByte(0x00, 0x37))),

		new ("Cheese", rom => rom.Demons.ForAllDemons(p => rom[DEMONPALETTES + (p.ID * 8)] = 0x13)),
	};

	// Demon moves
	public static readonly ShuffleOption[] DemonMoveShuffles = {
		new ("Vanilla", null),

		new ("Shuffled", rom => {
			var filtered = rom.Demons.ListOf.Select(p => p as Demon).Where(p => p is not null).ToArray();
			var shuffled = filtered.ToShuffledArray();

			for (int i = 0; i < filtered.Length; i++) {
				var demon1 = filtered[i];
				var demon2 = shuffled[i];

				(demon1.Move1, demon2.Move1) = (demon2.Move1, demon1.Move1);
				(demon1.Move2, demon2.Move2) = (demon2.Move2, demon1.Move2);
				(demon1.Move3, demon2.Move3) = (demon2.Move3, demon1.Move3);
			}
		}),

		new ("Random", rom => {
			rom.Demons.ForAllDemons(d => {
				var mov = rom.Skills.GetXRandomSkillIDs(3);
				SetDemonMovesWithChanceOfFailure(d, mov[0], mov[1], mov[2]);
			});
		}),
	};

	private static void SetDemonMovesWithChanceOfFailure(Demon d, byte m1, byte m2, byte m3) {
		d.Move1 = m1;

		if (GetSuccessForChance(.02)) {
			d.Move2 = Skill.NoMove;
			d.Move3 = Skill.NoMove;
			return;
		}

		d.Move2 = m2;

		d.Move3 = GetSuccessForChance(.02) ? m3 : Skill.NoMove;
	}

	public static readonly ShuffleOption[] DemonReligionShuffles = {
		new ("Vanilla", null),

		new ("Shuffled", rom => {
			var filtered = rom.Demons.ListOf.Select(p => p as Demon).Where(p => p is not null).ToArray();
			var shuffled = filtered.ToShuffledArray();

			for (int i = 0; i < filtered.Length; i++) {
				filtered[i].Alignment = shuffled[i].Alignment;
			}
		}),

		new ("Random", rom => {
			rom.Demons.ForAllDemons(d => d.Alignment = GetRandomByte());
			rom.Demons.RandomizeBossClasses();
		}),
	};

	private void RandomizeBossClasses() {
		rom.Write8(0x03E770, GetRandomBytes(54, 0, CLASSCOUNT - 1));
	}


	// Item drops
	public static readonly ShuffleOption[] DemonItemShuffles = {
		new ("Vanilla", null),

		new ("Balanced", rom => {
			rom.Demons.ForAllDemons(p => {
				// TODO nice distribution spread of equipment, items, gems
				// base equipment drop level around demon level, but small chance of slightly improved
			});
		}),

		new ("Free crazy drops", rom => {
			rom.Demons.ForAllDemons(p => {
				p.DropRate = 0x0F;
				p.DroppedItem = Item.GetRandomRealItem();
			});
		}),

		new ("Chaotic", rom => {
			rom.Demons.ForAllDemons(p => {
				p.DropRate = GetRandomNibble();
				p.DroppedItem = Item.GetRandomRealItem();
			});
		}),
	};

	// Mag stone drops
	public static readonly ShuffleOption[] MagOrbDropShuffes = {
		new ("Vanilla", null),

		new ("Helpful", rom => {
			rom.Demons.ForAllDemons(p => p.MagStoneDropRate = GetRandomByte(0x4, 0xF));
		}),

		new ("Cool", rom => {
			rom.Demons.ForAllDemons(p => p.MagStoneDropRate = GetRandomNibble());

			byte magStone = GetRandomByte() switch {
				>= 0x60 and < 0xA0 => 0xB3, // Muscle drink
				>= 0xA0 and < 0xB0 => 0xB0, // Ointment
				>= 0xB0 and < 0xCC => 0xB4, // Orb
				>= 0xCC and < 0xD0 => 0xB5, // Hiranya
				>= 0xD0 and < 0xE8 => 0xB1, // Gyoutan
				_ => 0xB2, // Magstone
			};

			byte orb;

			do {
				orb = GetRandomByte() switch {
					>= 0x00 and < 0x04 => 0xDE, // Talisman
					>= 0x04 and < 0x60 => 0xB4, // Orb
					>= 0x60 and < 0x90 => 0xB5, // Hiranya
					>= 0x90 and < 0xA0 => 0xBA, // Gold pill
					>= 0xA0 and < 0xA8 => 0xBB, // Soul incense
					>= 0xA8 and < 0xB0 => 0xE3, // Indulgence
					>= 0xB0 and < 0xC0 => 0xE0, // Core shield
					>= 0xC0 and < 0xD0 => 0xDF, // Fuma bell
					>= 0xE0 and < 0xF4 => 0xD9, // Smoke bomb
					_ => 0xDD, // Amulet
				};
			} while (orb == magStone);

			rom.Demons.WriteMagStoneAndOrbDrops(magStone, orb);
		}),

		new ("Desperation", rom => {
			rom.Demons.ForAllDemons(p => p.DropRate = 0xF);
			rom.Demons.WriteMagStoneAndOrbDrops(0xB4, 0xB5);
		}),

		new ShuffleOption("Chaotic", rom => {
			rom.Demons.ForAllDemons(p => p.MagStoneDropRate = GetRandomNibble());
			rom.Demons.WriteMagStoneAndOrbDrops(Item.GetRandomRealItem(), Item.GetRandomRealItem());
		}),
	};


	private void WriteMagStoneAndOrbDrops(byte magStoneDrop, byte orbDrop) {
		rom[new Address(0x01C7D6, 0x01C7E8) + 1] = magStoneDrop;
		rom[new Address(0x01C7E5, 0x01C7F7) + 1] = orbDrop;
	}


	// This stuff is absolute spaghetti
	public static readonly TranslateOption[] DemonClassTranslations = {
		new ("English", rom => Race.VanillaRaces.Select(s => s.EnglishName).ToArray()),

		new ("Japanese", rom => Race.VanillaRaces.Select(s => s.JapaneseName).ToArray()),

		new ("Romaji", rom => Race.VanillaRaces.Select(s => s.RomajiName).ToArray()),

		new ("Relatable", rom => Race.RelatableClasses.ToShuffledArray()[0..Race.VanillaRaces.Length]),

		new ("Gibberish", rom => Race.VanillaRaces.Select(s => GibberishGenerator.Generate(4, 6)).ToArray()),
	};

	private delegate string DemonTranslateFunction(Personality p, NamesHandler n = null);

	private static readonly DemonTranslateFunction GetJapaneseName = (p, _) => p.JapaneseName;

	private static readonly string[] Penis = {
		"Dick",
		"Johnson",
		"Penis",
		"Peter",
		"Wiener",
		"Willy",
		"Hancock",
	};

	public static readonly TranslateOption[] DemonNameTranslations = {
		new ("English", rom => rom.Demons.GetDemonNames((p, n) => p.EnglishName)),

		new ("Japanese", rom => rom.Demons.GetDemonNames(GetJapaneseName)),

		new ("Relatable", rom => {
			string[] mnames = RelatableNamesM.ToShuffledArray();
			string[] fnames = RelatableNamesF.ToShuffledArray();
			string[] rnames = RelatableNamesR.ToShuffledArray();
			var namer = new NamesHandler(mnames, fnames, rnames, Penis.GetRandomElement());

			return rom.Demons.GetDemonNames((p, n) => n.GetNameForMe(p), namer);
		}),

		new ("Cheese", rom => rom.Demons.GetDemonNames((p, n) => n.GetNameForMe(p), new(CheeseNames.ToShuffledArray()))),

		new ("Gibberish", rom => rom.Demons.GetDemonNames((p, n) => GibberishGenerator.Generate(4, 8))),
	};

	private class NamesHandler {
		private int maleindex = 0;
		private int femaleindex = 0;
		private int inanimateindex = 0;

		private readonly string[] malenames;
		private readonly string[] femalenames;
		private readonly string[] inanimatenames;

		private readonly string penisname;

		public NamesHandler(string[] m, string[] f = null, string[] i = null, string penis = null) {
			malenames = m;
			femalenames = f;
			inanimatenames = i;
			penisname = penis;
		}


		public string GetNameForMe(Personality p) => p.Gender switch {
			Gender.Male => malenames[maleindex++],
			Gender.Female => femalenames?[femaleindex++] ?? malenames[maleindex++],
			Gender.None => femalenames is null || GetRandomBool() ? malenames[maleindex++] : femalenames[femaleindex++],
			Gender.Robot => inanimatenames?[inanimateindex++] ?? malenames[maleindex++],
			Gender.PenisChariot => penisname ?? malenames[maleindex++],
			_ => "Obama"
		};
	}


	private string[] GetDemonNames(DemonTranslateFunction translator, NamesHandler n = null) {
		string[] ret = new string[DEMONCOUNT];

		ForEveryone(p => {
			ret[p.ID] = p.Name = p switch {
				Demon d when d.SharedName is not 0xFF => null,
				// Normal translation
				Demon => translator(p, n) ?? p.EnglishName,
				FancyItem or UselessJerk => null,
				FancyNPC when translator == GetJapaneseName => p.JapaneseName,
				FancyNPC => p.EnglishName,
				_ => "uhoh",
			};
		});

		ForAllDemons(p => {
			if (p.SharedName is not 0xFF) {
				p.Name = ret[p.SharedName];
			}
		});

		return ret;
	}
}

