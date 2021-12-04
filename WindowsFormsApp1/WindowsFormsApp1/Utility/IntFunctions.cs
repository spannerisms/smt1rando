namespace SMTRandoApp.Utility;
internal static class IntFunctions {
	public static bool BitIsOn(this byte testValue, int testBitNumber) {
		return (testValue & (1 << testBitNumber)) != 0;
	}

	public static byte MakeBitfield(bool b7 = false, bool b6 = false, bool b5 = false, bool b4 = false,
		bool b3 = false, bool b2 = false, bool b1 = false, bool b0 = false) {
		return (byte) (
			(b0 ? 1 << 0 : 0) |
			(b1 ? 1 << 1 : 0) |
			(b2 ? 1 << 2 : 0) |
			(b3 ? 1 << 3 : 0) |
			(b4 ? 1 << 4 : 0) |
			(b5 ? 1 << 5 : 0) |
			(b6 ? 1 << 6 : 0) |
			(b7 ? 1 << 7 : 0)
		);
	}

	public static byte MergeNibbles(byte low, byte high) {
		return (byte) ((high << 4) | (low & 0xF));
	}

	public static byte NibbleClamp(this byte b) => b switch {
		< 0x10 => b,
		_ => 0xF
	};
}
