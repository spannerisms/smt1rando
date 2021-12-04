namespace SMTRandoApp.SMTROM;

internal struct Address {
	public int Version1Address { get; }
	public int Revision1Address { get; }

	public int this[ROMVersion version] => version switch {
		ROMVersion.Version1 => Version1Address,
		ROMVersion.Revision1 => Revision1Address,
		_ => 0,
	};

	public Address(int v1, int v2) {
		Version1Address = v1 & 0xFFFFFF;
		Revision1Address = v2 & 0xFFFFFF;
	}

	public Address(int v1) : this(v1, v1) { }

	public static implicit operator Address(int a) => new(a, a);

	public static explicit operator int(Address a) => a.Version1Address;

	public static Address operator +(Address a, int off) => new(a.Version1Address + off, a.Revision1Address + off);
	public static Address operator ++(Address a) => new(a.Version1Address + 1, a.Revision1Address + 1);

	public static Address operator -(Address a) => new(a.Version1Address | 0x800000, a.Revision1Address | 0x800000);

	public static Address operator -(Address a, int off) => new(a.Version1Address - off, a.Revision1Address - off);
	public static Address operator --(Address a) => new(a.Version1Address - 1, a.Revision1Address - 1);
}
