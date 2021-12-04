namespace SMTRandoApp.Randomization;

internal delegate string[] TranslateFunction(ROMWriter r);

internal class TranslateOption {
	public string Name { get; init; }

	public TranslateFunction RunTranslation { get; init; }

	public TranslateOption(string name, TranslateFunction del) {
		Name = name;
		RunTranslation = del;
	}

	override public string ToString() => Name;
}
