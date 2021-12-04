namespace SMTRandoApp.SMTROM;

internal record ScriptedFight : ITextCommand {
	public string Name { get; }
	public byte[] Data { get; }
	public byte Count { get; }
	public int DemonID { get; }
	public byte MaxLevel { get; }
	public byte MinLevel { get; }
	public bool IsReallyFightable => (MaxLevel | MinLevel) != 0x00;

	public ScriptedFight(string name, byte slot, byte count, int demon, byte min = 0, byte max = 0) {
		Name = name;
		//Slot = slot;
		Count = count;
		DemonID = demon;
		MaxLevel = max;
		MinLevel = min;
		Data = new byte[] {
			(byte) (slot == 0 ? 0xDE : 0xEB),
			(byte) (DemonID >> 8),
			0x00,
			(byte) DemonID,
			Count
		};
	}
}