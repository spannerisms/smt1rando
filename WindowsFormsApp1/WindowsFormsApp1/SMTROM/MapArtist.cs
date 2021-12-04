namespace SMTRandoApp.SMTROM;

#pragma warning disable CA1416 // Validate platform compatibility
internal class MapArtist {
	private const int DungeonSizeX = 32;
	private const int DungeonSizeY = 16;

	private const int RoomSize = 8;
	private const int RoomDrawSize = RoomSize - 1;
	private const int RoomDimension = RoomSize;
	private const int ImageDimensionX = RoomDimension * DungeonSizeX * 4;
	private const int ImageDimensionY = RoomDimension * DungeonSizeY * 4;

	private const int BlockDimension = RoomDimension * 4;

	private static readonly Image Chest = Properties.Resources.chest;
	private static readonly Image DarkRoom = Properties.Resources.darkroom;
	private static readonly Image StairsDown = Properties.Resources.stairsdown;
	private static readonly Image ExitIcon = Properties.Resources.exit;
	private static readonly Image StairsUp = Properties.Resources.stairsup;
	private static readonly Image NPCSquare = Properties.Resources.npc;
	private static readonly Image Elevator = Properties.Resources.elevator;
	private static readonly Image Trap = Properties.Resources.trap;
	private static readonly Image FreeHole = Properties.Resources.freehole;
	private static readonly Image Warp = Properties.Resources.warp;
	private static readonly Image Armor = Properties.Resources.armor;
	private static readonly Image Bar = Properties.Resources.bar;
	private static readonly Image Drugs = Properties.Resources.drugs;
	private static readonly Image Gaia = Properties.Resources.gaia;
	private static readonly Image Guns = Properties.Resources.guns;
	private static readonly Image Jakyou = Properties.Resources.jakyou;
	private static readonly Image Junk = Properties.Resources.junk;
	private static readonly Image Kaifuku = Properties.Resources.kaifuku;
	private static readonly Image Mesia = Properties.Resources.mesia;
	private static readonly Image Rags = Properties.Resources.rags;
	private static readonly Image Steven = Properties.Resources.steven;
	private static readonly Image Terminal = Properties.Resources.terminal;
	private static readonly Image Weapons = Properties.Resources.weapons;

	private readonly DungeonBlock[,] blocks = new DungeonBlock[DungeonSizeX,DungeonSizeY];

	public MapArtist() {
		for (byte y = 0; y < DungeonSizeY; y++) {
			for (byte x = 0; x < DungeonSizeX; x++) {
				blocks[x,y] = new(x, y);
			}
		}
	}

	static MapArtist() {
		const int colorCount = 64;

		DungeonColors = new Pen[colorCount];

		int r = 24;
		int g = 24;
		int b = 24;

		for (int i = 0; i < colorCount; i++) {
			DungeonColors[i] = new Pen(Color.FromArgb(r, g, b));

			if ((r += 16) >= 256) {
				r = 24;
				if ((b += 24) >= 256) {
					b = 24;
				}
				if ((g += 36) >= 256) {
					g = 24;
				}
			}
		}
	}

	public DungeonRoom GetRoomAt(int x, int y) {
		byte xx = (byte) (x & 0x03);
		byte yy = (byte) (y & 0x03);
		return blocks[x/4,y/4][xx, yy];
	}

	private class MapProps {
		public Bitmap Image { get; } = new Bitmap(ImageDimensionX, ImageDimensionY);
		public int MinX { get; set; } = 999999;
		public int MaxX { get; set; } = -999999;
		public int MinY { get; set; } = 999999;
		public int MaxY { get; set; } = -999999;
	}

	public void DrawMap() {
		using var imgout = new Bitmap(ImageDimensionX, ImageDimensionY);
		using var g2 = Graphics.FromImage(imgout);

		g2.Clear(MapBackground);

		var cols = new Dictionary<byte, Pen>();

		var imgs = new Dictionary<byte, MapProps>();

		// Background grid
		for (int i = 0; i < ImageDimensionX; i += RoomDimension) {
			g2.DrawLine(MapBackGridPen, i, 0, i, ImageDimensionY);
		}

		for (int i = 0; i < ImageDimensionY; i += RoomDimension) {
			g2.DrawLine(MapBackGridPen, 0, i, ImageDimensionX, i);
		}

		foreach (var b in blocks) {

			Graphics g1;
			MapProps dungeonImage;
			if (imgs.ContainsKey(b.DungeonID)) {
				dungeonImage = imgs[b.DungeonID];
			} else {
				dungeonImage = imgs[b.DungeonID] = new();
				//Debug.Print($"{{ 0x{b.DungeonID:X4}, \"\" }},");
				//g1.Clear(MapBackground);
				//for (int i = 0; i < ImageDimensionX; i += RoomDimension) {
				//	g1.DrawLine(MapBackGridPen, i, 0, i, ImageDimensionY);
				//}

				//for (int i = 0; i < ImageDimensionX; i += RoomDimension) {
				//	g1.DrawLine(MapBackGridPen, 0, i, ImageDimensionX, i);
				//}
			}

			g1 = Graphics.FromImage(dungeonImage.Image);

			Graphics g = g1;

			b.ForEachRoom(room => {
				if (!room.Reachable) return;

				int xx = room.X * RoomDimension;
				int yy = room.Y * RoomDimension;
				int xx2 = xx + RoomDrawSize;
				int yy2 = yy + RoomDrawSize;

				g.FillRectangle(room.Reachable ? MapForegroundBrush : Brushes.Red, xx, yy, RoomSize, RoomSize);

				if (room.IsDark) {
					g.DrawImage(DarkRoom, xx, yy);
				}

				g.DrawRectangle(MapForeGridPen, xx, yy, RoomDrawSize, RoomDrawSize);


				switch (room.NorthWall) {
					case DungeonWall.NoWall:
						break;

					case DungeonWall.Wall:
						g.DrawLine(WallColorPen, xx, yy, xx2, yy);
						break;

					case DungeonWall.FakeWall:
						g.DrawLine(FakeWallColorPen, xx, yy, xx2, yy);
						break;

					case DungeonWall.Door:
						g.DrawLine(WallColorPen, xx, yy, xx + 2, yy);
						g.DrawLine(WallColorPen, xx2 - 2, yy, xx2, yy);
						break;
				}

				switch (room.SouthWall) {
					case DungeonWall.NoWall:
						break;

					case DungeonWall.Wall:
						g.DrawLine(WallColorPen, xx, yy2, xx2, yy2);
						break;

					case DungeonWall.FakeWall:
						g.DrawLine(FakeWallColorPen, xx, yy2, xx2, yy2);
						break;

					case DungeonWall.Door:
						g.DrawLine(WallColorPen, xx, yy2, xx + 2, yy2);
						g.DrawLine(WallColorPen, xx2 - 2, yy2, xx2, yy2);
						break;
				}


				switch (room.WestWall) {
					case DungeonWall.NoWall:
						break;

					case DungeonWall.Wall:
						g.DrawLine(WallColorPen, xx, yy, xx, yy2);
						break;

					case DungeonWall.FakeWall:
						g.DrawLine(FakeWallColorPen, xx, yy, xx, yy2);
						break;

					case DungeonWall.Door:
						g.DrawLine(WallColorPen, xx, yy, xx, yy + 2);
						g.DrawLine(WallColorPen, xx, yy2 - 2, xx, yy2);
						break;
				}
				


				switch (room.EastWall) {
					case DungeonWall.NoWall:
						break;

					case DungeonWall.Wall:
						g.DrawLine(WallColorPen, xx2, yy, xx2, yy2);
						break;

					case DungeonWall.FakeWall:
						g.DrawLine(FakeWallColorPen, xx2, yy, xx2, yy2);
						break;

					case DungeonWall.Door:
						g.DrawLine(WallColorPen, xx2, yy, xx2, yy + 2);
						g.DrawLine(WallColorPen, xx2, yy2 - 2, xx2, yy2);
						break;
				}


				Image eventImage = room.Event switch {
					0x02 or 0x03 or 0x04 => Trap,
					0x05 => FreeHole,
					0x06 => Warp,
					0x07 => ExitIcon,
					0x08 => StairsUp,
					0x09 => StairsDown,
					//0x0B => NPCSquare,
					0x0C => Elevator,
					_ => null,
				};

				if (eventImage is not null) {
					g.DrawImage(eventImage, xx, yy);
				}

				if (room.TalkType is not NPCType.None) {
					var nnn = room.TalkType switch {
						//NPCType. => Chest,
						NPCType.ArmorShop => Armor,
						NPCType.Bar => Bar,
						NPCType.Drugs => Drugs,
						NPCType.Gaia => Gaia,
						NPCType.GunsShop => Guns,
						NPCType.Jakyou => Jakyou,
						NPCType.JunksShop => Junk,
						NPCType.Kaifuku => Kaifuku,
						NPCType.Mesia => Mesia,
						NPCType.Rags => Rags,
						NPCType.Steven => Steven,
						NPCType.Terminal => Terminal,
						NPCType.WeaponsShop => Weapons,
						_ => NPCSquare,
					};


					g.DrawImage(nnn, xx, yy);
				}

				if (room.HasChest) {
					g.DrawImage(Chest, xx, yy);
				}

			});
			// end of rooms draw

			int xl = b.X * RoomDimension;
			int xh = xl + BlockDimension;
			int yl = b.Y * RoomDimension;
			int yh = yl + BlockDimension;

			if (xl < dungeonImage.MinX) dungeonImage.MinX = xl;
			if (xh > dungeonImage.MaxX) dungeonImage.MaxX = xh;
			if (yl < dungeonImage.MinY) dungeonImage.MinY = yl;
			if (yh > dungeonImage.MaxY) dungeonImage.MaxY = yh;


			g.Flush();
			g.Dispose();
		}

		string folder = Properties.Settings.Default.OutputDirectory + @"\smt1maps\";
		// end of drawing
		//using var wr = new FileStream(test, FileMode.Create, FileAccess.Write);

		foreach (var (id, mm) in imgs) {

			g2.DrawImage(mm.Image, 0, 0);

			int w = mm.MaxX - mm.MinX;
			int h = mm.MaxY - mm.MinY;

			var pic = new Bitmap(w, h);
			var g3 = Graphics.FromImage(pic);

			g3.Clear(MapBackground);

			// Background grid
			for (int i = 0; i < w; i += RoomDimension) {
				g3.DrawLine(MapBackGridPen, i, 0, i, ImageDimensionY);
			}

			for (int i = 0; i < h; i += RoomDimension) {
				g3.DrawLine(MapBackGridPen, 0, i, ImageDimensionX, i);
			}

			g3.DrawImage(mm.Image, -mm.MinX, -mm.MinY);

			g3.Flush();

			pic.Save($"{folder}{id:X2}.png");
			g3.Dispose();

		}

		g2.Flush();
		imgout.Save($"{folder}_full.png");
		//wr.Close();
	}





	public static MapArtist ReadMapFromROM(ROMWriter rom) {
		var ret = new MapArtist();

		var reachableRooms = new List<DungeonRoom>();
		foreach (var b in ret.blocks) {
			b.ForEachRoom(room => {
				Address a = DungeonRoomData + room.DataOffset;
				var b = a.Version1Address;

				byte walls = rom[a++];
				byte evts = rom[a];

				room.NorthWall = (DungeonWall) ((walls & 0xC0) >> 6);
				room.EastWall = (DungeonWall) ((walls & 0x30) >> 4);
				room.SouthWall = (DungeonWall) ((walls & 0x0C) >> 2);
				room.WestWall = (DungeonWall) ((walls & 0x03) >> 0);

				room.IsDark = evts.BitIsOn(7);

				room.Event = (byte) (evts & 0x0F);

				if (room.Event is 0x02 or 0x03 or 0x04 or 0x05 or 0x06 or 0x07 or
					0x08 or 0x09 or 0x0B or 0x0C) {
					reachableRooms.Add(room);
				}

				//Debug.Print($"#_{b:X6}: db ${walls:X2}, ${evts:X2} ; Room at ({room.X:X2}, {room.Y:X2})");
			});

			Address ab = DungeonIDData + b.IDOffset;
			byte id1 = rom[ab++];
			byte flr = rom[ab++];
			b.DungeonID = (byte) (id1 & 0x3F);
			b.HiddenID = (byte) ((id1 & 0xC0) >> 6);
			int fl = (flr & 0x7F) + 1;
			if (flr.BitIsOn(7)) {
				fl *= -1;
			}
			b.Floor = (sbyte) fl;
		}

		var a = NPCLocations;
		while (rom[a] != 0xFF) {
			byte x = rom[a++];
			byte y = rom[a++];
			ushort m = rom.Read16(a);
			var r = ret.GetRoomAt(x, y);
			r.NPCMessage = m;
			a += 2;
		}

		a = ChestLocations;
		while (rom[a] != 0xFF) {

			byte x = rom[a++];
			byte y = (byte) (rom[a++] & 0x3F);
			byte t = rom[a++];
			byte c = rom[a++];
			var r = ret.GetRoomAt(x, y);

			r.ChestItem = c;
		}

		a = FreeHoles;
		while (rom[a] != 0xFF) {

			byte x = rom[a++];
			byte y = (byte) (rom[a++] & 0x3F);
			var r = ret.GetRoomAt(x, y);
			r.Destination = rom.Read16(a);
			a += 4;
		}

		a = WarpHoles;
		while (rom[a] != 0xFF) {
			byte x = rom[a++];
			byte y = (byte) (rom[a++] & 0x3F);
			var r = ret.GetRoomAt(x, y);
			r.Destination = rom.Read16(a);
			a += 4;
		}

		ret.DetermineReachability();

		return ret;
	}

	private void DetermineReachability() {
		var reachableRooms = new List<DungeonRoom>();
		foreach (var b in blocks) {
			b.ForEachRoom(room => {
				if ((room.Event is 0x02 or 0x03 or 0x04 or 0x05 or 0x06 or 0x07 or
					0x08 or 0x09 or 0x0B or 0x0C) || room.NPCMessage is not null || room.HasChest) {
					reachableRooms.Add(room);
				}

				if (room.Destination is ushort d) {
					byte x = (byte) d;
					byte y = (byte) ((d >> 8) & 0x3F);
					reachableRooms.Add(GetRoomAt(x, y));
				}
			});
		}

		foreach (var r in reachableRooms) {
			FindAllRooms(r.X, r.Y);

			void FindAllRooms(int xxx, int yyy) {
				if ((xxx is < 0 or >= (DungeonSizeX * 4)) || (yyy is < 0 or >= (DungeonSizeY * 4))) {
					return;
				}

				var curroom = GetRoomAt(xxx, yyy);
				if (curroom.Reachable) return;
				curroom.Reachable = true;

				if (curroom.NorthWall is not DungeonWall.Wall) FindAllRooms(xxx, yyy - 1);
				if (curroom.SouthWall is not DungeonWall.Wall) FindAllRooms(xxx, yyy + 1);
				if (curroom.EastWall is not DungeonWall.Wall) FindAllRooms(xxx + 1, yyy);
				if (curroom.WestWall is not DungeonWall.Wall) FindAllRooms(xxx - 1, yyy);
			}
		}
	}

	public static int GetRoomOffsetIntoData(int x, int y) {
		return (((x & 0x7F) << 1) | ((y & 0x3F) << 8)) & 0x3FFE;
	}

	public static (int block, byte x, byte y) GetDungeonBlockAndPositionOfRoom(int x, int y) {
		var b = GetDungeonBlockOfRoom(x, y);
		var (xx, yy) = GetInteriorPositionOfRoom(x, y);
		return (b, xx, yy);
	}

	public static (byte x, byte y) GetInteriorPositionOfRoom(int x, int y) {
		return ((byte) (x & 0x03), (byte) (y & 0x03));
	}

	public static int GetDungeonBlockOfRoom(int x, int y) {
		return ((x >> 1) & 0x3E) | ((y << 4) & 0x03C0);
	}

	private static readonly Color MapBackground = Color.FromArgb(0x00, 0x00, 0x00);
	private static readonly Pen MapBackgroundPen = new(MapBackground);
	private static readonly SolidBrush MapBackgroundBrush = new(MapBackground);
	private static readonly Color MapBackGrid = Color.FromArgb(0x00, 0x63, 0x00);
	private static readonly Pen MapBackGridPen = new(MapBackGrid);
	private static readonly SolidBrush MapBackGridBrush = new(MapBackGrid);
	private static readonly Color MapForeground = Color.FromArgb(0x00, 0x42, 0x42);
	private static readonly Pen MapForegroundPen = new(MapForeground);
	private static readonly SolidBrush MapForegroundBrush = new(MapForeground);
	private static readonly Color MapForeGrid = Color.FromArgb(0x00, 0x63, 0x63);
	private static readonly Pen MapForeGridPen = new(MapForeGrid);
	private static readonly SolidBrush MapForeGridBrush = new(MapForeGrid);
	private static readonly Color WallColor = Color.FromArgb(0x42, 0xC6, 0xA5);
	private static readonly Pen WallColorPen = new(WallColor);
	private static readonly SolidBrush WallColorBrush = new(WallColor);
	private static readonly Color FakeWallColor = Color.FromArgb(0x9B, 0xD0, 0x9B);
	private static readonly Pen FakeWallColorPen = new(FakeWallColor);
	private static readonly SolidBrush FakeWallColorBrush = new(FakeWallColor);
	private static readonly Color ExitColor = Color.FromArgb(0xE7, 0x00, 0x00);
	private static readonly Pen ExitColorPen = new(ExitColor);
	private static readonly SolidBrush ExitColorBrush = new(ExitColor);
	private static readonly Color StairsColor = Color.FromArgb(0x00, 0xE7, 0x00);
	private static readonly Pen StairsColorPen = new(StairsColor);
	private static readonly SolidBrush StairsColorBrush = new(StairsColor);



	private static readonly Pen[] DungeonColors;

	private static readonly Dictionary<ushort, string> VanillaDungeonPlaces = new() {
		{ 0x0000, "Home" },

		{ 0x0001, "Kichijoji mall" },

		{ 0x0002, "Dream Sequence @ F1" },
		{ 0x0102, " @ F2" },

		{ 0x0003, "Inogashira Park Mansion" },

		{ 0x0004, "Dream Sequence 2" },

		{ 0x0005, "Echo Building @ 1F" },
		{ 0x0105, "Echo Building @ 2F" },
		{ 0x0205, "Echo Building @ 3F" },
		{ 0x0305, "Echo Building @ 4F" },
		{ 0x0405, "Echo Building @ 5F" },

		{ 0x0006, "Hospital @ 1F" },
		{ 0x0106, "Hospital @ 2F" },

		{ 0x0007, "Laboratory @ 1F" },
		{ 0x0107, "Laboratory @ 2F" },

		{ 0x8008, "American Embassy @ B1" },
		{ 0x0008, "American Embassy @ F1" },
		{ 0x0108, "American Embassy @ F2" },

		{ 0x8009, "Goutou's HQ @ B1" },
		{ 0x0009, "Goutou's HQ @ 1F" },
		{ 0x0109, "Goutou's HQ @ 1F" },
		{ 0x0209, "Goutou's HQ @ 1F" },

		{ 0x810A, "Shinjuku mall @ B2" },
		{ 0x800A, "Shinjuku mall @ B1" },
		{ 0x000A, "Shinjuku mall @ F1" },
		{ 0x010A, "Shinjuku mall @ F2" },

		{ 0x000C, "" },

		{ 0x000D, "Kongokai" },

		{ 0x000E, "Shibuya @ F1" },
		{ 0x010E, "Shibuya @ F2" },

		{ 0x800F, "Roppongi @ B1" },
		{ 0x000F, "Roppongi @ F1" },
		{ 0x010F, "Roppongi @ F2" },
		{ 0x020F, "Roppongi @ F3" },

		{ 0x0010, "Momo's Brain" },

		{ 0x8011, "Police station @ B1" },
		{ 0x0011, "Police station @ F1" },
		{ 0x0111, "Police station @ F2" },
		{ 0x0211, "Police station @ F3" },
		{ 0x0311, "Police station @ F4" },
		{ 0x0411, "Police station @ F5" },

		{ 0x8112, "Ginza @ B2" },
		{ 0x8012, "Ginza @ B1" },

		{ 0x0013, "Shinagawa @ F1" },
		{ 0x0113, "Shinagawa @ F2" },
		{ 0x0213, "Shinagawa @ F3" },
		{ 0x0313, "Shinagawa @ F4" },

		{ 0x0014, "Ikebukuro @ F1" },
		{ 0x0114, "Ikebukuro @ F2" },
		{ 0x0214, "Ikebukuro @ F3" },
		{ 0x0314, "Ikebukuro @ F4" },

		{ 0x0015, "Ueno @ F1" },
		{ 0x0115, "Ueno @ F2" },
		{ 0x0215, "Ueno @ F3" },

		{ 0x0016, "Tokyo Destiny Land @ F1" },
		{ 0x0116, "Tokyo Destiny Land @ F2" },
		{ 0x0216, "Tokyo Destiny Land @ F3" },
		{ 0x0316, "Tokyo Destiny Land @ F4" },

		{ 0x0017, "" },

		{ 0x0018, " @ F01" },
		{ 0x0D18, " @ F14" },
		{ 0x1018, " @ F17" },

		{ 0x8719, "Cathedral @ B8" },
		{ 0x8619, "Cathedral @ B7" },
		{ 0x8519, "Cathedral @ B6" },
		{ 0x8419, "Cathedral @ B5" },
		{ 0x8319, "Cathedral @ B4" },
		{ 0x8219, "Cathedral @ B3" },
		{ 0x8119, "Cathedral @ B2" },
		{ 0x8019, "Cathedral @ B1" },
		{ 0x0019, "Cathedral @ F1" },
		{ 0x0119, "Cathedral @ F2" },
		{ 0x0219, "Cathedral @ F3" },
		{ 0x0319, "Cathedral @ F4" },
		{ 0x0419, "Cathedral @ F5" },
		{ 0x0519, "Cathedral @ F6" },
		{ 0x0619, "Cathedral @ F7" },
		{ 0x0719, "Cathedral @ F8" },

		{ 0x811A, "" },

		{ 0x811B, " @ B2" },
		{ 0x801B, " @ B1" },

		{ 0x821C, "Ginza-Cathedral Tunnel @ B3" },
		{ 0x811C, "Ginza-Cathedral Tunnel @ B2" },
		{ 0x801C, "Ginza-Cathedral Tunnel @ B1" },

		{ 0x801D, "Ginza-Shinagawa Tunnel" },

		{ 0x811E, "Ueno Bunkers @ B2" },
		{ 0x801E, "Ueno Bunkers @ B1" },

		{ 0x811F, "Resistance Hideout" },

		{ 0x0020, "" },

		{ 0x0021, "" },

		{ 0x0022, "" },

		{ 0x0023, "" },

		{ 0x0024, "" }, // Ginza entrances?
		{ 0x0025, "" }, // Ginza entrances?
		{ 0x0026, "" }, // Ginza entrances?
		{ 0x0027, "" }, // Ginza entrances?

		{ 0x0029, "East Mansion (Jikokuten)" },

		{ 0x002A, "South Mansion (Komokuten)" },

		{ 0x002B, "North Mansion (Bishamonten)" },

		{ 0x002C, "West Mansion (Zouchouten)" },

		{ 0x102D, "Tokyo Government Office W @ F45" },
		{ 0x112D, "Tokyo Government Office W @ F46" },
		{ 0x122D, "Tokyo Government Office W @ F47" },
		{ 0x132D, "Tokyo Government Office W @ F48" },

		{ 0x102E, "Tokyo Government Office E @ F45" },
		{ 0x112E, "Tokyo Government Office E @ F46" },
		{ 0x122E, "Tokyo Government Office E @ F47" },
		{ 0x132E, "Tokyo Government Office E @ F48" },

		{ 0x102F, "Kabukicho Prison" },

		{ 0x8430, " @ B5" },
		{ 0x8330, " @ B4" },
		{ 0x8230, " @ B3" },
		{ 0x8130, " @ B2" },
		{ 0x8030, " @ B1" },

		{ 0x8131, "Ginza-Cathedral Exit" },

		{ 0x8232, "Great Fork" },

		{ 0x0F33, "Tokyo Government Office @ F32" },

		{ 0x8034, "" },

		{ 0x0135, "Cathedral Law Trolling @ F2" },
		{ 0x0235, "Cathedral Law Trolling @ F3" },

		{ 0x8236, "Cathedral Chaos Trolling @ B3" },
		{ 0x8136, "Cathedral Chaos Trolling @ B2" },

		{ 0x8137, " @ B2" },
		{ 0x8037, " @ B1" },

		{ 0x0038, "Cathedral Law" },

		{ 0x0739, "" },

		{ 0x003F, "" },
	};






}
#pragma warning restore CA1416 // Validate platform compatibility
