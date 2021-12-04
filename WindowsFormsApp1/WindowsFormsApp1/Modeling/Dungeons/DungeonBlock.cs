namespace SMTRandoApp.Modeling.Dungeons;

internal class DungeonBlock {

	private readonly DungeonRoom Room00;
	private readonly DungeonRoom Room01;
	private readonly DungeonRoom Room02;
	private readonly DungeonRoom Room03;
	private readonly DungeonRoom Room10;
	private readonly DungeonRoom Room11;
	private readonly DungeonRoom Room12;
	private readonly DungeonRoom Room13;
	private readonly DungeonRoom Room20;
	private readonly DungeonRoom Room21;
	private readonly DungeonRoom Room22;
	private readonly DungeonRoom Room23;
	private readonly DungeonRoom Room30;
	private readonly DungeonRoom Room31;
	private readonly DungeonRoom Room32;
	private readonly DungeonRoom Room33;

	public DungeonRoom this[int x, int y] => (x, y) switch {
		(0, 0) => Room00,
		(1, 0) => Room01,
		(2, 0) => Room02,
		(3, 0) => Room03,
		(0, 1) => Room10,
		(1, 1) => Room11,
		(2, 1) => Room12,
		(3, 1) => Room13,
		(0, 2) => Room20,
		(1, 2) => Room21,
		(2, 2) => Room22,
		(3, 2) => Room23,
		(0, 3) => Room30,
		(1, 3) => Room31,
		(2, 3) => Room32,
		(3, 3) => Room33,
		_ => throw new IndexOutOfRangeException()
	};

	public byte DungeonID { get; set; }
	public byte HiddenID { get; set; }

	public sbyte Floor { get; set; } = 1;

	public byte X { get; }
	public byte Y { get; }

	public int IDOffset { get; }

	public DungeonBlock(byte x, byte y) {
		X = (byte) (x << 2);
		Y = (byte) (y << 2);
		IDOffset = MapArtist.GetDungeonBlockOfRoom(X, Y);

		Room00 = new((byte) (X + 0), (byte) (Y + 0));
		Room01 = new((byte) (X + 1), (byte) (Y + 0));
		Room02 = new((byte) (X + 2), (byte) (Y + 0));
		Room03 = new((byte) (X + 3), (byte) (Y + 0));

		Room10 = new((byte) (X + 0), (byte) (Y + 1));
		Room11 = new((byte) (X + 1), (byte) (Y + 1));
		Room12 = new((byte) (X + 2), (byte) (Y + 1));
		Room13 = new((byte) (X + 3), (byte) (Y + 1));

		Room20 = new((byte) (X + 0), (byte) (Y + 2));
		Room21 = new((byte) (X + 1), (byte) (Y + 2));
		Room22 = new((byte) (X + 2), (byte) (Y + 2));
		Room23 = new((byte) (X + 3), (byte) (Y + 2));

		Room30 = new((byte) (X + 0), (byte) (Y + 3));
		Room31 = new((byte) (X + 1), (byte) (Y + 3));
		Room32 = new((byte) (X + 2), (byte) (Y + 3));
		Room33 = new((byte) (X + 3), (byte) (Y + 3));
	}

	public void ForEachRoom(Action<DungeonRoom> act) {
		act(Room00);
		act(Room01);
		act(Room02);
		act(Room03);
		act(Room10);
		act(Room11);
		act(Room12);
		act(Room13);
		act(Room20);
		act(Room21);
		act(Room22);
		act(Room23);
		act(Room30);
		act(Room31);
		act(Room32);
		act(Room33);
	}
}
