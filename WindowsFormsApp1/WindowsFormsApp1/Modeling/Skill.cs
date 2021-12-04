namespace SMTRandoApp.Modeling;

internal partial class Skill {
	public const byte NoMove = 0xFF;

	public byte ID { get; init; }

	public string Name { get; set; }
	public string JapaneseName { get; init; }
	public string EnglishName { get; init; }

	public bool IsValid { get; private set; }

	public byte Prop0 { get; set; }
	public byte Damage { get; set; }
	public byte Prop2 { get; set; }

	private byte acc;
	public byte AccuracyClass { get => acc; set => acc = value.NibbleClamp(); }
	public byte Cost { get; set; }

	public StatusAffliction StatusInflicted { get; set; }
	public SkillType MoveType { get; init; }

	private Skill() { }

	private Skill(Skill copy) {
		var properties = GetType().GetProperties();
		foreach (var p in properties) {
			if (!p.CanWrite) continue;
			p.SetValue(this, p.GetValue(copy));
		}
	}

	public Skill Clone() => new(this);

	public byte[] GetStats() {
		return new byte[] {
			Prop0,
			Damage,
			MergeNibbles(AccuracyClass, Prop2),
			Cost,
			(byte) StatusInflicted,
			(byte) ((ushort) StatusInflicted >> 8)
		};
	}

	public static Skill[] GetFreshList() => VanillaList.Select(p => p.Clone()).ToArray();
}

