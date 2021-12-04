namespace SMTRandoApp.Randomization;

internal delegate void ShuffleFunction(ROMWriter r);

internal class ShuffleOption {
	public string Name { get; init; }

	public ShuffleFunction RunShuffle { get; init; }

	public ShuffleOption(string name, ShuffleFunction del = null) {
		Name = name;
		RunShuffle = del ?? delegate { };
	}

	override public string ToString() => Name;
}