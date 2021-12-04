namespace SMTRandoApp.Modeling;

[Flags]
internal enum StatusAffliction : ushort {
	None      = 0,

	Happy     = 1 << 0x0,
	Panic     = 1 << 0x1,
	Sealed    = 1 << 0x2,
	Shock     = 1 << 0x3,

	Freeze    = 1 << 0x4,
	Bind      = 1 << 0x5,
	Sleep     = 1 << 0x6,
	Charm     = 1 << 0x7,

	Curse     = 1 << 0x8,
	Status9   = 1 << 0x9,
	Fly       = 1 << 0xA,
	Poison    = 1 << 0xB,

	Paralysis = 1 << 0xC,
	Petrify   = 1 << 0xD,
	Dying     = 1 << 0xE,
	Dead      = 1 << 0xF,

	InstaKill = Dying | Dead,
}