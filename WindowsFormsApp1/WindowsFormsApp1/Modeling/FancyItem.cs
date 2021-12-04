namespace SMTRandoApp.Modeling;

internal class FancyItem : Personality {
	/// <summary>
	/// The item this shares a name with
	/// </summary>
	public byte SharedName { get; init; } = 0xFF;

	private FancyItem(FancyItem copy) {
		var properties = GetType().GetProperties();
		foreach (var p in properties) {
			p.SetValue(this, p.GetValue(copy));
		}
	}

	internal FancyItem(int id, string japaneseName, string englishName, byte sharedName)
		: base(id, japaneseName, englishName, Gender.None) {
		SharedName = sharedName;
	}

	public override Personality Clone() => new FancyItem(this);
}