namespace SMTRandoApp.Modeling;

internal class UselessJerk : Personality {
	public UselessJerk() : base(0xFF, "がったいふのう", "NO FUSE", Gender.None) { }

	public override Personality Clone() => new UselessJerk();
}
