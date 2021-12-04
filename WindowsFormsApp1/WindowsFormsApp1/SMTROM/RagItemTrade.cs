namespace SMTRandoApp.SMTROM;

internal record RagItemTrade(string Name, byte Item1, byte Item2) : ITextCommand {
	public byte[] Data => new byte[] {
		0xE1, Item1, 0xF3, // item 1 name
		0xCF, 0x5A, 0x97, 0xCF, // " -> "
		0xE1, Item2, 0xF3 // item 2 name
	};
}
