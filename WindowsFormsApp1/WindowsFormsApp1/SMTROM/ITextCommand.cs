namespace SMTRandoApp.SMTROM;

internal interface ITextCommand {
	public string Name { get; }
	public byte[] Data { get; }
}
