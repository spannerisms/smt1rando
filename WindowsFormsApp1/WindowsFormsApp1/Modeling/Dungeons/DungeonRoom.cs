namespace SMTRandoApp.Modeling.Dungeons;
internal class DungeonRoom {

	public DungeonWall NorthWall { get; set; }
	public DungeonWall SouthWall { get; set; }
	public DungeonWall EastWall { get; set; }
	public DungeonWall WestWall { get; set; }

	public bool IsDark { get; set; }

	public byte? ChestItem { get; set; } = null;
	public bool HasChest => ChestItem is not null;

	public byte Event { get; set; }
	public byte X { get; }
	public byte Y { get; }

	public ushort? NPCMessage { get; set; } = null;

	public NPCType TalkType => NPCMessage switch {
		null => NPCType.None,
		0x02DC or 0xC052 or 0x02F1 or 0x4052 or 0x402B => NPCType.Steven,
		0x032E or 0x032F or 0x8062 or 0x032B or 0x032A or 0x0330 or 0x0332 or 0x032C or 0x0329 or 0x0331 or 0x0333 or 0x032D or 0x0334 or 0x0328 => NPCType.Terminal,
		0x8063 => NPCType.Mesia,
		0x806A => NPCType.Gaia,
		0x8035 or 0x8051 or 0x8055 or 0x8056 or 0x8054 or 0x8053 or 0x804F or 0x8050 or 0x8052 => NPCType.JunksShop,
		0x8039 or 0x803D or 0x803C or 0x803A or 0x803B => NPCType.Bar,
		0x8034 => NPCType.Drugs,
		0x8036 => NPCType.WeaponsShop,
		0x8043 or 0x8040 or 0x8045 or 0x8044 or 0x8042 or 0x803F or 0x8037 or 0x8041 or 0x407F => NPCType.GunsShop,
		0x4078 => NPCType.Jakyou,
		0x8070 => NPCType.Kaifuku,
		0x4051 => NPCType.Rags,
		0x8049 or 0x804B or 0x806A or 0x806A or 0x806A or 0x804A or 0x8033 or 0x806A or 0x804D or 0x8048 or 0x804C or 0x8047 or 0x806A => NPCType.ArmorShop,
		_ => NPCType.Boring
	};

	public ushort? Destination { get; set; } = null;

	public bool Reachable { get; set; } = false; // TODO

	public int DataOffset { get; }

	public DungeonRoom(byte x, byte y) {
		X = x;
		Y = y;
		DataOffset = MapArtist.GetRoomOffsetIntoData(X, Y);
	}
}
