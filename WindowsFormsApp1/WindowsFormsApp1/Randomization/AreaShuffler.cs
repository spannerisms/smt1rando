namespace SMTRandoApp.Randomization;

internal class AreaShuffler {
	private readonly ROMWriter rom;

	private (byte min, byte max)[] LevelRanges { get; } = {
		( 1,  4), // 00
		( 1,  6), // 01
		( 1,  5), // 02
		( 1,  5), // 03
		( 4,  8), // 04
		( 4, 12), // 05
		( 4, 11), // 06
		( 6, 12), // 07
		( 3, 13), // 08
		( 7, 15), // 09
		( 9, 18), // 0A
		( 7, 14), // 0B
		(10, 21), // 0C
		(15, 27), // 0D
		(20, 28), // 0E
		(15, 23), // 0F
		(17, 27), // 10
		(18, 30), // 11
		(18, 28), // 12
		(10, 35), // 13
		(19, 29), // 14
		(18, 35), // 15
		(20, 28), // 16
		(25, 35), // 17
		(21, 37), // 18
		(27, 40), // 19
		(29, 40), // 1A
		(33, 41), // 1B
		(35, 45), // 1C
		(29, 40), // 1D
		(35, 47), // 1E
		(30, 44), // 1F
		(30, 43), // 20
		(39, 51), // 21
		(40, 52), // 22
		(36, 54), // 23
		(36, 54), // 24
		(20, 45), // 25
		(38, 54), // 26
		(15, 37), // 27
		(45, 60), // 28
		(40, 65), // 29
		(40, 65), // 2A
		(34, 55), // 2B
		(34, 55), // 2C
		(30, 60), // 2D
		(40, 63), // 2E
		(40, 63), // 2F
		(53, 65), // 30
		(53, 65), // 31
		(55, 70), // 32
		(48, 65), // 33
		(50, 66), // 34
		(60, 71), // 35
		(45, 61), // 36
		(40, 55), // 37
		(65, 85), // 38
		(65, 85), // 39
		(65, 85), // 3A
		(65, 85), // 3B
	};

	// TODO merge into the placeholders
	// { "Arachne", min: 48, max: 48
	// { "Arioch", min: 85, max: 85
	// { "Astaroth", min: 98, max: 98
	// { "Asura", min: 110, max: 110
	// { "Beelzebub", min: 99, max: 99
	// { "BeelzebubBig", min: 108, max: 108
	// { "Belial", min: 52, max: 52
	// { "Bishamon", min: 75, max: 75
	// { "Cerberus", min: 43, max: 43
	// { "ChaosMan", min: 99, max: 99
	// { "ChaosPhantasm", min: 32, max: 32
	// { "Echidna", min: 81, max: 81
	// { "Elite4", null
	// { "FakeMom", min: 12, max: 12
	// { "Firewall", min: 58, max: 58
	// { "Gabriel", min: 96, max: 96
	// { "GabrielBig", min: 96, max: 96
	// { "Goki", min: 32, max: 32
	// { "Gotou", min: 28, max: 28
	// { "Haniel", min: 80, max: 80
	// { "IndrajitBig", min: 81, max: 81
	// { "Jikokuten", min: 59, max: 59
	// { "JudgeYama", min: 77, max: 77
	// { "Kasbeel", min: 70, max: 70
	// { "Koumokuten", min: 57, max: 57
	// { "Laboratory", min: 10, max: 10
	// { "Ladon", min: 71, max: 71
	// { "LawMan", min: 99, max: 99
	// { "LawPhantasm", min: 32, max: 32
	// { "Lilith", min: 80, max: 80
	// { "Michael", min: 116, max: 116
	// { "Nebiros", min: 46, max: 46
	// { "Nio", min: 72, max: 72
	// { "OzawaFuture", min: 43, max: 43
	// { "Raphael", min: 91, max: 91
	// { "RaphaelBig", min: 91, max: 91
	// { "RavanaBig", min: 69, max: 69
	// { "RavanaJoin", min: 53, max: 53
	// { "Surtr", min: 100, max: 100
	// { "TerminalNerd", min: 8, max: 15
	// { "Thor", min: 30, max: 30
	// { "Uriel", min: 83, max: 83
	// { "UrielBig", min: 83, max: 83
	// { "VishnuBig", min: 92, max: 92
	// { "VishnuJoin", min: 82, max: 82
	// { "YakuzaMeeting", min: 2, max: 2
	// { "Zenki", min: 32, max: 32
	// { "Zombie", min: 1, max: 1
	// { "ZombieLady", min: 2, max: 2
	// { "ZombieResearcher", min: 1, max: 1
	// { "Zouchouten", min: 55, max: 55

	public AreaShuffler(ROMWriter r) {
		rom = r;
	}

	private static readonly byte[][] GoodThemeCombos = {
		new byte[] { 0x00, 0x03, 0x04, 0x0A, 0x0D, 0x0F },

		new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
			0x09, 0x0B, 0x0C, 0x0E, 0x10, 0x11, 0x12, 0x17 },

		new byte[] { 0x03, 0x04, 0x0B, 0x0C, 0x10, 0x11 },

		new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09,
			0x0B, 0x0C, 0x0E, 0x10, 0x11, 0x12, 0x13, 0x14, 0x17 },

		new byte[] { 0x0E, 0x13, 0x14 },

		new byte[] { 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x0B,
			0x0C, 0x0E, 0x0F, 0x10, 0x11, 0x12, 0x17 }
	};


	private const int ENCOUNTERGROUPS = 0x3B;


	public static readonly ShuffleOption[] DemonEncounterShuffles = {
		new ("Vanilla", null),

		new ("Balanced", rom => {
			RandomizeAllRegularEncounters(rom, i => {
				var (min, max) = rom.World.LevelRanges[i];
				var uniques = GetRandomInt(1, 3);
				return (min, max, uniques);
			});
		}),

		new ("Chaotic", rom => {
			RandomizeAllRegularEncounters(rom, i => (0, 99, 0));

			rom.World.WriteAllScriptedFights();
		})
	};


	private delegate (byte min, byte max, int uniques) GetRandomEncounter(int group);

	private static void RandomizeAllRegularEncounters(ROMWriter rom, GetRandomEncounter func) {
		var ids = new byte[16];

		for (int i = 0; i <= ENCOUNTERGROUPS; i++) {
			var (min, max, uniques) = func(i);

			for (int j = 0; j < uniques; j++) {
				var d = rom.Demons.GetRandomUnusedDemonInLevelRange(min, max);
				ids[j] = (byte) (d?.ID ?? ZombieID);
			}

			for (int j = uniques; j < 16; j++) {
				Demon d = rom.Demons.GetRandomDemonInLevelRange(min, max);
				ids[j] = (byte) (d?.ID ?? ZombieID);
			}

			rom.Write8(ENCOUNTERTABLES + 16 * i, ids);
		}
	}

	private readonly Dictionary<ScriptedFight, List<Address>> fights = new();

	public void AddScriptedFight(ScriptedFight n, Address a) {
		List<Address> add;

		if (fights.ContainsKey(n)) {
			add = fights[n];
		} else {
			add = new();
			fights[n] = add;
		}

		add.Add(a);
	}


	private delegate void ScriptedFightWriter();

	public void WriteAllScriptedFights() {
		foreach (var (key, list) in fights) {
			if (!key.IsReallyFightable) continue;

			var add = rom.Demons.GetRandomDemonInLevelRange(key.MinLevel, key.MaxLevel).ID;

			foreach (var address in list) {
				rom.Write8(address + 1,
					(byte) ((add & 0x0100) >> 8),
					0x00,
					(byte) add
					// TODO can do number of demons in encounter here if I want eventually
				);
			}
		}
	}

	//=========================================================================================================

	private static readonly int THEMES = 28;

	public static readonly ShuffleOption[] DungeonThemeShuffles = {
		new ("Vanilla", null),

		new ("Shuffled", rom =>
			rom.Write16(THEMETABLE, rom.Read16(THEMETABLE, THEMES).ToShuffledArray())
		),

		new ("Palette-able", rom => {
			byte[] t1 = new byte[THEMES * 2];
			for (int i = 0; i < t1.Length; i += 2) {
				int a = GetRandomInt(0, 5);
				t1[i + 0] = (byte) a;
				t1[i + 1] = GoodThemeCombos[a].GetRandomElement();
			}
			rom.Write8(THEMETABLE, t1);
		}),

		new ("Atrocious", rom => {
			byte[] t2 = new byte[THEMES * 2];

			for (int i = 0; i < t2.Length; i += 2) {
				t2[i] = (byte) GetRandomInt(0x00, 0x05);
				t2[i + 1] = (byte) GetRandomInt(0x00, 0x17);
			}

			rom.Write8(THEMETABLE, t2);
		}),
	};
}

