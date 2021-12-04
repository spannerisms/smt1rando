namespace SMTRandoApp.Utility;

internal static class ConsistentRandom {
	private static Random seedseq = new();

	public static int GetRandomInt() => seedseq.Next();

	/// <summary>
	/// Returns a random number in the range [<paramref name="low"/>, <paramref name="high"/>];
	/// inclusive of the upper bound.
	/// </summary>
	public static int GetRandomInt(int low, int high) => seedseq.Next(low, high + 1);

	/// <summary>
	/// Returns a random <see langword="byte"/> in the range [<paramref name="low"/>, <paramref name="high"/>];
	/// inclusive of the upper bound.
	/// </summary>
	public static byte GetRandomByte() => (byte) seedseq.Next(256);

	public static byte GetRandomByte(int low, int high) => (byte) seedseq.Next(low, high + 1);

	public static byte GetRandomNibble() => (byte) seedseq.Next(16);


	/// <summary>
	/// Returns <see langword="true"/> with a <paramref name="chance"/>% chance.
	/// </summary>
	public static bool GetSuccessForChance(double chance) => chance > seedseq.NextDouble();

	public static bool GetRandomBool() => (seedseq.Next() & 1) is 1;

	public static byte[] GetRandomBytes(int count, int low, int high) {
		byte[] ret = new byte[count];

		for (int i = 0; i < count; i++) {
			ret[i] = GetRandomByte(low, high);
		}

		return ret;
	}
	public static void ReseedRNG(string s = null) {
		seedseq = new(s?.GetHashCode() ?? (int) DateTime.Now.Ticks);
	}

	private const string reseedchars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

	public static string GenerateNewSeedString() {
		Random r = new();

		var ret = new StringBuilder();

		for (int i = 0; i < 10; i++) {
			ret.Append(reseedchars[r.Next(reseedchars.Length)]);
		}

		return ret.ToString();
	}
}
