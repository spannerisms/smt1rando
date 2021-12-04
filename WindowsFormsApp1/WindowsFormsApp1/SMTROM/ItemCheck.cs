namespace SMTRandoApp.SMTROM;

internal record ItemCheck(string Name, byte ItemID, byte MessageID) : ITextCommand {
	public byte[] Data => new byte[] { 0xDD, ItemID, MessageID };
}