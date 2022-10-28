namespace SMTRandoApp.Utility;

internal static class Constants {
	// meta info
	public static readonly string VERSION = typeof(MainForm).Assembly.GetName().Version.ToString(2);

	// generation info
	public const int SMTSIZE = 0x180000;
	public const int ROMSIZE = 0x200000;

	// sizes and such
	public const int CLASSCOUNT = 0x27;

	// rom labels
	public const string DEMONNAMEPOINTERS = "DemonNamePointers";
	public const string ITEMNAMEPOINTERS = "ItemNamePointers";
	public const string BOSSNAMEPOINTERS = "BossNamePointers";
	public const string CLASSNAMEPOINTERS = "ClassNamePointers";
	public const string SKILLNAMEPOINTERS = "SkillNamePointers";
	public const string DRINKNAMEPOINTERS = "DrinkNamePointers";

	// addresses verified as good on both versions
	public static readonly Address SHOPPRICES = new(0x03A368);
	public static readonly Address DEMONGRAPHICS = new(0x07C14F);
	public static readonly Address DEMONPALETTES = DEMONGRAPHICS + 2;
	public static readonly Address DEMONSTATS = new(0x07CBFA);
	public static readonly Address CLASSPOINTERSVANILLA = new(0x09F429);
	public static readonly Address EQUIPMENTSTATS = new(0x07ACC5);
	public static readonly Address SKILLSTATS = new(0x07B645);
	public static readonly Address SHOPSTOCKPOINTERS = new(0x03A1EA);
	public static readonly Address ENCOUNTERTABLES = new(0x07BD49);

	public static readonly Address DungeonRoomData = new(0x048000);
	public static readonly Address DungeonIDData = new(0x04C000);
	public static readonly Address NPCLocations = new(0x07A40D);
	public static readonly Address ChestLocations = new(0x07AAC0);
	public static readonly Address FreeHoles = new(0x079EFD);
	public static readonly Address WarpHoles = new(0x0792E5);

	// addresses known to differ between versions
	public static readonly Address HEROLEARNPOINTERS = new(0x01AEDD, 0x01AEEF);
	public static readonly Address EXPREWRITE = new(0x01B703, 0x01B715);
	public static readonly Address THEMETABLE = new(0x00DAE8, 0x00DAEB);

	// colors
	// public static readonly Color SELBLUE = Color.FromArgb(33, 148, 216);
	// public static readonly Color BORDERL = Color.FromArgb(99, 123, 115);
	// public static readonly Color BORDERD = Color.FromArgb(57, 66, 57);
	// public static readonly Color MENURED = Color.FromArgb(214, 0, 0);
	// public static readonly Color MENUBLUE = Color.FromArgb(0, 0, 49);

	public const byte ZombieID = 0xF2;
}
