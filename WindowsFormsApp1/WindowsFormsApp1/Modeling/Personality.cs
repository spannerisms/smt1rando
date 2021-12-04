namespace SMTRandoApp.Modeling;

internal abstract partial class Personality {
	public int ID { get; init; }
	public bool BeenUsed { get; init; }
	public string Name { get; set; }
	public string JapaneseName { get; init; }
	public string EnglishName { get; init; }
	public Gender Gender { get; init; }

	protected Personality() { }

	protected Personality(int id, string jname, string ename, Gender g) {
		ID = id;
		Gender = g;
		JapaneseName = jname;
		EnglishName = ename;
		Name = ename;
	}

	public abstract Personality Clone();

	public static Personality[] GetFreshList() => VanillaList.Select(p => p.Clone()).ToArray();
}
