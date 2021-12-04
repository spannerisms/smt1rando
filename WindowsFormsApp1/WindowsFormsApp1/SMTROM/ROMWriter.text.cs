namespace SMTRandoApp.SMTROM;

partial class ROMWriter {
	private readonly Dictionary<string, Address> LabelsList = new();

	/// <summary>
	/// Writes a bunch of Strings to ROM.
	/// </summary>
	/// <param name="table">Location of the table of pointers for these items</param>
	/// <param name="start">Start address where text will be written</param>
	/// <param name="list">List of text items</param>
	public void WriteNamesWithLabels(Address table, ref Address start, string[] list) {
		var adding = table;

		foreach (string s in list) {
			if (s is null) {
				Write16iContinuous(ref adding, (int) GetLabel("truly_null"));
				continue;
			}


			Write16iContinuous(ref adding, (int) start);

			foreach (char c in s) {
				Write8Continuous(ref start, Encoding[c]);
			}

			this[start++] = 0xFF;
		}
	}

	/// <summary>
	/// Patches every bank of English text into the ROM
	/// </summary>
	public void PatchAllEnglishText() {
		int pointer;

		// --------------------------------------------------------------------------------
		// Bank08
		// --------------------------------------------------------------------------------
		PatchTextBank(0x088000, Bank08TextData.Data);

		// fix some pointers
		pointer = (int) LabelsList["data08FF9B"];
		Write16i(0x0381A3 + 1, pointer);
		Write16i(0x0381E7 + 1, pointer);
		Write16i(0x0F8C2D + 1, pointer);

		pointer = (int) LabelsList["data08FF89"];
		Write16i(0x03E1BD + 1, pointer);
		Write16i(0x03E4D3 + 1, pointer);

		pointer = (int) LabelsList["data08FFC1"];
		Write16i(0x03B3C4 + 1, pointer);


		// --------------------------------------------------------------------------------
		// Bank 09
		// --------------------------------------------------------------------------------
		PatchTextBank(0x098000, Bank09TextData.Data);

		pointer = (int) LabelsList[BOSSNAMEPOINTERS];
		Write16i(0x039274 + 1, pointer);

		pointer = (int) LabelsList[CLASSNAMEPOINTERS];
		Write16i(0x00AA6A + 1, pointer);
		Write16i(0x03928B + 1, pointer);
		Write16i(0x03CFFB + 1, pointer);
		Write16i(0x03E23A + 1, pointer);
		Write16i(0x03E31B + 1, pointer);
		Write16i(0x03E442 + 1, pointer);
		Write16i(new Address(0x03FC50, 0x03FC52) + 1, pointer);
		Write16i(new Address(0x03FD66, 0x03FD68) + 1, pointer);

		pointer = (int) LabelsList[DEMONNAMEPOINTERS];
		Write16i(0x00AA5B + 1, pointer);
		Write16i(0x039264 + 1, pointer);
		Write16i(0x03CFDF + 1, pointer);
		Write16i(0x03DC71 + 1, pointer);
		Write16i(0x03E278 + 1, pointer);
		Write16i(0x03E2D5 + 1, pointer);
		Write16i(0x03E484 + 1, pointer);
		Write16i(new Address(0x03FC8E, 0x03FC90) + 1, pointer);
		Write16i(new Address(0x03FDA4, 0x03FDA6) + 1, pointer);
		Write16i(new Address(0x03FED5, 0x03FED7) + 1, pointer);

		pointer = (int) LabelsList[DRINKNAMEPOINTERS];
		Write16i(0x03C189 + 1, pointer);
		Write16i(0x03C2E9 + 1, pointer);

		pointer = (int) LabelsList[ITEMNAMEPOINTERS];
		Write16i(0x00AA88 + 1, pointer);
		Write16i(0x03922A + 1, pointer);
		Write16i(0x0F94E9 + 1, pointer);

		pointer = (int) LabelsList[SKILLNAMEPOINTERS];
		Write16i(0x00AA79 + 1, pointer);
		Write16i(0x039246 + 1, pointer);

		Write16i(0x0388D5, (int) LabelsList["MessageSelectionPointers"]);
		Write16i(0x0388D7, (int) LabelsList["BattleSelectionPointers"]);

		// --------------------------------------------------------------------------------
		// Bank 0A
		// --------------------------------------------------------------------------------
		PatchTextBank(0x0A8000, Bank0ATextData.Data);

		// --------------------------------------------------------------------------------
		// Bank 09
		// --------------------------------------------------------------------------------
		PatchTextBank(0x0B8000, Bank0BTextData.Data);

		// --------------------------------------------------------------------------------
		// other
		// --------------------------------------------------------------------------------
		// these message ids need fixing in REV 1
		Write16(0x039CCF,
			0x2D08, 0x3008, 0x3108, 0x3608, 0x3908);

		Write16(0x039FE9,
			0x4702, 0x4C02, 0x5102, 0x5502, 0x5902, 0x5E02, 0x6002, 0x6902,
			0x6B02, 0x7402, 0x7602, 0x7F02, 0x9302, 0x9502, 0xA002, 0xA202,
			0xAD02, 0xAF02, 0xBA02, 0xC002, 0xDB02, 0xDD02, 0xE902, 0xEB02);

		Write16(0x039D2D,
			0x160A, 0x170A, 0x1C0A, 0x1D0A, 0x1E0A, 0x1F0A, 0x200A, 0x210A,
			0x220A, 0x230A, 0x240A, 0x250A, 0x290A);

		// YES/NO for selections
		Write8(0x0393A8,
			Encoding['Y'], 0x20,
			Encoding['e'], 0x20,
			Encoding['s'], 0x20);

		Write8(0x0393AE,
			Encoding['N'], 0x20,
			Encoding['o'], 0x20,
			Encoding[' '], 0x20);

		// save/load file
		PatchStrings(0x0F8D6F, "READ WHICH FILE?", "SAVE WHICH FILE?");

		this[0x0F8B9D + 1] = 0x00;
		PatchChar(0x0F8B18, ' ');

		PatchString(0x0F8B24, "HERE? ", 2);
		PatchString(0x0F8B48, "YES", 2);
		PatchString(0x0F8B68, "NO ", 2);

		PatchChar(0x0F8CB3 + 1, ' ');
		PatchChar(0x0F8CBD + 1, 'L');
		PatchChar(0x0F8CC3 + 1, 'v');
		PatchChar(0x0F8CC9 + 1, 'l');

		// elevators
		PatchChar(0x03B856, ' ');
		PatchChar(0x03B863, ' ');
		PatchChar(0x03B865, ' ');

		PatchStrings(0x03B868, "Select a floor:   ");

		Write8(0x07F0F1, 0x00, 0xEC, 0xC6, 0xC3, 0xC3, 0xC8, 0xFF, 0x00);

		// healing
		PatchStrings(0x03D47C + 1, "Cost ");
		PatchStrings(0x03D49A + 1, "Cost ");

		PatchStrings(0x0F9773,
			"Heal whose HP?  ",
			"Recover whom?   ",
			"Whose curse?    ",
			"Revive whom?    ",

			"Heal whose HP?  ",
			"Recover whom?   ",
			"Whose curse?    ",
			"Revive whom?    ",

			"Heal whose HP?  ",
			"Recover whom?   ",
			"Whose curse?    ",
			"Revive whom?    ");

		// stats screen things
		this[0x018596 + 1] = 0x00;
		this[0x018E85 + 1] = 0x00;

		// this table is super dumb
		PatchString(0x07ECF6 + 2, "TYNheois\0s     g  o  o  d  ?  ", 4);

		this[0x07ED0E] = 0x00;
		this[0x07ED3E] = 0x00;

		PatchStrings(0x07EFBD,
			"LV  ",
			"HP  ",
			"MP  ",
			"EXP ",
			"NEXT",
			"ST  ",
			"SWD ",
			"GUN ",
			"AMM ",
			"HAT ",
			"BOD ",
			"ARM ",
			"LEG ",
			"POW ",
			"ACC ",
			"DEF ",
			"EVA ",
			"MPW ",
			"MFX ",
			"    ",
			"    ",
			"    ",
			"    ",
			"    ",
			"    ",
			"STR ",
			"INT ",
			"MAG ",
			"VIT ",
			"SPD ",
			"LUK ",
			"CP  ",

			"ALIGN   ",
			"     LAW",
			" NEUTRAL",
			"   CHAOS",

			"    ",
			"    ",
			"    ",
			"    ",
			"    ",
			"    ",
			"    ",

			"PTS ",
			"    ");
	}

	public void PatchChar(Address pointer, char c) {
		this[pointer] = Encoding[c];
	}

	public void PatchStrings(Address pointer, params string[] texts) {
		foreach (string s in texts) {
			foreach (char c in s) {
				this[pointer++] = Encoding[c];
			}
		}
	}

	public void PatchString(Address pointer, string text, int interval) {
		foreach (char c in text) {
			this[pointer] = Encoding[c];
			pointer += interval;
		}
	}


	private void PatchTextBank(Address address, object[] data) {
		List<LabelPlaceholder> LabelsRequested = new();

		foreach (var o in data) {
			switch (o) {
				case LabelName ln:
					LabelsList[ln.Name] = (int) address;
					if (ln.IsCritical) {
						AddCriticalLabel(ln.Name, address);
					}
					break;

				case LabelRequest lr:
					var (name, size) = lr;
					LabelsRequested.Add(new(name, (int) address, size));
					address += size;
					break;

				case ITextCommand tc:
					if (tc is ScriptedFight sf) {
						World.AddScriptedFight(sf, address);
					}
					AddCriticalLabel(tc.Name, address);
					Write8Continuous(ref address, tc.Data);
					break;

				case int ii:
					this[address++] = (byte) ii;
					break;

				case string os:
					foreach (char c in os) {
						this[address++] = Encoding[c];
					}
					break;
			}
		}

		foreach (var (name, add, _) in LabelsRequested) {
			Write16i(add, (int) LabelsList[name]);
		}
	}



	public static Dictionary<char, byte> Encoding { get; } = new() {
		{ '\0', 0x00 }, // null

		{ '0', 0x01 }, // Arabic numerals
		{ '1', 0x02 }, // Arabic numerals
		{ '2', 0x03 }, // Arabic numerals
		{ '3', 0x04 }, // Arabic numerals
		{ '4', 0x05 }, // Arabic numerals
		{ '5', 0x06 }, // Arabic numerals
		{ '6', 0x07 }, // Arabic numerals
		{ '7', 0x08 }, // Arabic numerals
		{ '8', 0x09 }, // Arabic numerals
		{ '9', 0x0A }, // Arabic numerals

		{ 'A', 0x0B }, // Latin letters
		{ 'B', 0x0C }, // Latin letters
		{ 'C', 0x0D }, // Latin letters
		{ 'D', 0x0E }, // Latin letters
		{ 'E', 0x0F }, // Latin letters
		{ 'F', 0x10 }, // Latin letters
		{ 'G', 0x11 }, // Latin letters
		{ 'H', 0x12 }, // Latin letters
		{ 'I', 0x13 }, // Latin letters
		{ 'J', 0x14 }, // Latin letters
		{ 'K', 0x15 }, // Latin letters
		{ 'L', 0x16 }, // Latin letters
		{ 'M', 0x17 }, // Latin letters
		{ 'N', 0x18 }, // Latin letters
		{ 'O', 0x19 }, // Latin letters
		{ 'P', 0x1A }, // Latin letters
		{ 'Q', 0x1B }, // Latin letters
		{ 'R', 0x1C }, // Latin letters
		{ 'S', 0x1D }, // Latin letters
		{ 'T', 0x1E }, // Latin letters
		{ 'U', 0x1F }, // Latin letters
		{ 'V', 0x20 }, // Latin letters
		{ 'W', 0x21 }, // Latin letters
		{ 'X', 0x22 }, // Latin letters
		{ 'Y', 0x23 }, // Latin letters
		{ 'Z', 0x24 }, // Latin letters
		{ 'a', 0x0B }, // Latin letters
		{ 'b', 0x0C }, // Latin letters
		{ 'c', 0x0D }, // Latin letters
		{ 'd', 0x0E }, // Latin letters
		{ 'e', 0x0F }, // Latin letters
		{ 'f', 0x10 }, // Latin letters
		{ 'g', 0x11 }, // Latin letters
		{ 'h', 0x12 }, // Latin letters
		{ 'i', 0x13 }, // Latin letters
		{ 'j', 0x14 }, // Latin letters
		{ 'k', 0x15 }, // Latin letters
		{ 'l', 0x16 }, // Latin letters
		{ 'm', 0x17 }, // Latin letters
		{ 'n', 0x18 }, // Latin letters
		{ 'o', 0x19 }, // Latin letters
		{ 'p', 0x1A }, // Latin letters
		{ 'q', 0x1B }, // Latin letters
		{ 'r', 0x1C }, // Latin letters
		{ 's', 0x1D }, // Latin letters
		{ 't', 0x1E }, // Latin letters
		{ 'u', 0x1F }, // Latin letters
		{ 'v', 0x20 }, // Latin letters
		{ 'w', 0x21 }, // Latin letters
		{ 'x', 0x22 }, // Latin letters
		{ 'y', 0x23 }, // Latin letters
		{ 'z', 0x24 }, // Latin letters

		{ 'ō', 0x19 }, // Japanese o
		
		{ 'あ', 0x25 }, // Hiragana
		{ 'い', 0x26 }, // Hiragana
		{ 'う', 0x27 }, // Hiragana
		{ 'え', 0x28 }, // Hiragana
		{ 'お', 0x29 }, // Hiragana
		{ 'か', 0x2A }, // Hiragana
		{ 'き', 0x2B }, // Hiragana
		{ 'く', 0x2C }, // Hiragana
		{ 'け', 0x2D }, // Hiragana
		{ 'こ', 0x2E }, // Hiragana
		{ 'さ', 0x2F }, // Hiragana
		{ 'し', 0x30 }, // Hiragana
		{ 'す', 0x31 }, // Hiragana
		{ 'せ', 0x32 }, // Hiragana
		{ 'そ', 0x33 }, // Hiragana
		{ 'た', 0x34 }, // Hiragana
		{ 'ち', 0x35 }, // Hiragana
		{ 'つ', 0x36 }, // Hiragana
		{ 'て', 0x37 }, // Hiragana
		{ 'と', 0x38 }, // Hiragana
		{ 'な', 0x39 }, // Hiragana
		{ 'に', 0x3A }, // Hiragana
		{ 'ぬ', 0x3B }, // Hiragana
		{ 'ね', 0x3C }, // Hiragana
		{ 'の', 0x3D }, // Hiragana
		{ 'は', 0x3E }, // Hiragana
		{ 'ひ', 0x3F }, // Hiragana
		{ 'ふ', 0x40 }, // Hiragana
		{ 'へ', 0x41 }, // Hiragana
		{ 'ほ', 0x42 }, // Hiragana
		{ 'ま', 0x43 }, // Hiragana
		{ 'み', 0x44 }, // Hiragana
		{ 'む', 0x45 }, // Hiragana
		{ 'め', 0x46 }, // Hiragana
		{ 'も', 0x47 }, // Hiragana
		{ 'や', 0x48 }, // Hiragana
		{ 'ゆ', 0x49 }, // Hiragana
		{ 'よ', 0x4A }, // Hiragana
		{ 'ら', 0x4B }, // Hiragana
		{ 'り', 0x4C }, // Hiragana
		{ 'る', 0x4D }, // Hiragana
		{ 'れ', 0x4E }, // Hiragana
		{ 'ろ', 0x4F }, // Hiragana
		{ 'わ', 0x50 }, // Hiragana
		{ 'を', 0x51 }, // Hiragana
		{ 'ん', 0x52 }, // Hiragana
		{ 'ぁ', 0x53 }, // Hiragana
		{ 'ぉ', 0x54 }, // Hiragana
		{ 'ゃ', 0x55 }, // Hiragana
		{ 'ゅ', 0x56 }, // Hiragana
		{ 'ょ', 0x57 }, // Hiragana
		{ 'っ', 0x58 }, // Hiragana
		{ 'ぅ', 0x59 }, // Hiragana
		{ 'ー', 0x5A }, // Hiragana
		{ '-', 0x5A }, // Hiragana

		{ '￥', 0x5B }, // Yen
		{ 'ħ', 0x5C }, // Macca

		{ 'ア', 0x5D }, // Katakana
		{ 'イ', 0x5E }, // Katakana
		{ 'ウ', 0x5F }, // Katakana
		{ 'エ', 0x60 }, // Katakana
		{ 'オ', 0x61 }, // Katakana
		{ 'カ', 0x62 }, // Katakana
		{ 'キ', 0x63 }, // Katakana
		{ 'ク', 0x64 }, // Katakana
		{ 'ケ', 0x65 }, // Katakana
		{ 'コ', 0x66 }, // Katakana
		{ 'サ', 0x67 }, // Katakana
		{ 'シ', 0x68 }, // Katakana
		{ 'ス', 0x69 }, // Katakana
		{ 'セ', 0x6A }, // Katakana
		{ 'ソ', 0x6B }, // Katakana
		{ 'タ', 0x6C }, // Katakana
		{ 'チ', 0x6D }, // Katakana
		{ 'ツ', 0x6E }, // Katakana
		{ 'テ', 0x6F }, // Katakana
		{ 'ト', 0x70 }, // Katakana
		{ 'ナ', 0x71 }, // Katakana
		{ 'ニ', 0x72 }, // Katakana
		{ 'ヌ', 0x73 }, // Katakana
		{ 'ネ', 0x74 }, // Katakana
		{ 'ノ', 0x75 }, // Katakana
		{ 'ハ', 0x76 }, // Katakana
		{ 'ヒ', 0x77 }, // Katakana
		{ 'フ', 0x78 }, // Katakana
		{ 'ヘ', 0x79 }, // Katakana
		{ 'ホ', 0x7A }, // Katakana
		{ 'マ', 0x7B }, // Katakana
		{ 'ミ', 0x7C }, // Katakana
		{ 'ム', 0x7D }, // Katakana
		{ 'メ', 0x7E }, // Katakana
		{ 'モ', 0x7F }, // Katakana
		{ 'ヤ', 0x80 }, // Katakana
		{ 'ユ', 0x81 }, // Katakana
		{ 'ヨ', 0x82 }, // Katakana
		{ 'ラ', 0x83 }, // Katakana
		{ 'リ', 0x84 }, // Katakana
		{ 'ル', 0x85 }, // Katakana
		{ 'レ', 0x86 }, // Katakana
		{ 'ロ', 0x87 }, // Katakana
		{ 'ワ', 0x88 }, // Katakana
		{ 'ヲ', 0x89 }, // Katakana
		{ 'ン', 0x8A }, // Katakana
		{ 'ァ', 0x8B }, // Katakana
		{ 'ィ', 0x8C }, // Katakana
		{ 'ェ', 0x8D }, // Katakana
		{ 'ォ', 0x8E }, // Katakana
		{ 'ャ', 0x8F }, // Katakana
		{ 'ュ', 0x90 }, // Katakana
		{ 'ョ', 0x91 }, // Katakana
		{ 'ッ', 0x92 }, // Katakana

		{ '・', 0x93 }, // Punctuation
		{ ',', 0x93 }, // Punctuation
		{ '!', 0x94 }, // Punctuation
		{ '?', 0x95 }, // Punctuation
		{ '&', 0x96 }, // Punctuation
		{ '>', 0x97 }, // Punctuation
		{ '/', 0x98 }, // Punctuation
		{ '\'', 0x99 }, // Punctuation
		{ ':', 0x9A }, // Punctuation
		{ '.', 0x9B }, // Punctuation

		{ 'が', 0x9C }, // Hiragana
		{ 'ぎ', 0x9D }, // Hiragana
		{ 'ぐ', 0x9E }, // Hiragana
		{ 'げ', 0x9F }, // Hiragana
		{ 'ご', 0xA0 }, // Hiragana
		{ 'ざ', 0xA1 }, // Hiragana
		{ 'じ', 0xA2 }, // Hiragana
		{ 'ず', 0xA3 }, // Hiragana
		{ 'ぜ', 0xA4 }, // Hiragana
		{ 'ぞ', 0xA5 }, // Hiragana
		{ 'だ', 0xA6 }, // Hiragana
		{ 'ぢ', 0xA7 }, // Hiragana
		{ 'づ', 0xA8 }, // Hiragana
		{ 'で', 0xA9 }, // Hiragana
		{ 'ど', 0xAA }, // Hiragana
		{ 'ば', 0xAB }, // Hiragana
		{ 'び', 0xAC }, // Hiragana
		{ 'ぶ', 0xAD }, // Hiragana
		{ 'べ', 0xAE }, // Hiragana
		{ 'ぼ', 0xAF }, // Hiragana
		{ 'ぱ', 0xB0 }, // Hiragana
		{ 'ぴ', 0xB1 }, // Hiragana
		{ 'ぷ', 0xB2 }, // Hiragana
		{ 'ぺ', 0xB3 }, // Hiragana
		{ 'ぽ', 0xB4 }, // Hiragana

		{ 'ガ', 0xB5 }, // Katakana
		{ 'ギ', 0xB6 }, // Katakana
		{ 'グ', 0xB7 }, // Katakana
		{ 'ゲ', 0xB8 }, // Katakana
		{ 'ゴ', 0xB9 }, // Katakana
		{ 'ザ', 0xBA }, // Katakana
		{ 'ジ', 0xBB }, // Katakana
		{ 'ズ', 0xBC }, // Katakana
		{ 'ゼ', 0xBD }, // Katakana
		{ 'ゾ', 0xBE }, // Katakana
		{ 'ダ', 0xBF }, // Katakana
		{ 'ヂ', 0xC0 }, // Katakana
		{ 'ヅ', 0xC1 }, // Katakana
		{ 'デ', 0xC2 }, // Katakana
		{ 'ド', 0xC3 }, // Katakana
		{ 'バ', 0xC4 }, // Katakana
		{ 'ビ', 0xC5 }, // Katakana
		{ 'ブ', 0xC6 }, // Katakana
		{ 'ベ', 0xC7 }, // Katakana
		{ 'ボ', 0xC8 }, // Katakana
		{ 'パ', 0xC9 }, // Katakana
		{ 'ピ', 0xCA }, // Katakana
		{ 'プ', 0xCB }, // Katakana
		{ 'ペ', 0xCC }, // Katakana
		{ 'ポ', 0xCD }, // Katakana
		{ 'ヴ', 0xCE }, // Katakana

		{ ' ', 0xCF }, // Space

		{ '\n', 0xF9 }, // newline

	};
}
