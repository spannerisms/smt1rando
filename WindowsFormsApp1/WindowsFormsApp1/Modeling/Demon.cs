namespace SMTRandoApp.Modeling;

internal class Demon : Personality {
	public string TrueName { get; init; }

	public int HitPoints { get; set; }
	public int MagicPower { get; set; }
	public byte Level { get; set; }

	public byte STR { get; set; }
	public byte INT { get; set; }
	public byte MAG { get; set; }
	public byte STM { get; set; }
	public byte SPD { get; set; }
	public byte LUK { get; set; }

	public byte Alignment { get; set; }

	private byte xp;
	public byte Experience { get => xp; set => xp = value.NibbleClamp(); }

	public byte CP { get; set; }

	public byte Move1 { get; set; }
	public byte Move2 { get; set; }
	public byte Move3 { get; set; }

	public byte Unknown1 { get; set; }
	public byte Unknown2 { get; set; }
	public byte Unknown3 { get; set; }
	public byte Unknown4 { get; set; }

	private byte dr;
	public byte DropRate { get => dr; set => dr = value.NibbleClamp(); }
	public byte DroppedItem { get; set; }

	private byte uk7;
	public byte Unknown7 { get => uk7; set => uk7 = value.NibbleClamp(); }

	private byte mds;
	public byte MagStoneDropRate { get => mds; set => mds = value.NibbleClamp(); }

	public byte Unknown8 { get; set; }

	/// <summary>
	/// The ID of a demon this boss shares a name with, if any.
	/// </summary>
	public byte SharedName { get; init; } = 0xFF;

	internal Demon() { }

	private Demon(Demon copy) {
		var properties = GetType().GetProperties();
		foreach (var p in properties) {
			if (!p.CanWrite) continue;
			p.SetValue(this, p.GetValue(copy));
		}
	}


	override public Personality Clone() => new Demon(this);

	public byte[] GetStats() {
		return new byte[24] {
			Level,

			(byte) HitPoints,
			(byte) (HitPoints >> 8),

			(byte) MagicPower,
			(byte) (MagicPower >> 8),

			STR,
			INT,
			MAG,
			STM,
			SPD,
			LUK,

			Alignment,
			Unknown1,
			Unknown2,
			Unknown3,
			Unknown4,

			Move1,
			Move2,
			Move3,

			MergeNibbles(DropRate, Experience),
			DroppedItem,
			MergeNibbles(MagStoneDropRate, Unknown7),

			CP,
			Unknown8
		};
	}
}
