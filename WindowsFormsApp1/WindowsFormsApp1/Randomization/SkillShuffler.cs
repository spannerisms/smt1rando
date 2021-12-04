namespace SMTRandoApp.Randomization;

internal class SkillShuffler {
	private readonly Skill[] ListOfSkills = new Skill[0x76];
	private readonly ROMWriter rom;

	private Skill[] ValidSkills = Array.Empty<Skill>();

	private bool ohko = true;
	public bool AllowOHKO {
		get => ohko;
		set {
			if (ohko == value) return;
			ohko = value;
			RefreshValidSkills();
		}
	}

	public SkillShuffler(ROMWriter r) {
		ListOfSkills = Skill.GetFreshList();

		rom = r;

		RefreshValidSkills();
	}

	public string GetSkillName(byte id) {
		var s = ListOfSkills.FirstOrDefault(i => i.ID == id, null);

		return s?.Name ?? "N/A";
	}

	private void RefreshValidSkills() {
		ValidSkills = Array.FindAll(ListOfSkills, s => s.IsValid && (AllowOHKO || s.MoveType is not SkillType.OHKO));
	}

	public byte[] GetXRandomSkillIDs(int x) {
		return ValidSkills.ToShuffledArray(x).Select(s => s.ID).ToArray();
	}

	public byte[] GetRandomlyShuffledSkillIDs() {
		return ValidSkills.ToShuffledArray().Select(s => s.ID).ToArray();
	}

	public static readonly ShuffleOption[] SkillStatusShuffles = {
		new ("Vanilla", null),

		new ("Fair", rom => rom.Skills.RandomizeSkillStatuses(56)),

		new ("Random", rom => rom.Skills.RandomizeSkillStatuses(30)),

		new ("Painful", rom => rom.Skills.RandomizeSkillStatuses(17)),

		new ("Unfair", rom => {
			int intensity = rom.Skills.AllowOHKO ? 15 : 13;

			foreach (var s in rom.Skills.ListOfSkills) {
				if (s.MoveType is SkillType.Healing) continue;
				s.StatusInflicted = (StatusAffliction) (1 << GetRandomInt(0, intensity));
			}
		})
	};


	private void RandomizeSkillStatuses(int intensity) {
		foreach (var s in ListOfSkills) {
			if (s.MoveType is SkillType.Healing or SkillType.OHKO) continue;

			int shift = GetRandomInt(0, intensity);

			if (shift > 13) {
				s.StatusInflicted = StatusAffliction.None;
				continue;
			}

			s.StatusInflicted = (StatusAffliction) (1 << shift);
		}
	}


	public static readonly ShuffleOption[] HeroSkillShuffles = {
		new ("Vanilla", null),

		new ("Shuffled", rom => {
			ushort[] pointers = rom.Read16(HEROLEARNPOINTERS, 3);
			rom.Write16(HEROLEARNPOINTERS, pointers.ToShuffledArray());
		}),

		new ("Random", rom => rom.Skills.CompletelyRandomizeSkills(0x3E)),

		new ("Demonic", rom => rom.Skills.CompletelyRandomizeSkills(0x7F)),

	};

	private void CompletelyRandomizeSkills(byte maxSkill) {
		ushort[] pts = rom.Read16(HEROLEARNPOINTERS, 3);

		// Momo's skills
		WriteSkillsAtAddress(0x010000 | pts[0], 20);

		// Jimmy's skills
		WriteSkillsAtAddress(0x010000 | pts[1], 12);

		// him's skills
		WriteSkillsAtAddress(0x010000 | pts[2], 11);

		void WriteSkillsAtAddress(int address, int count) {
			byte[] shuf = Array.FindAll(GetRandomlyShuffledSkillIDs(), sk => sk <= maxSkill)[0..count];
			rom.Write8(address, shuf);
			rom[address + count] = 0xFF;
		}
	}

	// Skill damage
	public static readonly ShuffleOption[] SkillDamageShuffles = {
		new ("Vanilla", null),

		new ("Balanced", rom =>
			rom.Skills.RandomizeSkillDamages(
				t => t switch {
					SkillType.Elemental => (0x14, 0x1C), // base: 0x18
					SkillType.StrongElemental => (0x30, 0x40), // base: 0x38
					SkillType.ElementalMultiTarget => (0x0C, 0x14), // base: 0x10
					SkillType.StrongElementalMultiTarget => (0x28, 0x34), // base: 0x30
					SkillType.SpecialAttack => null,
					_ => null
				})
			),

		new ("Random", rom =>
			rom.Skills.RandomizeSkillDamages(
				t => t switch {
					SkillType.Elemental => (0x08, 0x20),
					SkillType.StrongElemental => (0x20, 0x40),
					SkillType.ElementalMultiTarget => (0x08, 0x20),
					SkillType.StrongElementalMultiTarget => (0x20, 0x40),
					SkillType.SpecialAttack => (0x01, 0x03),
					_ => null
				})
			),

		new ("Chaotic", rom =>
			rom.Skills.RandomizeSkillDamages(
				t => t switch {
					SkillType.Elemental => (0x01, 0x40),
					SkillType.StrongElemental => (0x01, 0x40),
					SkillType.ElementalMultiTarget => (0x01, 0x40),
					SkillType.StrongElementalMultiTarget => (0x01, 0x40),
					SkillType.SpecialAttack => (0x01, 0x40),
					_ => null
				})
			),
	};

	private delegate (int min, int max)? DamageShuffler(SkillType t);

	private void RandomizeSkillDamages(DamageShuffler mixer) {
		foreach (Skill s in ListOfSkills) {
			if (!s.IsValid) continue;

			(int min, int max)? minmax = mixer(s.MoveType);

			if (minmax is null) continue;

			s.Damage = GetRandomByte(minmax?.min ?? 0, minmax?.max ?? 0);
		}
	}

	// Skill costs
	public static readonly ShuffleOption[] SkillCostShuffles = {
		new ("Vanilla", null),

		new ("Random", rom => rom.Skills.RandomizeSkillCosts(1, 15)),

		new ("Cheap", rom => rom.Skills.RandomizeSkillCosts(0, 3)),

		new ("Chaotic", rom => rom.Skills.RandomizeSkillCosts(0, 30)),
	};

	public void RandomizeSkillCosts(byte min, byte max) {
		foreach (Skill s in ListOfSkills) {
			s.Cost = GetRandomByte(min, max);
		}
	}

	public void WriteSkillData() {
		foreach (Skill s in ListOfSkills) {
			rom.Write8(SKILLSTATS + 6 * s.ID, s.GetStats());
		}
	}

	public static readonly TranslateOption[] SkillNameTranslations = {
		new ("English", rom => rom.Skills.ListOfSkills.Select(s => s.Name = s.EnglishName).ToArray()),

		new ("Japanese", rom => rom.Skills.ListOfSkills.Select(s => s.Name = s.JapaneseName).ToArray()),

	};
}
