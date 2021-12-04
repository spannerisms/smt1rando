namespace SMTRandoApp.Modeling;
internal class FancyNPC : Personality {
	private FancyNPC(FancyNPC copy) {
		var properties = GetType().GetProperties();
		foreach (var p in properties) {
			p.SetValue(this, p.GetValue(copy));
		}
	}

	internal FancyNPC(int id, string japaneseName, string englishName, Gender gender) : base(id, japaneseName, englishName, gender) { }

	public override Personality Clone() => new FancyNPC(this);
}
