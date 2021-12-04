namespace SMTRandoApp.Randomization;

internal static class GibberishGenerator {
	public static string Generate(int minLength, int maxLength) {
		StringBuilder strB = new();

		int currentLength = 0;
		int targetLength = GetRandomInt(minLength, maxLength);

		while (currentLength < targetLength) {
			string atom = GetRandomBool() switch {
				false => consonantsFront.GetRandomElement() + vowels.GetRandomElement(),
				true => vowels[GetRandomInt(0, vowels.Length - 2)] + // -2 to ignore y
						consonantsBack.GetRandomElement()
			};

			if (atom is null) {
				break;
			} else {
				currentLength += atom.Length;
				if (currentLength > maxLength) {
					break;
				} else {
					strB.Append(atom);
				}
			}
		}

		var capitalize = strB.ToString().ToCharArray();
		capitalize[0] = char.ToUpper(capitalize[0]);

		return new(capitalize);
	}


	private static readonly string[] vowels = {
		"a", "e", "i", "o", "u", "y",
	};

	private static readonly string[] consonantsFront = {
		"b", "br", "bl", "bw",
		"c", "ch", "cr", "cl", "cw", "chr", "chl",
		"d", "dr", "dw",
		"f", "fr", "fl", "fw",
		"g", "gl", "gw", "gr",
		"h",
		"j",
		"k", "kr", "kl",
		"l",
		"m",
		"n",
		"p", "pr", "pl", "pw", "ph",
		"qu",
		"r", "rh",
		"s", "sh", "sl", "shl", "sw",
		"scr", "scl",
		"t", "tw", "th", "tr", "thr",
		"v", "vr", "vl",
		"w", "wh",
		"x",
		"y",
		"z", "zh"
	};

	private static readonly string[] consonantsBack = {
		"b",
		"c", "ch",
		"d",
		"f",
		"g",
		"j",
		"k",
		"l",
		"m",
		"n",
		"p",
		"r",
		"s", "sh",
		"t", "th",
		"v",
		"w",
		"x",
		"y",
		"z"
	};
}
