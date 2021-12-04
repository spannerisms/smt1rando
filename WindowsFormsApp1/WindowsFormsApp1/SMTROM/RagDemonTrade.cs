namespace SMTRandoApp.SMTROM;
internal record RagDemonTrade(string Name, byte Item1, byte Item2, byte Item3, byte DemonID) : ITextCommand {
	public byte[] Data => new byte[] {
		0xE1, Item1, 0xF3, // item name
		0xCF, 0x98, 0xCF, // " / "
		0xE1, Item2, 0xF3, // item 2 name
		0xCF, 0x98, 0xF9, // " /\n"
		0xE1, Item3, 0xF3, // item 3 name
		0xCF, 0x5A, 0x97, 0xCF, // " -> "
		0xDE, 0x00, 0x00, DemonID, 0x01, // set demon
		0xF5 // write demon name
	};
}