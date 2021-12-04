namespace SMTRandoApp.Randomization;

internal static class SoundShuffler {
	private const ushort NOSONG = 0x0E2C;
	private const ushort GINZA = 0x81BC;
	private const int PackagePointers = 0x0C814C;
	private const int SongCount = 20;

	private const int SFXSET1SIZE = 35;
	private const int SFXSET2SIZE = 12;

	// SFX Rando
	public static readonly ShuffleOption[] SFXShuffles = {
		new("Vanilla", null),

		new("Shuffled", r => ShuffleSFX(r, CollectionRandomization.ToShuffledArray)),

		new("Random", r => ShuffleSFX(r, CollectionRandomization.ToRandomizedArray)),
	};

	private static void ShuffleSFX(ROMWriter r, ListShuffleFunc<ushort> mixer) {
		var sfx = r.Read16(0x0CBF76, SFXSET1SIZE).Concat(r.Read16(0x0CBFC8, SFXSET2SIZE)).ToArray();

		var newList = mixer(sfx);

		r.Write16(0x0CBF76, newList[..SFXSET1SIZE]);
		r.Write16(0x0CBFC8, newList[^SFXSET2SIZE..]);
	}

	// Music rando
	public static readonly ShuffleOption[] MusicShuffles = {
		new("Vanilla", null),

		new("Shuffled", r => {
			var songs = r.Read16(PackagePointers, SongCount);
			r.Write16(0x0CBFF4, NOSONG); // Jakyou weirdness
			r.Write16(PackagePointers, songs.ToShuffledArray());
		}),

		new("Random", r => {
			var songs = r.Read16(PackagePointers, SongCount);
			r.Write16(0x0CBFF4, NOSONG); // Jakyou weirdness
			r.Write16(PackagePointers, songs.ToRandomizedArray());
		}),

		// Ginza everywhere
		new("Ginza", r => {
			r.Write16(0x0CBFF4, 0x7800);

			var songs = new ushort[SongCount];
			Array.Fill(songs, GINZA);

			r.Write16(PackagePointers, songs);
		}),
	};
}

