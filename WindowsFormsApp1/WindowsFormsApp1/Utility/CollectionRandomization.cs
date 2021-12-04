namespace SMTRandoApp.Utility;

internal delegate T[] ListShuffleFunc<T>(T[] list);
internal static class CollectionRandomization {
	public static T[] ToShuffledArray<T>(this ICollection<T> a) {
		return a.ToShuffledArray(a.Count);
	}

	public static T[] ToShuffledArray<T>(this ICollection<T> a, int count) {
		if (count > a.Count) {
			throw new IndexOutOfRangeException("Requested shuffle size is larger than the size of the given array.");
		}

		T[] ret = new T[a.Count];
		var s = a.ToList();

		for (int i = 0; i < ret.Length; i++) {
			int r = GetRandomInt(0, s.Count - 1);
			ret[i] = s[r];
			s.RemoveAt(r);
		}

		return ret;
	}

	public static T[] ToRandomizedArray<T>(this T[] a) {
		return a.ToRandomizedArray(a.Length);
	}

	public static T[] ToRandomizedArray<T>(this T[] a, int count) {
		T[] ret = new T[a.Length];

		for (int i = 0; i < count; i++) {
			ret[i] = a.GetRandomElement();
		}

		return ret;
	}

	public static T GetRandomElement<T>(this ICollection<T> a) {
		return a.ElementAt(GetRandomInt(0, a.Count - 1));
	}
}
