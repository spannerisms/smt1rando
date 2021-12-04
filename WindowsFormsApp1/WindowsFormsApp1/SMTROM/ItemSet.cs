namespace SMTRandoApp.SMTROM;

internal record ItemSet(string Name, byte ItemID) : ITextCommand {
	public byte[] Data => new byte[] { 0xE1, ItemID };
}