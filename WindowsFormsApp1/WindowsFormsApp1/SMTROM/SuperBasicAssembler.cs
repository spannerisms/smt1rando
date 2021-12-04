using System.Text.RegularExpressions;

namespace SMTRandoApp.SMTROM;
// Basic assembler just so that I don't need to distribute an asar.dll
static class SuperBasicAssembler {
	private const string ORG = @"org (\$[A-Fa-f\d]{6}|V\([A-Fa-f\d]{6},[A-Fa-f\d]{6}\))";
	private const string VARADDRESS = @"V\(([A-Fa-f\d]{6}),([A-Fa-f\d]{6})\)";
	private const string INTADDRESS = @"(\d+)";
	private const string HEXADDRESS = @"\$([A-Fa-f\d]+)";
	private const string LABADDRESS = @"([A-Za-z_][A-Za-z\d_]+)";

	private const string LABEL = @"([A-Za-z_][a-zA-Z\d_]+):";

	private static bool REV1;
	public static void Apply(ROMWriter r, string a) {
		REV1 = r.Version is ROMVersion.Revision1;

		// each instruction must be on a new line
		string[] lines = a.Split('\t', '\n', '\r');

		Dictionary<string, int> LabelsList = new();
		List<LabelPlaceholder> RequestsList = new();
		List<LabelPlaceholder> RelativesList = new();
		int pc = 0;
		int x;
		Match m;

		foreach (string li in lines) {
			var l = li.Trim();

			if ((m = Regex.Match(l, ORG)).Success) {
				pc = GetOperand(m.Groups[1].Value);
				continue;
			}
			if ((m = Regex.Match(l, LABEL)).Success) {
				LabelsList[m.Groups[1].Value] = pc;
				continue;
			}

			foreach (var i in Instruction.OPS) {
				m = Regex.Match(l, i.Pattern);
				if (!m.Success) continue;

				switch (i.Opcode) {
					default:
						r.Write8(pc, i.Opcode);
						x = GetOperand(m.Groups[0].Value);
						if (x == -1) {
							RequestsList.Add(
								new LabelPlaceholder(
									Regex.Match(m.Groups[1].Value,LABADDRESS).Groups[1].Value,
									pc + 1,
									i.OperandSize
								));
							break;
						}

						WriteForSize(r, pc, i.OperandSize, x);

						break;

					case 0x10: // BPL rel
					case 0x30: // BMI rel
					case 0x50: // BVC rel
					case 0x62: // PER rel
					case 0x70: // BVS rel
					case 0x80: // BRA rel
					case 0x82: // BRL rel
					case 0x90: // BCC rel
					case 0xB0: // BCS rel
					case 0xD0: // BNE rel
					case 0xF0: // BEQ rel
						r[pc] = i.Opcode;
						x = GetOperand(m.Groups[0].Value);
						if (x == -1) {
							RelativesList.Add(
								new LabelPlaceholder(
									Regex.Match(m.Groups[1].Value, LABADDRESS).Groups[1].Value,
									pc + 1,
									i.OperandSize
								));
							break;
						}

						WriteForSize(r, pc, i.OperandSize, x - (pc + i.Size));

						break;

					case 0x44:
					case 0x54:

						break;

				}
				pc += i.Size;
			}
		}

		foreach (LabelPlaceholder d in RequestsList) {
			WriteForSize(r, d.Address, d.Size, LabelsList[d.Name]);
		}

		foreach (LabelPlaceholder d in RelativesList) {
			WriteForSize(r, d.Address, d.Size, LabelsList[d.Name] - (d.Address + d.Size - 1));
		}


		static void WriteForSize(ROMWriter r, int address, int size, int value) {
			for (int i = 0; i < size; i++) {
				r[address++] = (byte) value;
				value >>= 8;
			}
		}
	}


	private static int GetOperand(string s) {
		Match m;

		if ((m = Regex.Match(s, VARADDRESS)).Success) {
			return int.Parse(m.Groups[REV1 ? 2 : 1].Value, System.Globalization.NumberStyles.HexNumber);
		}

		if ((m = Regex.Match(s, HEXADDRESS)).Success) {
			return int.Parse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber);
		}

		if ((m = Regex.Match(s, INTADDRESS)).Success) {
			return int.Parse(m.Groups[1].Value, System.Globalization.NumberStyles.Number);
		}

		return -1;
	}

	private struct Instruction {
		public string Pattern { get; init; }
		public byte Size { get; init; }
		public byte OperandSize { get; init; }
		public byte Opcode { get; init; }

		private Instruction(byte o, byte s, string p) {
			Pattern = $"^{p}(\\s|$)";
			Size = s;
			OperandSize = --s;
			Opcode = o;
		}

		internal readonly static Instruction[] OPS = new Instruction[] {
			new Instruction(0x00, 2, @"BRK #?(\$?[A-Za-z_\d]+)"),
			new Instruction(0x01, 2, @"ORA\.b \((\$?[A-Za-z_\d]+),X\)"),
			new Instruction(0x02, 2, @"COP #?(\$?[A-Za-z_\d]+)"),
			new Instruction(0x03, 2, @"ORA (\$?[A-Za-z_\d]+),S"),
			new Instruction(0x04, 2, @"TSB\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x05, 2, @"ORA\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x06, 2, @"ASL\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x07, 2, @"ORA\.b \[(\$?[A-Za-z_\d]+)\]"),
			new Instruction(0x08, 1, @"PHP"),
			new Instruction(0x09, 2, @"ORA\.b #(\$?[A-Za-z_\d]+)"),
			new Instruction(0x09, 3, @"ORA\.w #(\$?[A-Za-z_\d]+)"),
			new Instruction(0x0A, 1, @"ASL A"),
			new Instruction(0x0B, 1, @"PHD"),
			new Instruction(0x0C, 3, @"TSB\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x0D, 3, @"ORA\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x0E, 3, @"ASL\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x0F, 4, @"ORA\.l (\$?[A-Za-z_\d]+)"),
			new Instruction(0x10, 2, @"BPL (\$?[A-Za-z_\d]+)"),
			new Instruction(0x11, 2, @"ORA\.b \((\$?[A-Za-z_\d]+)\),Y"),
			new Instruction(0x12, 2, @"ORA\.b \((\$?[A-Za-z_\d]+)\)"),
			new Instruction(0x13, 2, @"ORA \((\$?[A-Za-z_\d]+),S\),Y"),
			new Instruction(0x14, 2, @"TRB\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x15, 2, @"ORA\.b (\$?[A-Za-z_\d]+), X"),
			new Instruction(0x16, 2, @"ASL\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x17, 2, @"ORA\.b \[(\$?[A-Za-z_\d]+)\],Y"),
			new Instruction(0x18, 1, @"CLC"),
			new Instruction(0x19, 3, @"ORA\.w (\$?[A-Za-z_\d]+),Y"),
			new Instruction(0x1A, 1, @"INC A"),
			new Instruction(0x1B, 1, @"TCS"),
			new Instruction(0x1C, 3, @"TRB\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x1D, 3, @"ORA\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x1E, 3, @"ASL\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x1F, 4, @"ORA\.l (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x20, 3, @"JSR (\$?[A-Za-z_\d]+)"),
			new Instruction(0x20, 3, @"JSR\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x21, 2, @"AND\.b \((\$?[A-Za-z_\d]+),X\)"),
			new Instruction(0x22, 4, @"JSL (\$?[A-Za-z_\d]+)"),
			new Instruction(0x22, 4, @"JSL\.l (\$?[A-Za-z_\d]+)"),
			new Instruction(0x23, 2, @"AND (\$?[A-Za-z_\d]+),S"),
			new Instruction(0x24, 2, @"BIT\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x25, 2, @"AND\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x26, 2, @"ROL\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x27, 2, @"AND\.b \[(\$?[A-Za-z_\d]+)\]"),
			new Instruction(0x28, 1, @"PLP"),
			new Instruction(0x29, 2, @"AND\.b #(\$?[A-Za-z_\d]+)"),
			new Instruction(0x29, 3, @"AND\.w #(\$?[A-Za-z_\d]+)"),
			new Instruction(0x2A, 1, @"ROL A"),
			new Instruction(0x2B, 1, @"PLD"),
			new Instruction(0x2C, 3, @"BIT\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x2D, 3, @"AND\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x2E, 3, @"ROL\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x2F, 4, @"AND\.l (\$?[A-Za-z_\d]+)"),
			new Instruction(0x30, 2, @"BMI (\$?[A-Za-z_\d]+)"),
			new Instruction(0x31, 2, @"AND\.b \((\$?[A-Za-z_\d]+)\),Y"),
			new Instruction(0x32, 2, @"AND\.b \((\$?[A-Za-z_\d]+)\)"),
			new Instruction(0x33, 2, @"AND \((\$?[A-Za-z_\d]+),S\),Y"),
			new Instruction(0x34, 2, @"BIT\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x35, 2, @"AND\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x36, 2, @"ROL\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x37, 2, @"AND\.b \[(\$?[A-Za-z_\d]+)\],Y"),
			new Instruction(0x38, 1, @"SEC"),
			new Instruction(0x39, 3, @"AND\.w (\$?[A-Za-z_\d]+),Y"),
			new Instruction(0x3A, 1, @"DEC A"),
			new Instruction(0x3B, 1, @"TSC"),
			new Instruction(0x3C, 3, @"BIT\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x3D, 3, @"AND\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x3E, 3, @"ROL\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x3F, 4, @"AND\.l (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x40, 1, @"RTI"),
			new Instruction(0x41, 2, @"EOR\.b \((\$?[A-Za-z_\d]+),X\)"),
			new Instruction(0x42, 2, @"WDM #?(\$?[A-Za-z_\d]+)"),
			new Instruction(0x43, 2, @"EOR (\$?[A-Za-z_\d]+),S"),
			new Instruction(0x44, 3, @"MVP (\$?[A-Za-z_\d]+),d(\$?[A-Za-z_\d]+)"),
			new Instruction(0x45, 2, @"EOR\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x46, 2, @"LSR\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x47, 2, @"EOR\.b \[(\$?[A-Za-z_\d]+)\]"),
			new Instruction(0x48, 1, @"PHA"),
			new Instruction(0x49, 2, @"EOR\.b #(\$?[A-Za-z_\d]+)"),
			new Instruction(0x49, 3, @"EOR\.w #(\$?[A-Za-z_\d]+)"),
			new Instruction(0x4A, 1, @"LSR A"),
			new Instruction(0x4B, 1, @"PHK"),
			new Instruction(0x4C, 3, @"JMP (\$?[A-Za-z_\d]+)"),
			new Instruction(0x4C, 3, @"JMP\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x4D, 3, @"EOR\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x4E, 3, @"LSR\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x4F, 4, @"EOR\.l (\$?[A-Za-z_\d]+)"),
			new Instruction(0x50, 2, @"BVC (\$?[A-Za-z_\d]+)"),
			new Instruction(0x51, 2, @"EOR\.b \((\$?[A-Za-z_\d]+)\),Y"),
			new Instruction(0x52, 2, @"EOR\.b \((\$?[A-Za-z_\d]+)\)"),
			new Instruction(0x53, 2, @"EOR \((\$?[A-Za-z_\d]+),S\),Y"),
			new Instruction(0x54, 3, @"MVN (\$?[A-Za-z_\d]+),(\$?[A-Za-z_\d]+)"),
			new Instruction(0x55, 2, @"EOR\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x56, 2, @"LSR\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x57, 2, @"EOR\.b \[(\$?[A-Za-z_\d]+)\],Y"),
			new Instruction(0x58, 1, @"CLI"),
			new Instruction(0x59, 2, @"EOR\.w (\$?[A-Za-z_\d]+),Y"),
			new Instruction(0x5A, 1, @"PHY"),
			new Instruction(0x5B, 1, @"TCD"),
			new Instruction(0x5C, 4, @"JML\.l (\$?[A-Za-z_\d]+)"),
			new Instruction(0x5D, 3, @"EOR\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x5E, 3, @"LSR\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x5F, 4, @"EOR\.l (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x60, 1, @"RTS"),
			new Instruction(0x61, 2, @"ADC\.b \((\$?[A-Za-z_\d]+),X\)"),
			new Instruction(0x62, 3, @"PER (\$?[A-Za-z_\d]+)"),
			new Instruction(0x63, 2, @"ADC (\$?[A-Za-z_\d]+),S"),
			new Instruction(0x64, 2, @"STZ\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x65, 2, @"ADC\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x66, 2, @"ROR\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x67, 2, @"ADC\.b \[(\$?[A-Za-z_\d]+)\]"),
			new Instruction(0x68, 1, @"PLA"),
			new Instruction(0x69, 2, @"ADC\.b #(\$?[A-Za-z_\d]+)"),
			new Instruction(0x69, 3, @"ADC\.w #(\$?[A-Za-z_\d]+)"),
			new Instruction(0x6A, 1, @"ROR A"),
			new Instruction(0x6B, 1, @"RTL"),
			new Instruction(0x6C, 3, @"JMP\.w \((\$?[A-Za-z_\d]+)\)"),
			new Instruction(0x6D, 3, @"ADC\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x6E, 3, @"ROR\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x6F, 4, @"ADC\.l (\$?[A-Za-z_\d]+)"),
			new Instruction(0x70, 2, @"BVS (\$?[A-Za-z_\d]+)"),
			new Instruction(0x71, 2, @"ADC\.b \((\$?[A-Za-z_\d]+)\),Y"),
			new Instruction(0x72, 2, @"ADC\.b \((\$?[A-Za-z_\d]+)\)"),
			new Instruction(0x73, 2, @"ADC \((\$?[A-Za-z_\d]+),S\),Y"),
			new Instruction(0x74, 2, @"STZ\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x75, 2, @"ADC\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x76, 2, @"ROR\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x77, 2, @"ADC\.b \[(\$?[A-Za-z_\d]+)\],Y"),
			new Instruction(0x78, 1, @"SEI"),
			new Instruction(0x79, 2, @"ADC\.w (\$?[A-Za-z_\d]+),Y"),
			new Instruction(0x7A, 1, @"PLY"),
			new Instruction(0x7B, 1, @"TDC"),
			new Instruction(0x7C, 3, @"JMP\.w \((\$?[A-Za-z_\d]+),X\)"),
			new Instruction(0x7D, 3, @"ADC\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x7E, 3, @"ROR\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x7F, 4, @"ADC\.l (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x80, 2, @"BRA (\$?[A-Za-z_\d]+)"),
			new Instruction(0x81, 2, @"STA\.b \((\$?[A-Za-z_\d]+),X\)"),
			new Instruction(0x82, 3, @"BRL (\$?[A-Za-z_\d]+)"),
			new Instruction(0x83, 2, @"STA (\$?[A-Za-z_\d]+),S"),
			new Instruction(0x84, 2, @"STY\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x85, 2, @"STA\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x86, 2, @"STX\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0x87, 2, @"STA\.b \[(\$?[A-Za-z_\d]+)\]"),
			new Instruction(0x88, 1, @"DEY"),
			new Instruction(0x89, 2, @"BIT\.b #(\$?[A-Za-z_\d]+)"),
			new Instruction(0x89, 3, @"BIT\.w #(\$?[A-Za-z_\d]+)"),
			new Instruction(0x8A, 1, @"TXA"),
			new Instruction(0x8B, 1, @"PHB"),
			new Instruction(0x8C, 3, @"STY\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x8D, 3, @"STA\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x8E, 3, @"STX\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x8F, 4, @"STA\.l (\$?[A-Za-z_\d]+)"),
			new Instruction(0x90, 2, @"BCC (\$?[A-Za-z_\d]+)"),
			new Instruction(0x91, 2, @"STA\.b \((\$?[A-Za-z_\d]+)\),Y"),
			new Instruction(0x92, 2, @"STA\.b \((\$?[A-Za-z_\d]+)\)"),
			new Instruction(0x93, 2, @"STA \((\$?[A-Za-z_\d]+),S\),Y"),
			new Instruction(0x94, 2, @"STY\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x95, 2, @"STA\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x96, 2, @"STX\.b (\$?[A-Za-z_\d]+),Y"),
			new Instruction(0x97, 2, @"STA\.b \[(\$?[A-Za-z_\d]+)\],Y"),
			new Instruction(0x98, 1, @"TYA"),
			new Instruction(0x99, 3, @"STA\.w (\$?[A-Za-z_\d]+),Y"),
			new Instruction(0x9A, 1, @"TXS"),
			new Instruction(0x9B, 1, @"TXY"),
			new Instruction(0x9C, 3, @"STZ\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0x9D, 3, @"STA\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x9E, 3, @"STZ\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0x9F, 4, @"STA\.l (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xA0, 2, @"LDY\.b #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xA0, 3, @"LDY\.w #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xA1, 2, @"LDA\.b \((\$?[A-Za-z_\d]+),X\)"),
			new Instruction(0xA2, 2, @"LDX\.b #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xA2, 3, @"LDX\.w #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xA3, 2, @"LDA (\$?[A-Za-z_\d]+),S"),
			new Instruction(0xA4, 2, @"LDY\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0xA5, 2, @"LDA\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0xA6, 2, @"LDX\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0xA7, 2, @"LDA\.b \[(\$?[A-Za-z_\d]+)\]"),
			new Instruction(0xA8, 1, @"TAY"),
			new Instruction(0xA9, 2, @"LDA\.b #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xA9, 3, @"LDA\.w #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xAA, 1, @"TAX"),
			new Instruction(0xAB, 1, @"PLB"),
			new Instruction(0xAC, 3, @"LDY\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0xAD, 3, @"LDA\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0xAE, 3, @"LDX\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0xAF, 4, @"LDA\.l (\$?[A-Za-z_\d]+)"),
			new Instruction(0xB0, 2, @"BCS (\$?[A-Za-z_\d]+)"),
			new Instruction(0xB1, 2, @"LDA\.b \((\$?[A-Za-z_\d]+)\),Y"),
			new Instruction(0xB2, 2, @"LDA\.b \((\$?[A-Za-z_\d]+)\)"),
			new Instruction(0xB3, 2, @"LDA \(sp,S\),Y"),
			new Instruction(0xB4, 2, @"LDY\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xB5, 2, @"LDA\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xB6, 2, @"LDX\.b (\$?[A-Za-z_\d]+),Y"),
			new Instruction(0xB7, 2, @"LDA\.b \[(\$?[A-Za-z_\d]+)\],Y"),
			new Instruction(0xB8, 1, @"CLV"),
			new Instruction(0xB9, 3, @"LDA\.w (\$?[A-Za-z_\d]+),Y"),
			new Instruction(0xBA, 1, @"TSX"),
			new Instruction(0xBB, 1, @"TYX"),
			new Instruction(0xBC, 3, @"LDY\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xBD, 3, @"LDA\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xBE, 3, @"LDX\.w (\$?[A-Za-z_\d]+),Y"),
			new Instruction(0xBF, 4, @"LDA\.l (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xC0, 2, @"CPY\.b #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xC0, 3, @"CPY\.w #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xC1, 2, @"CMP\.b \((\$?[A-Za-z_\d]+),X\)"),
			new Instruction(0xC2, 2, @"REP #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xC3, 2, @"CMP (\$?[A-Za-z_\d]+),S"),
			new Instruction(0xC4, 2, @"CPY\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0xC5, 2, @"CMP\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0xC6, 2, @"DEC\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0xC7, 2, @"CMP\.b \[(\$?[A-Za-z_\d]+)\]"),
			new Instruction(0xC8, 1, @"INY"),
			new Instruction(0xC9, 2, @"CMP\.b #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xC9, 3, @"CMP\.w #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xCA, 1, @"DEX"),
			new Instruction(0xCB, 1, @"WAI"),
			new Instruction(0xCC, 3, @"CPY\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0xCD, 3, @"CMP\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0xCE, 3, @"DEC\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0xCF, 4, @"CMP\.l (\$?[A-Za-z_\d]+)"),
			new Instruction(0xD0, 2, @"BNE (\$?[A-Za-z_\d]+)"),
			new Instruction(0xD1, 2, @"CMP\.b \((\$?[A-Za-z_\d]+)\),Y"),
			new Instruction(0xD2, 2, @"CMP\.b \((\$?[A-Za-z_\d]+)\)"),
			new Instruction(0xD3, 2, @"CMP \((\$?[A-Za-z_\d]+),S\),Y"),
			new Instruction(0xD4, 2, @"PEI\.b \((\$?[A-Za-z_\d]+)\)"),
			new Instruction(0xD5, 2, @"CMP\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xD6, 2, @"DEC\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xD7, 2, @"CMP\.b \[(\$?[A-Za-z_\d]+)\],Y"),
			new Instruction(0xD8, 1, @"CLD"),
			new Instruction(0xD9, 3, @"CMP\.w (\$?[A-Za-z_\d]+),Y"),
			new Instruction(0xDA, 1, @"PHX"),
			new Instruction(0xDB, 1, @"STP"),
			new Instruction(0xDC, 3, @"JML\.w \[(\$?[A-Za-z_\d]+)\]"),
			new Instruction(0xDD, 3, @"CMP\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xDE, 3, @"DEC\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xDF, 4, @"CMP\.l (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xE0, 2, @"CPX\.b #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xE0, 3, @"CPX\.w #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xE1, 2, @"SBC\.b \((\$?[A-Za-z_\d]+),X\)"),
			new Instruction(0xE2, 2, @"SEP #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xE3, 2, @"SBC (\$?[A-Za-z_\d]+),S"),
			new Instruction(0xE4, 2, @"CPX\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0xE5, 2, @"SBC\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0xE6, 2, @"INC\.b (\$?[A-Za-z_\d]+)"),
			new Instruction(0xE7, 2, @"SBC\.b \[(\$?[A-Za-z_\d]+)\]"),
			new Instruction(0xE8, 1, @"INX"),
			new Instruction(0xE9, 2, @"SBC\.b #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xE9, 3, @"SBC\.w #(\$?[A-Za-z_\d]+)"),
			new Instruction(0xEA, 1, @"NOP"),
			new Instruction(0xEB, 1, @"XBA"),
			new Instruction(0xEC, 3, @"CPX\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0xED, 3, @"SBC\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0xEE, 3, @"INC\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0xEF, 4, @"SBC\.l (\$?[A-Za-z_\d]+)"),
			new Instruction(0xF0, 2, @"BEQ (\$?[A-Za-z_\d]+)"),
			new Instruction(0xF1, 2, @"SBC\.b \((\$?[A-Za-z_\d]+)\),Y"),
			new Instruction(0xF2, 2, @"SBC\.b \((\$?[A-Za-z_\d]+)\)"),
			new Instruction(0xF3, 2, @"SBC \((\$?[A-Za-z_\d]+),S\),Y"),
			new Instruction(0xF4, 2, @"PEA\.w (\$?[A-Za-z_\d]+)"),
			new Instruction(0xF5, 2, @"SBC\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xF6, 2, @"INC\.b (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xF7, 2, @"SBC\.b \[(\$?[A-Za-z_\d]+)\],Y"),
			new Instruction(0xF8, 1, @"SED"),
			new Instruction(0xF9, 2, @"SBC\.w (\$?[A-Za-z_\d]+),Y"),
			new Instruction(0xFA, 1, @"PLX"),
			new Instruction(0xFB, 1, @"XCE"),
			new Instruction(0xFC, 3, @"JSR\.w \((\$?[A-Za-z_\d]+),X\)"),
			new Instruction(0xFD, 3, @"SBC\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xFE, 3, @"INC\.w (\$?[A-Za-z_\d]+),X"),
			new Instruction(0xFF, 4, @"SBC\.l (\$?[A-Za-z_\d]+),X"),
		};
	}
}
