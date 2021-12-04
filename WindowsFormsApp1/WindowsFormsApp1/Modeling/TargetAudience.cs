namespace SMTRandoApp.Modeling;

/// <summary>
/// Specifies constants denoting which demographics are allowed to use a particular piece of equipment.
/// </summary>
[Flags]
internal enum TargetAudience : byte {
	NoOne = 0,
	Law = 1 << 0,
	Neutral = 1 << 1,
	Chaos = 1 << 2,

	Female = 1 << 6,
	Male = 1 << 7,

	BothGenders = Male | Female,
	AllReligions = Law | Neutral | Chaos,
	Everyone = BothGenders | AllReligions,
}