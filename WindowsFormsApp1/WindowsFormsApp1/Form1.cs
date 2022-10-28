using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO.IsolatedStorage;

namespace SMTRandoApp;
public partial class MainForm : Form {
	public MainForm() {
		InitializeComponent();
		SetUp();
		FindSavedROMs();
		RepopulateROMList();
		SetOutputDirectory(Properties.Settings.Default.OutputDirectory);

		//MapArtist.ReadMapFromROM(Version1ROM).DrawMap();

		//			ROM game = new ROM(new byte[ROMSIZE], true);
		//			SuperBasicAssembler.Apply(game,
		//@"org $008000
		//LDA.b $FF
		//wait:
		//BRA wait
		//
		//JMP wait
		//");
		//
		//			Debug.WriteLine(string.Format("{0:X2}  {1:X2}  {2:X2}  {3:X2}  {4:X2}  {5:X2}  {6:X2}",
		//				game.Read8(0x8000), game.Read8(0x8001), game.Read8(0x8002),
		//				game.Read8(0x8003), game.Read8(0x8004), game.Read8(0x8005), game.Read8(0x8006)


		//				));
	}

	private ROMWriter Version1ROM = null;
	private ROMWriter Revision1ROM = null;

	private const string V1Name = "version1.sfc";
	private const string R1Name = "revision1.sfc";


	private readonly IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForAssembly();
	private void FindSavedROMs() {
		Version1ROM = LoadROM(V1Name, ROMVersion.Version1);
		Revision1ROM = LoadROM(R1Name, ROMVersion.Revision1);

		ROMWriter LoadROM(string name, ROMVersion requestedVersion) {
			if (!storageFile.FileExists(name)) {
				return null;
			}

			using var s = new IsolatedStorageFileStream(name, FileMode.Open, storageFile);

			byte[] romData = new byte[SMTSIZE];

			s.Position = 0;
			s.Read(romData, 0, SMTSIZE);

			s.Close();

			if (requestedVersion != GetROMVersion(romData)) {
				storageFile.DeleteFile(name);
				return null;
			}

			return new(romData, requestedVersion);
		}
	}

	private static bool VerifyDirectory(string directoryName) {
		if (string.IsNullOrWhiteSpace(directoryName)) return false;

		return Directory.Exists(directoryName);
	}

	private void BrowseOutputDirectory() {
		var folderBrowser = new FolderBrowserDialog() {
			ShowNewFolderButton = true,
		};

		if (folderBrowser.ShowDialog() != DialogResult.OK) return;

		SetOutputDirectory(folderBrowser.SelectedPath);
	}

	private bool VerifyCurrentDirectory() {
		return VerifyDirectory(OutputDirectoryButton.Text);
	}

	private void SetOutputDirectory(string directoryName) {
		if (!VerifyDirectory(directoryName)) {
			if (VerifyCurrentDirectory()) return;
			OutputDirectoryButton.Text = "Click to browse for an output directory.";
			OutputDirectoryButton.ForeColor = SystemColors.AppWorkspace;
			return;
		}

		OutputDirectoryButton.Text = directoryName;
		OutputDirectoryButton.ForeColor = Color.Black;
		Properties.Settings.Default.OutputDirectory = directoryName;
		Properties.Settings.Default.Save();
	}


	private void SetDirectoryButton_Click(object sender, EventArgs e) {
		var folderBrowser = new FolderBrowserDialog() {
			ShowNewFolderButton = true,
		};

		if (folderBrowser.ShowDialog() != DialogResult.OK) return;

		SetOutputDirectory(folderBrowser.SelectedPath);
	}



	private record ROMListEntry(string Name, ROMWriter ROM) {
		public override string ToString() => Name;
	}

	private void RepopulateROMList() {
		ROMSelectBox.BeginUpdate();
		ROMSelectBox.DataSource = null;

		var list = new List<ROMListEntry>();

		if (Version1ROM is not null) {
			list.Add(new("Version 1", Version1ROM));
		}

		if (Revision1ROM is not null) {
			list.Add(new("Revision 1", Revision1ROM));
		}

		ROMSelectBox.DataSource = list;
		ROMSelectBox.EndUpdate();

		ROMSelectBox.Enabled = list.Any();
		ROMUploadButton.Enabled = list.Count < 2;
	}

	/// <returns>Returns <see langword="true"/> if successful and the version is correct.</returns>
	private bool UploadROM(byte[] dataStream, ROMVersion version) {
		if (version != GetROMVersion(dataStream)) {
			DisplayProblem("This binary does not match the version requested.");
			return false;
		}

		try {
			switch (version) {
				case ROMVersion.Version1:
					if (Version1ROM is not null) {
						DisplayProblem("You've already saved a version 1 ROM.");
						return false;
					}

					Version1ROM = new(dataStream, version);
					SaveDataStream(V1Name);
					break;


				case ROMVersion.Revision1:
					if (Revision1ROM is not null) {
						DisplayProblem("You've already saved a version 1 ROM.");
						return false;
					}

					Revision1ROM = new(dataStream, version);
					SaveDataStream(R1Name);
					break;
			}
		} catch (FileLoadException) { // TODO handle properly

			return false;
		}

		return true;


		void SaveDataStream(string fileName) {
			using var s = new IsolatedStorageFileStream(fileName, FileMode.Create, FileAccess.Write, storageFile);
			s.Write(dataStream);
			s.Flush();
		}
	}



	/// <summary>
	/// Gets the ROM Version
	/// </summary>
	/// <returns><list type="">
	/// <item>0 for version 1</item>
	/// <item>1 for revision 1</item>
	/// <item>-1 otherwise</item>
	/// </list></returns>
	private static ROMVersion GetROMVersion(byte[] rom) {
		const string REV0SHA = "D0B5EAC22D9E07C4A7CA10387200408BED0E635684CECC98AD008824E2952A6A";
		const string REV1SHA = "DCAC22D069C7AD1F4768A992EFA4FD5856DFB1144382E2199349E353C9066423";

		if (rom.Length is not SMTSIZE) {
			return ROMVersion.InvalidVersion;
		}

		var builder = new StringBuilder();
		byte[] hashSequence = System.Security.Cryptography.SHA256.Create().ComputeHash(rom);

		foreach (var hashDigit in hashSequence) {
			builder.Append($"{hashDigit:X2}");
		}

		string check = builder.ToString();

		return check switch {
			REV0SHA => ROMVersion.Version1,
			REV1SHA => ROMVersion.Revision1,
			_ => ROMVersion.InvalidVersion
		};
	}


	private static void DisplayProblem(string message) {
		MessageBox.Show(message, "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}

	private void SetUp() {
		musicShuffleSel.DataSource = SoundShuffler.MusicShuffles;
		sfxShuffleSel.DataSource = SoundShuffler.SFXShuffles;
		demonEXPRandoSel.DataSource = DemonShuffler.DemonExperienceShuffles;
		demonPaletteRandoSel.DataSource = DemonShuffler.DemonPaletteShuffles;

		affiliationRandoSel.DataSource = DemonShuffler.DemonReligionShuffles;
		demonMovesRandoSel.DataSource = DemonShuffler.DemonMoveShuffles;
		RandomizeDropsDropdown.DataSource = DemonShuffler.DemonItemShuffles;
		MagOrbRandoBox.DataSource = DemonShuffler.MagOrbDropShuffes;

		itemBonusesSel.DataSource = ItemShuffler.ItemBonusShuffles;
		itemAlignSel.DataSource = ItemShuffler.ItemReligionShuffles;
		itemGenderSel.DataSource = ItemShuffler.ItemGenderShuffles;

		skillCostSel.DataSource = SkillShuffler.SkillCostShuffles;
		skillLearnSel.DataSource = SkillShuffler.HeroSkillShuffles;
		skillDamageSel.DataSource = SkillShuffler.SkillDamageShuffles;
		skillStatusSel.DataSource = SkillShuffler.SkillStatusShuffles;

		themeShuffleSel.DataSource = AreaShuffler.DungeonThemeShuffles;
		encounterRandoSel.DataSource = AreaShuffler.DemonEncounterShuffles;

		translateDemonNamesSel.DataSource = DemonShuffler.DemonNameTranslations;
		translateClassNamesSel.DataSource = DemonShuffler.DemonClassTranslations;
		translateMoveNamesSel.DataSource = SkillShuffler.SkillNameTranslations;
		translateItemSel.DataSource = ItemShuffler.ItemNameTranslations;

		shopPricesSel.DataSource = ItemShuffler.ShopPriceShuffles;

		SetDefaultControls(this);

		Text = $"Shin Megami Tensei 1 (SNES) Randomizer - v{VERSION}";
		versionLabel.Text = VERSION;

		webBrowser1.DocumentText = Properties.Resources.help;

		SetNewSeedBoxString();
	}

	private static void SetDefaultControls(Control a) {
		foreach (Control b in a.Controls) {
			if (b is ComboBox cb) {
				cb.TabStop = false;

				if (cb.Items.Count > 0) {
					cb.SelectedIndex = 0;
				} else {
					cb.Enabled = false;
				}
			} else {
				SetDefaultControls(b);
			}
		}
	}

	private void GenerateRandomizedGame() {
		if (ROMSelectBox.SelectedItem is not ROMListEntry BaseROM) {
			MessageBox.Show(
				"No base ROM provided for game generation.",
				"Missing ROM",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
			);
			return;
		}

		if (!VerifyCurrentDirectory()) {
			MessageBox.Show(
				"Please choose a location to save your randomizer games.",
				"Nowhere to save",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
			);
			return;
		}


		ROMWriter game = BaseROM.ROM.Clone();

		ReseedRNG(seededBox.Checked ? seedBox.Text : null);


		game.Skills.AllowOHKO = removeOHKOBox.Checked;

		/*================================================================================================*\
		 * APPLY ASM PATCHES
		\*================================================================================================*/


		/*================================================================================================*\
		 * ITEMS TAB
		\*================================================================================================*/
		// ITEMS
		//RunShuffle(itemStatsRandoSel);
		RunShuffle(itemBonusesSel);
		RunShuffle(itemAlignSel);
		RunShuffle(itemGenderSel);

		// SKILLS
		RunShuffle(skillCostSel);
		RunShuffle(skillLearnSel);
		RunShuffle(skillDamageSel);
		RunShuffle(skillStatusSel);

		// DO THIS LAST
		game.Items.WriteAllItemData();
		game.Skills.WriteSkillData();

		/*================================================================================================*\
		 * DEMONS TAB
		\*================================================================================================*/
		RunShuffle(demonPaletteRandoSel);
		RunShuffle(affiliationRandoSel);
		RunShuffle(demonMovesRandoSel);
		RunShuffle(demonEXPRandoSel);
		RunShuffle(MagOrbRandoBox);


		game.Demons.WriteDemonData();

		/*================================================================================================*\
		 * DUNGEON TAB
		\*================================================================================================*/
		// Theme
		RunShuffle(themeShuffleSel);

		// Shops
		// THIS NEEDS TO BE AFTER ITEM STATS
		RunShuffle(shopPricesSel);
		RunShuffle(RandomizeDropsDropdown);

		// Maps
		if (trueNorthBox.Checked) {
			game.Write16(new Address(0x00ED96, 0x00ED99) + 1, 0x803A);
			game.Write16(new Address(0x00EF65, 0x00EF68) + 1, 0x803A);
			game.Write16(new Address(0x00EFB3, 0x00EFB6) + 1, 0x803A);
			game.Write16(new Address(0x00F24B, 0x00F24E) + 1, 0x803A);
		}

		// High Contrast Maps
		if (hcMapBox.Checked) {
			// this address works for both versions
			game.Write16(0x23FFE4,
				0x0180, // Dark Green
				0x7FFF, // White
				0x0000, // Black
				0x1D07, // Dark gray
				0x039C, // Yellow
				0x7280 // Blue
			);
		}

		/*================================================================================================*\
		 * GENERATE TAB
		\*================================================================================================*/
		// Quality of Life
		if (fastMoveBox.Checked) {
			game.Write8(new Address(0x00C8AB, 0x00C8AE) + 1, 0x01); // Movement delay
			game.Write8(new Address(0x00C8AF, 0x00C8B2) + 1, 0x01); // Movement delay
			game.Write8(new Address(0x00C926, 0x00C929) + 1, 0x01); // Bonk delay timer

			// game.Write8(0x028292, 0xD0, 0xD3); // TODO NOT VERY GOOD
		}

		// get rid of annoying flashing when paralyzed or poisoned
		game.NOPOut(0x0F994C, 4); // address verified to work on both versions


		// Sound
		RunShuffle(musicShuffleSel);
		RunShuffle(sfxShuffleSel);

		/*================================================================================================*\
		 * TEXT
		\*================================================================================================*/

		// Add text from our entities
		if (translateBox.Checked) {
			game.DoTranslation(
				translateDemonNamesSel.SelectedItem as TranslateOption,
				translateClassNamesSel.SelectedItem as TranslateOption,
				translateMoveNamesSel.SelectedItem as TranslateOption,
				translateItemSel.SelectedItem as TranslateOption
			);
		}


		// THIS MUST BE AFTER TEXT AS IT POTENTIALLY RELIES ON GENERATED POINTERS
		//RunShuffle(classShuffleSel);
		RunShuffle(encounterRandoSel);

		// other stuff that will have to be after text will be
		// rags

		//game.World.WriteAllScriptedFights();

		/*================================================================================================*\
		 * OUTPUT
		\*================================================================================================*/
		// Output file
		string seedText;
		if (seededBox.Checked) {
			if (seedBox.Text.Length < 1) {
				SetNewSeedBoxString();
			}
			seedText = seedBox.Text;
		} else {
			seedText = "ns-" + GenerateNewSeedString();
		}

		game.WriteSpoiler();

		try {
			string fileName = $"{OutputDirectoryButton.Text}{Path.DirectorySeparatorChar}SMT1R-{seedText}.sfc";
			FileStream fs = new(fileName, FileMode.Create, FileAccess.Write);
			fs.Write(game.Stream, 0, game.Stream.Length);
			fs.Close();

			if (showSuccessBox.Checked) {
				MessageBox.Show(
					$"Successfully generated game as\n{fileName}",
					"I did it!"
					);
			}
			if (genReseedBox.Checked && seededBox.Checked) {
				SetNewSeedBoxString();
			}

		} catch (Exception) { // TODO handle properly

		}

		// I just don't feel like tuping this same thing over and over and over and over again
		void RunShuffle(ComboBox box) {
			(box.SelectedItem as ShuffleOption).RunShuffle(game);
		}
	}

	private void SetNewSeedBoxString() {
		seedBox.Text = GenerateNewSeedString();
	}

	private void GenerateButton_Click_1(object sender, EventArgs e) {
		GenerateRandomizedGame();
	}

	/*================================================================================================*/

	private void ReseedButton_Click(object sender, EventArgs e) {
		SetNewSeedBoxString();
	}

	private void JashinChanBox_CheckedChanged(object sender, EventArgs e) {
		jashinPose.Visible = JashinChanBox.Checked;
	}

	private void TranslateBox_CheckedChanged(object sender, EventArgs e) {
		translatePanel.Enabled = translateBox.Checked;
	}

	private void SeededBox_CheckedChanged(object sender, EventArgs e) {
		seedPanel.Enabled = seededBox.Checked;
		genReseedBox.Enabled = seededBox.Checked;
	}

	private void ReleaseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		Process.Start("https://github.com/spannerisms/smt1rando/releases/latest");
	}

	private void DiscordLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		Process.Start("https://discord.gg/FZsX6HPZw5");
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		Process.Start("https://github.com/spannerisms/smt1dasm");
	}

	private void OutputDirectoryButton_Click(object sender, EventArgs e) {
		BrowseOutputDirectory();
	}

	private void ROMUploadButton_Click(object sender, EventArgs e) {
		byte[] ROMData = new byte[SMTSIZE];

		string fileName;

		if (openROM.ShowDialog() is DialogResult.OK) {
			fileName = openROM.FileName;
		} else {
			return;
		}

		try {
			using var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			StringBuilder builder = new();

			fs.Position = 0;
			fs.Read(ROMData, 0, SMTSIZE);

			var version = GetROMVersion(ROMData);

			if (version is ROMVersion.InvalidVersion) {
				MessageBox.Show(
					"Please provide a clean vanilla copy of Shin Megami Tensei.\n" +
					"Both version 0 (V1.0) and revision 1 (Rev 1) are valid.",
					"Invalid base ROM provided",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				return;
			}

			if (!UploadROM(ROMData, version)) return;

			MessageBox.Show(
				"Successfully uploaded your " + 
					version switch {
						ROMVersion.Version1 => "version 1",
						ROMVersion.Revision1 => "revision 1",
						_ => "corrupted"
					}
				+ " ROM!",
				"Hooray!",
				MessageBoxButtons.OK
			);

			RepopulateROMList();

		} catch (Exception) { }
	}
}
