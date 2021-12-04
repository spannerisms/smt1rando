using static SMTRandoApp.Modeling.TargetAudience;
using static SMTRandoApp.Modeling.ItemType;

namespace SMTRandoApp.Modeling;

internal partial class Item {
	private static readonly Item[] VanillaList = new Item[] {

		// Melee weapons
		new Item {
			ID = 0x00, ItemType = MeleeWeapon, DisplayName = "Attack knife",
			EnglishName = "Knife", JapaneseName = "アタックナイフ",
			BuyPrice = 50, SellPrice = 25,
			WearableBy = Everyone,
			Power = 6, AuxPow = 1,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x01, ItemType = MeleeWeapon, DisplayName = "Machete",
			EnglishName = "Machete", JapaneseName = "マチェット",
			BuyPrice = 65, SellPrice = 32,
			WearableBy = Everyone,
			Power = 7, AuxPow = 2,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x02, ItemType = MeleeWeapon, DisplayName = "Tonfā",
			EnglishName = "Tonfa", JapaneseName = "トンファー",
			BuyPrice = 70, SellPrice = 35,
			WearableBy = Male|AllReligions,
			Power = 6, AuxPow = 2,
			Stat3 = 0x01, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x03, ItemType = MeleeWeapon, DisplayName = "Spike rod",
			EnglishName = "Spikerod", JapaneseName = "スパイクロッド",
			BuyPrice = 78, SellPrice = 39,
			WearableBy = Male|AllReligions,
			Power = 8, AuxPow = 5,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x04, ItemType = MeleeWeapon, DisplayName = "Replica sword",
			EnglishName = "Rapier", JapaneseName = "もぞうとう",
			BuyPrice = 90, SellPrice = 45,
			WearableBy = Everyone,
			Power = 9, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x23, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x05, ItemType = MeleeWeapon, DisplayName = "Unnamed katana",
			EnglishName = "Katana", JapaneseName = "むめいのかたな",
			BuyPrice = 120, SellPrice = 60,
			WearableBy = Male|AllReligions,
			Power = 13, AuxPow = 7,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x06, ItemType = MeleeWeapon, DisplayName = "Rectifier",
			EnglishName = "Rectify", JapaneseName = "せいりゅうとう",
			BuyPrice = 180, SellPrice = 90,
			WearableBy = Male|AllReligions,
			Power = 16, AuxPow = 8,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x07, ItemType = MeleeWeapon, DisplayName = "Scorpion whip",
			EnglishName = "Bug whip", JapaneseName = "さそりムチ",
			BuyPrice = 0, SellPrice = 40,
			WearableBy = Female|AllReligions,
			Power = 10, AuxPow = 5,
			Stat3 = 0x09, Stat7 = 0x1A, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x08, ItemType = MeleeWeapon, DisplayName = "Battle hammer",
			EnglishName = "Hammer", JapaneseName = "バトルハンマー",
			BuyPrice = 0, SellPrice = 30,
			WearableBy = Male|AllReligions,
			Power = 18, AuxPow = 3,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x09, ItemType = MeleeWeapon, DisplayName = "Three-section staff",
			EnglishName = "Staff", JapaneseName = "さんせつこん",
			BuyPrice = 200, SellPrice = 100,
			WearableBy = Male|AllReligions,
			Power = 12, AuxPow = 15,
			Stat3 = 0x07, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x0A, ItemType = MeleeWeapon, DisplayName = "Bizen's Tanto",
			EnglishName = "Dagger", JapaneseName = "びぜんのたんとう",
			BuyPrice = 0, SellPrice = 80,
			WearableBy = Female|AllReligions,
			Power = 17, AuxPow = 8,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x0B, ItemType = MeleeWeapon, DisplayName = "Chainsaw",
			EnglishName = "Chainsaw", JapaneseName = "チェーンソー",
			BuyPrice = 0, SellPrice = 15,
			WearableBy = Male|AllReligions,
			Power = 25, AuxPow = 2,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x0C, ItemType = MeleeWeapon, DisplayName = "Swiss Army Knife",
			EnglishName = "SA knife", JapaneseName = "アセイミナイフ",
			BuyPrice = 0, SellPrice = 22,
			WearableBy = Female|AllReligions,
			Power = 22, AuxPow = 15,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x0D, ItemType = MeleeWeapon, DisplayName = "Gladius",
			EnglishName = "Gladius", JapaneseName = "グラディウス",
			BuyPrice = 0, SellPrice = 27,
			WearableBy = Male|AllReligions,
			Power = 29, AuxPow = 0,
			Stat3 = 0x06, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x0E, ItemType = MeleeWeapon, DisplayName = "Kotetsu's Honor",
			EnglishName = "Fork", JapaneseName = "めいとうこてつ",
			BuyPrice = 0, SellPrice = 37,
			WearableBy = Male|AllReligions,
			Power = 32, AuxPow = 7,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x0F, ItemType = MeleeWeapon, DisplayName = "Tomoe's Naginata",
			EnglishName = "Screw", JapaneseName = "ともえのなぎなた",
			BuyPrice = 0, SellPrice = 39,
			WearableBy = Female|AllReligions,
			Power = 24, AuxPow = 17,
			Stat3 = 0x01, Stat7 = 0x10, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x10, ItemType = MeleeWeapon, DisplayName = "Mikazuchi's Tachi",
			EnglishName = "Woldo", JapaneseName = "みかづきのたち",
			BuyPrice = 0, SellPrice = 42,
			WearableBy = BothGenders|Neutral,
			Power = 30, AuxPow = 20,
			Stat3 = 0x07, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x11, ItemType = MeleeWeapon, DisplayName = "Kodachi of Light",
			EnglishName = "Khopesh", JapaneseName = "ひかりのこだち",
			BuyPrice = 0, SellPrice = 45,
			WearableBy = BothGenders|Law,
			Power = 35, AuxPow = 30,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x2F, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x12, ItemType = MeleeWeapon, DisplayName = "Guillotine axe",
			EnglishName = "Hatchet", JapaneseName = "ギロチンアクス",
			BuyPrice = 0, SellPrice = 47,
			WearableBy = Male|Chaos,
			Power = 40, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x13, ItemType = MeleeWeapon, DisplayName = "Lotus whip",
			EnglishName = "Takoba", JapaneseName = "ぐれんのムチ",
			BuyPrice = 0, SellPrice = 50,
			WearableBy = Female|AllReligions,
			Power = 25, AuxPow = 20,
			Stat3 = 0x0C, Stat7 = 0x02, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x14, ItemType = MeleeWeapon, DisplayName = "Bizen-Osafune",
			EnglishName = "Mambele", JapaneseName = "びぜんおさふね",
			BuyPrice = 0, SellPrice = 66,
			WearableBy = Everyone,
			Power = 35, AuxPow = 10,
			Stat3 = 0x07, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x15, ItemType = MeleeWeapon, DisplayName = "Raiden's whip",
			EnglishName = "Khanda", JapaneseName = "らいでんのムチ",
			BuyPrice = 0, SellPrice = 75,
			WearableBy = Female|AllReligions,
			Power = 37, AuxPow = 15,
			Stat3 = 0x0A, Stat7 = 0x09, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x16, ItemType = MeleeWeapon, DisplayName = "Lance of Curses",
			EnglishName = "Lance", JapaneseName = "ランスオブカース",
			BuyPrice = 0, SellPrice = 90,
			WearableBy = Male|AllReligions,
			Power = 50, AuxPow = 0,
			Stat3 = 0x06, Stat7 = 0x1C, Stat8 = 0x00, Stat9 = 0x01, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x17, ItemType = MeleeWeapon, DisplayName = "Kamudo's sword",
			EnglishName = "Big pole", JapaneseName = "カムドのつるぎ",
			BuyPrice = 0, SellPrice = 100,
			WearableBy = Male|Neutral,
			Power = 55, AuxPow = 5,
			Stat3 = 0x00, Stat7 = 0x15, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x18, ItemType = MeleeWeapon, DisplayName = "Plasma sword",
			EnglishName = "Jintachi", JapaneseName = "プラズマソード",
			BuyPrice = 0, SellPrice = 150,
			WearableBy = Male|Law,
			Power = 41, AuxPow = 20,
			Stat3 = 0x08, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x19, ItemType = MeleeWeapon, DisplayName = "Kusanagi-no-tsurugi",
			EnglishName = "Hina", JapaneseName = "くさなぎのつるぎ",
			BuyPrice = 0, SellPrice = 180,
			WearableBy = Everyone,
			Power = 40, AuxPow = 10,
			Stat3 = 0x0F, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x22, StatB = 0x00,
			STRBonus = 0, INTBonus = 1, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x1A, ItemType = MeleeWeapon, DisplayName = "Brionac",
			EnglishName = "Brionac", JapaneseName = "ブリューナク",
			BuyPrice = 0, SellPrice = 205,
			WearableBy = Female|AllReligions,
			Power = 60, AuxPow = 20,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x2D, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 1,
		},

		new Item {
			ID = 0x1B, ItemType = MeleeWeapon, DisplayName = "Tokkosho",
			EnglishName = "Vajra", JapaneseName = "とっこしょ",
			BuyPrice = 0, SellPrice = 210,
			WearableBy = Male|Chaos,
			Power = 75, AuxPow = 3,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x13, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 1, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x1C, ItemType = MeleeWeapon, DisplayName = "Kuchinawa's sword",
			EnglishName = "Luwuk", JapaneseName = "クチナワのけん",
			BuyPrice = 0, SellPrice = 250,
			WearableBy = Everyone,
			Power = 58, AuxPow = 8,
			Stat3 = 0x0A, Stat7 = 0x50, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 1, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x1D, ItemType = MeleeWeapon, DisplayName = "Futsu-no-mitama",
			EnglishName = "Baguette", JapaneseName = "ふつのみたま",
			BuyPrice = 0, SellPrice = 290,
			WearableBy = Everyone,
			Power = 80, AuxPow = 3,
			Stat3 = 0x07, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x17, StatB = 0x00,
			STRBonus = 0, INTBonus = 1, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x1E, ItemType = MeleeWeapon, DisplayName = "Sonic blade",
			EnglishName = "Gayang", JapaneseName = "ソニックブレード",
			BuyPrice = 0, SellPrice = 320,
			WearableBy = Male|AllReligions,
			Power = 44, AuxPow = 5,
			Stat3 = 0x0E, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 1, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x1F, ItemType = MeleeWeapon, DisplayName = "Cliamh Solais",
			EnglishName = "Claiomh", JapaneseName = "クラウソナス",
			BuyPrice = 0, SellPrice = 360,
			WearableBy = Everyone,
			Power = 98, AuxPow = 10,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x20, ItemType = MeleeWeapon, DisplayName = "Shichiseiken",
			EnglishName = "Gari", JapaneseName = "しちせいけん",
			BuyPrice = 0, SellPrice = 450,
			WearableBy = Male|AllReligions,
			Power = 77, AuxPow = 30,
			Stat3 = 0x04, Stat7 = 0x54, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x0D, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 1, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x21, ItemType = MeleeWeapon, DisplayName = "Higyosanko",
			EnglishName = "Nimcha", JapaneseName = "ひぎょうさんこ",
			BuyPrice = 0, SellPrice = 500,
			WearableBy = Male|AllReligions,
			Power = 87, AuxPow = 5,
			Stat3 = 0x00, Stat7 = 0x13, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x14, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 2, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x22, ItemType = MeleeWeapon, DisplayName = "Kodachi of Kikusui",
			EnglishName = "Kodachi", JapaneseName = "きくすいのこだち",
			BuyPrice = 0, SellPrice = 620,
			WearableBy = Female|AllReligions,
			Power = 88, AuxPow = 15,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x30, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 1,
		},

		new Item {
			ID = 0x23, ItemType = MeleeWeapon, DisplayName = "Yoto Nihiru",
			EnglishName = "Shotel", JapaneseName = "ようとうニヒル",
			BuyPrice = 0, SellPrice = 1,
			WearableBy = Everyone,
			Power = 120, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x44, Stat8 = 0x00, Stat9 = 0x01, StatA = 0x5A, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x24, ItemType = MeleeWeapon, DisplayName = "Present from Hades",
			EnglishName = "Nagamaki", JapaneseName = "メイドのミヤゲ",
			BuyPrice = 0, SellPrice = 750,
			WearableBy = Male|Law,
			Power = 80, AuxPow = 15,
			Stat3 = 0x01, Stat7 = 0x17, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x15, StatB = 0x00,
			STRBonus = 2, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x25, ItemType = MeleeWeapon, DisplayName = "Gae Bolga",
			EnglishName = "Gae Bulg", JapaneseName = "ゲイボルク",
			BuyPrice = 0, SellPrice = 830,
			WearableBy = Female|AllReligions,
			Power = 90, AuxPow = 40,
			Stat3 = 0x04, Stat7 = 0x21, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x3C, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 2, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x26, ItemType = MeleeWeapon, DisplayName = "Muramasa's cursed sword",
			EnglishName = "Maken", JapaneseName = "まけんムラマサ",
			BuyPrice = 0, SellPrice = 1,
			WearableBy = Female|AllReligions,
			Power = 130, AuxPow = 0,
			Stat3 = 0x0E, Stat7 = 0x1A, Stat8 = 0x00, Stat9 = 0x01, StatA = 0x1A, StatB = 0x00,
			STRBonus = 2, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x27, ItemType = MeleeWeapon, DisplayName = "Deathbringer",
			EnglishName = "Curtana", JapaneseName = "デスブリンガー",
			BuyPrice = 0, SellPrice = 1200,
			WearableBy = Male|Chaos,
			Power = 90, AuxPow = 15,
			Stat3 = 0x07, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x16, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x28, ItemType = MeleeWeapon, DisplayName = "Headhunter spoon",
			EnglishName = "Spoon", JapaneseName = "くびかりスプーン",
			BuyPrice = 0, SellPrice = 1,
			WearableBy = Everyone,
			Power = 120, AuxPow = 25,
			Stat3 = 0x03, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x01, StatA = 0x0F, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x29, ItemType = MeleeWeapon, DisplayName = "Cat of nine tails",
			EnglishName = "Cat9tail", JapaneseName = "きゅうびのムチ",
			BuyPrice = 0, SellPrice = 2200,
			WearableBy = Female|Neutral,
			Power = 78, AuxPow = 20,
			Stat3 = 0x0C, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x1B, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x2A, ItemType = MeleeWeapon, DisplayName = "Alchemist's Sword",
			EnglishName = "Renkiken", JapaneseName = "れんきのけん",
			BuyPrice = 0, SellPrice = 2700,
			WearableBy = Everyone,
			Power = 98, AuxPow = 30,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x23, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x2B, ItemType = MeleeWeapon, DisplayName = "Amenonuhoko",
			EnglishName = "Naginata", JapaneseName = "あめのぬぼこ",
			BuyPrice = 0, SellPrice = 3300,
			WearableBy = Female|Law,
			Power = 100, AuxPow = 10,
			Stat3 = 0x01, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x25, StatB = 0x00,
			STRBonus = 2, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x2C, ItemType = MeleeWeapon, DisplayName = "Yatsuka's sword",
			EnglishName = "Falchion", JapaneseName = "やつかのけん",
			BuyPrice = 0, SellPrice = 3500,
			WearableBy = Everyone,
			Power = 115, AuxPow = 5,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x74, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x2D, ItemType = MeleeWeapon, DisplayName = "Valhalla sword",
			EnglishName = "Hengdang", JapaneseName = "バルハラソード",
			BuyPrice = 0, SellPrice = 3800,
			WearableBy = Female|Chaos,
			Power = 130, AuxPow = 16,
			Stat3 = 0x00, Stat7 = 0xFF, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x40, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x2E, ItemType = MeleeWeapon, DisplayName = "Sword of Hao",
			EnglishName = "Xiphos", JapaneseName = "はおうのつるぎ",
			BuyPrice = 0, SellPrice = 4100,
			WearableBy = Male|AllReligions,
			Power = 135, AuxPow = 3,
			Stat3 = 0x00, Stat7 = 0x26, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x1B, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 2, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x2F, ItemType = MeleeWeapon, DisplayName = "Hades Hazuki",
			EnglishName = "Estoc", JapaneseName = "めいふはづき",
			BuyPrice = 0, SellPrice = 4400,
			WearableBy = Male|Neutral,
			Power = 155, AuxPow = 10,
			Stat3 = 0x00, Stat7 = 0x0E, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x0F, StatB = 0x00,
			STRBonus = 2, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x30, ItemType = MeleeWeapon, DisplayName = "Angel's Trumpet",
			EnglishName = "Akrafena", JapaneseName = "てんしのラッパ",
			BuyPrice = 13220, SellPrice = 6660,
			WearableBy = Everyone,
			Power = 200, AuxPow = 10,
			Stat3 = 0x0E, Stat7 = 0x13, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x34, StatB = 0x00,
			STRBonus = 3, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x31, ItemType = MeleeWeapon, DisplayName = "Luna Blade",
			EnglishName = "Cutlass", JapaneseName = "ルナブレイド",
			BuyPrice = 9400, SellPrice = 4700,
			WearableBy = Female|AllReligions,
			Power = 140, AuxPow = 5,
			Stat3 = 0x01, Stat7 = 0x14, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x35, StatB = 0x00,
			STRBonus = 0, INTBonus = 3, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x32, ItemType = MeleeWeapon, DisplayName = "Reaper's Bell",
			EnglishName = "Scythe", JapaneseName = "しにがみのかね",
			BuyPrice = 13220, SellPrice = 6660,
			WearableBy = Everyone,
			Power = 215, AuxPow = 10,
			Stat3 = 0x0E, Stat7 = 0x15, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x17, StatB = 0x00,
			STRBonus = 3, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x33, ItemType = MeleeWeapon, DisplayName = "Majousen",
			EnglishName = "Majousen", JapaneseName = "まじょうせん",
			BuyPrice = 9800, SellPrice = 4900,
			WearableBy = Female|AllReligions,
			Power = 120, AuxPow = 3,
			Stat3 = 0x0E, Stat7 = 0x16, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x3F, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 3, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x34, ItemType = MeleeWeapon, DisplayName = "Lotus Wand",
			EnglishName = "Lotus", JapaneseName = "ロータスワンド",
			BuyPrice = 10200, SellPrice = 5100,
			WearableBy = Everyone,
			Power = 130, AuxPow = 10,
			Stat3 = 0x09, Stat7 = 0x0B, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x3E, StatB = 0x00,
			STRBonus = 3, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x35, ItemType = MeleeWeapon, DisplayName = "Longinus",
			EnglishName = "Longinus", JapaneseName = "ロンギヌス",
			BuyPrice = 10400, SellPrice = 5200,
			WearableBy = Everyone,
			Power = 165, AuxPow = 20,
			Stat3 = 0x00, Stat7 = 0x0F, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x30, StatB = 0x00,
			STRBonus = 0, INTBonus = 3, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x36, ItemType = MeleeWeapon, DisplayName = "Soul blade",
			EnglishName = "Moplah", JapaneseName = "ソルブレイド",
			BuyPrice = 0, SellPrice = 5500,
			WearableBy = Female|AllReligions,
			Power = 160, AuxPow = 40,
			Stat3 = 0x04, Stat7 = 0x21, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x2E, StatB = 0x00,
			STRBonus = 0, INTBonus = 3, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x37, ItemType = MeleeWeapon, DisplayName = "Stradivari",
			EnglishName = "Stratus", JapaneseName = "ストラディバリ",
			BuyPrice = 0, SellPrice = 6660,
			WearableBy = Everyone,
			Power = 255, AuxPow = 0,
			Stat3 = 0x0E, Stat7 = 0x12, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x41, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 3, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x38, ItemType = MeleeWeapon, DisplayName = "Ame-no-Murakumo",
			EnglishName = "Murakumo", JapaneseName = "あめのむらくも",
			BuyPrice = 0, SellPrice = 5700,
			WearableBy = Everyone,
			Power = 180, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x0E, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x2D, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x39, ItemType = MeleeWeapon, DisplayName = "Scattered wind sword",
			EnglishName = "Fujinken", JapaneseName = "ふうじんけん",
			BuyPrice = 0, SellPrice = 6000,
			WearableBy = Everyone,
			Power = 155, AuxPow = 5,
			Stat3 = 0x08, Stat7 = 0x04, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x05, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x3A, ItemType = MeleeWeapon, DisplayName = "Thunder sword",
			EnglishName = "Rajinken", JapaneseName = "らいじんけん",
			BuyPrice = 0, SellPrice = 6000,
			WearableBy = Male|AllReligions,
			Power = 170, AuxPow = 3,
			Stat3 = 0x07, Stat7 = 0x08, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x09, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x3B, ItemType = MeleeWeapon, DisplayName = "River sword",
			EnglishName = "Karyuken", JapaneseName = "かりゅうけん",
			BuyPrice = 0, SellPrice = 6200,
			WearableBy = Female|AllReligions,
			Power = 185, AuxPow = 2,
			Stat3 = 0x01, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x01, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x3C, ItemType = MeleeWeapon, DisplayName = "Sword of Heaven",
			EnglishName = "Amanremu", JapaneseName = "あまのみつるぎ",
			BuyPrice = 12800, SellPrice = 6400,
			WearableBy = Male|Law,
			Power = 190, AuxPow = 8,
			Stat3 = 0x07, Stat7 = 0x0A, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x28, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x3D, ItemType = MeleeWeapon, DisplayName = "Masakodo's katana",
			EnglishName = "Gulok", JapaneseName = "マサカドのかたな",
			BuyPrice = 12800, SellPrice = 6400,
			WearableBy = Male|Neutral,
			Power = 195, AuxPow = 10,
			Stat3 = 0x07, Stat7 = 0x16, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x11, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x3E, ItemType = MeleeWeapon, DisplayName = "Kurikara's sword",
			EnglishName = "Kabeala", JapaneseName = "くりからのつるぎ",
			BuyPrice = 12800, SellPrice = 6400,
			WearableBy = Male|Chaos,
			Power = 190, AuxPow = 15,
			Stat3 = 0x07, Stat7 = 0x02, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x29, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x3F, ItemType = MeleeWeapon, DisplayName = "Hinokagutsuchi",
			EnglishName = "Kujang", JapaneseName = "ひのかぐつち",
			BuyPrice = 13000, SellPrice = 6500,
			WearableBy = Everyone,
			Power = 200, AuxPow = 20,
			Stat3 = 0x08, Stat7 = 0x03, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x12, StatB = 0x00,
			STRBonus = 1, INTBonus = 1, MAGBonus = 1, VITBonus = 1, SPDBonus = 1, LUKBonus = 1,
		},

		// Guns
		new Item {
			ID = 0x40, ItemType = Gun, DisplayName = "New Nanbu",
			EnglishName = "Naboot", JapaneseName = "ニューナンブ",
			BuyPrice = 120, SellPrice = 60,
			WearableBy = Everyone,
			Power = 18, AuxPow = 8,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x41, ItemType = Gun, DisplayName = "Beretta 92F",
			EnglishName = "Beretta", JapaneseName = "ベレッタ92F",
			BuyPrice = 180, SellPrice = 90,
			WearableBy = Everyone,
			Power = 22, AuxPow = 15,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x42, ItemType = Gun, DisplayName = "MP5 submachine gun",
			EnglishName = "MP5 SMG", JapaneseName = "MP5マシンガン",
			BuyPrice = 250, SellPrice = 125,
			WearableBy = Everyone,
			Power = 34, AuxPow = 3,
			Stat3 = 0x0A, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x43, ItemType = Gun, DisplayName = "M16 rifle",
			EnglishName = "M16 AR", JapaneseName = "M16ライフル",
			BuyPrice = 700, SellPrice = 350,
			WearableBy = Male|AllReligions,
			Power = 43, AuxPow = 5,
			Stat3 = 0x0C, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x44, ItemType = Gun, DisplayName = "SPAS12",
			EnglishName = "SPAS12", JapaneseName = "SPAS12",
			BuyPrice = 1000, SellPrice = 500,
			WearableBy = Everyone,
			Power = 55, AuxPow = 8,
			Stat3 = 0x08, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x45, ItemType = Gun, DisplayName = "M249 SAW LMG/FN Minimi",
			EnglishName = "M249 SAW", JapaneseName = "M249ミニミ",
			BuyPrice = 1500, SellPrice = 750,
			WearableBy = Male|AllReligions,
			Power = 68, AuxPow = 10,
			Stat3 = 0x0C, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x46, ItemType = Gun, DisplayName = "Browning M2",
			EnglishName = "Browning", JapaneseName = "ブローニングM2",
			BuyPrice = 2000, SellPrice = 1000,
			WearableBy = Male|AllReligions,
			Power = 72, AuxPow = 0,
			Stat3 = 0x0E, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x47, ItemType = Gun, DisplayName = "Pauza P50",
			EnglishName = "P50 AMR", JapaneseName = "パウザP50",
			BuyPrice = 2800, SellPrice = 1400,
			WearableBy = Male|AllReligions,
			Power = 110, AuxPow = 25,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x48, ItemType = Gun, DisplayName = "Explosive gun",
			EnglishName = "Mine gun", JapaneseName = "きらいほう",
			BuyPrice = 3500, SellPrice = 1750,
			WearableBy = Everyone,
			Power = 80, AuxPow = 10,
			Stat3 = 0x0C, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x49, ItemType = Gun, DisplayName = "Golden gun",
			EnglishName = "Gold gun", JapaneseName = "おうごんじゅう",
			BuyPrice = 5000, SellPrice = 2500,
			WearableBy = Everyone,
			Power = 95, AuxPow = 30,
			Stat3 = 0x0A, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x4A, ItemType = Gun, DisplayName = "Gigasmasher",
			EnglishName = "Gsmasher", JapaneseName = "ギガスマッシャー",
			BuyPrice = 8000, SellPrice = 4000,
			WearableBy = Male|AllReligions,
			Power = 100, AuxPow = 8,
			Stat3 = 0x0E, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x4B, ItemType = Gun, DisplayName = "Kinitomo's gun",
			EnglishName = "AK-74u", JapaneseName = "くにとものじゅう",
			BuyPrice = 10000, SellPrice = 5000,
			WearableBy = Everyone,
			Power = 120, AuxPow = 40,
			Stat3 = 0x09, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x4C, ItemType = Gun, DisplayName = "M134 minigun",
			EnglishName = "Minigun", JapaneseName = "M134ミニガン",
			BuyPrice = 15000, SellPrice = 7500,
			WearableBy = Male|AllReligions,
			Power = 125, AuxPow = 0,
			Stat3 = 0x0F, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x4D, ItemType = Gun, DisplayName = "Railgun",
			EnglishName = "Railgun", JapaneseName = "レールガン",
			BuyPrice = 20000, SellPrice = 10000,
			WearableBy = Everyone,
			Power = 150, AuxPow = 35,
			Stat3 = 0x0A, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x4E, ItemType = Gun, DisplayName = "Megiddo",
			EnglishName = "Megiddo", JapaneseName = "メギドファイア",
			BuyPrice = 30000, SellPrice = 15000,
			WearableBy = BothGenders|Law,
			Power = 160, AuxPow = 30,
			Stat3 = 0x0F, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x4F, ItemType = Gun, DisplayName = "Peacemaker",
			EnglishName = "Inverter", JapaneseName = "ピースメーカー",
			BuyPrice = 40000, SellPrice = 20000,
			WearableBy = BothGenders|Chaos,
			Power = 170, AuxPow = 5,
			Stat3 = 0x0E, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		// Ammo
		new Item {
			ID = 0x50, ItemType = Ammunition, DisplayName = "Bullets",
			EnglishName = "Bullets", JapaneseName = "つうじょうだん",
			BuyPrice = 15, SellPrice = 4,
			WearableBy = Everyone,
			Power = 2, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x01,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x51, ItemType = Ammunition, DisplayName = "Shotgun shells",
			EnglishName = "Buckshot", JapaneseName = "ショットシェル",
			BuyPrice = 40, SellPrice = 10,
			WearableBy = Everyone,
			Power = 10, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x01,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x52, ItemType = Ammunition, DisplayName = "Poisoned bullets",
			EnglishName = "PSN shot", JapaneseName = "どくばりだん",
			BuyPrice = 25, SellPrice = 6,
			WearableBy = Everyone,
			Power = 8, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x50, Stat8 = 0x00, Stat9 = 0x08, StatA = 0xFF, StatB = 0x0E,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x53, ItemType = Ammunition, DisplayName = "Nerve bullets",
			EnglishName = "NRV shot", JapaneseName = "しんけいだん",
			BuyPrice = 35, SellPrice = 8,
			WearableBy = Everyone,
			Power = 15, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x19, Stat8 = 0x40, Stat9 = 0x00, StatA = 0xFF, StatB = 0x0F,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x54, ItemType = Ammunition, DisplayName = "Cursed bullets",
			EnglishName = "CUR shot", JapaneseName = "のろいのだんがん",
			BuyPrice = 80, SellPrice = 20,
			WearableBy = Everyone,
			Power = 20, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x17, Stat8 = 0x00, Stat9 = 0x01, StatA = 0xFF, StatB = 0x09,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x55, ItemType = Ammunition, DisplayName = "Blessed bullets",
			EnglishName = "BLS shot", JapaneseName = "せいなるだんがん",
			BuyPrice = 70, SellPrice = 17,
			WearableBy = Everyone,
			Power = 9, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x15, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x08,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x56, ItemType = Ammunition, DisplayName = "Silver bullets",
			EnglishName = "Ag shot", JapaneseName = "ぎんのだんがん",
			BuyPrice = 100, SellPrice = 25,
			WearableBy = Everyone,
			Power = 16, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x16, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x08,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x57, ItemType = Ammunition, DisplayName = "Uranium slugs",
			EnglishName = "U slugs", JapaneseName = "ウラニウムだん",
			BuyPrice = 200, SellPrice = 50,
			WearableBy = Everyone,
			Power = 25, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x0E, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x01,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x58, ItemType = Ammunition, DisplayName = "Plutonium slugs",
			EnglishName = "Pu slugs", JapaneseName = "プルトニウムだん",
			BuyPrice = 300, SellPrice = 75,
			WearableBy = Everyone,
			Power = 30, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x0F, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x01,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x59, ItemType = Ammunition, DisplayName = "Magic shells",
			EnglishName = "MagShell", JapaneseName = "まりょくのたま",
			BuyPrice = 400, SellPrice = 100,
			WearableBy = Everyone,
			Power = 17, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x1F, Stat8 = 0x80, Stat9 = 0x00, StatA = 0xFF, StatB = 0x0F,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x5A, ItemType = Ammunition, DisplayName = "Medusa shells",
			EnglishName = "Medusas", JapaneseName = "メデューサのたま",
			BuyPrice = 600, SellPrice = 150,
			WearableBy = Everyone,
			Power = 28, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x41, Stat8 = 0x00, Stat9 = 0x20, StatA = 0xFF, StatB = 0x09,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x5B, ItemType = Ammunition, DisplayName = "Antimagic shells",
			EnglishName = "AntiMage", JapaneseName = "まふうじのたま",
			BuyPrice = 800, SellPrice = 200,
			WearableBy = Everyone,
			Power = 25, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x1E, Stat8 = 0x04, Stat9 = 0x00, StatA = 0xFF, StatB = 0x0F,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x5C, ItemType = Ammunition, DisplayName = "Flash slugs",
			EnglishName = "FlaShot", JapaneseName = "せんこうだん",
			BuyPrice = 1000, SellPrice = 250,
			WearableBy = Everyone,
			Power = 30, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x1A, Stat8 = 0x20, Stat9 = 0x00, StatA = 0xFF, StatB = 0x0F,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x5D, ItemType = Ammunition, DisplayName = "Happy shot",
			EnglishName = ":D Shot", JapaneseName = "ハッピーショット",
			BuyPrice = 1500, SellPrice = 375,
			WearableBy = Everyone,
			Power = 35, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x1C, Stat8 = 0x01, Stat9 = 0x00, StatA = 0xFF, StatB = 0x0F,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x5E, ItemType = Ammunition, DisplayName = "Bullets of Light",
			EnglishName = "LiteShot", JapaneseName = "ひかりのだんがん",
			BuyPrice = 0, SellPrice = 550,
			WearableBy = BothGenders|Law,
			Power = 40, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x01,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x5F, ItemType = Ammunition, DisplayName = "Bullets of Darkness",
			EnglishName = "DarkShot", JapaneseName = "やみのだんがん",
			BuyPrice = 0, SellPrice = 660,
			WearableBy = BothGenders|Chaos,
			Power = 40, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0xFF, StatB = 0x01,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		// Headgear
		new Item {
			ID = 0x60, ItemType = HeadGear, DisplayName = "Headgear",
			EnglishName = "Headgear", JapaneseName = "ヘッドギア",
			BuyPrice = 15, SellPrice = 7,
			WearableBy = Male|AllReligions,
			Power = 3, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x61, ItemType = HeadGear, DisplayName = "Full helmet",
			EnglishName = "FullHelm", JapaneseName = "フルヘルム",
			BuyPrice = 28, SellPrice = 14,
			WearableBy = Male|AllReligions,
			Power = 4, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x62, ItemType = HeadGear, DisplayName = "Fritz helmet",
			EnglishName = "FritzHlm", JapaneseName = "フリッツヘルム",
			BuyPrice = 40, SellPrice = 20,
			WearableBy = Male|AllReligions,
			Power = 6, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x63, ItemType = HeadGear, DisplayName = "Metal crown",
			EnglishName = "Fe Crown", JapaneseName = "メタルクラウン",
			BuyPrice = 60, SellPrice = 30,
			WearableBy = Female|AllReligions,
			Power = 6, AuxPow = 3,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 1, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x64, ItemType = HeadGear, DisplayName = "Dullachan helmet",
			EnglishName = "DullHelm", JapaneseName = "デュラハンヘルム",
			BuyPrice = 90, SellPrice = 45,
			WearableBy = Male|AllReligions,
			Power = 8, AuxPow = 1,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 1, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x65, ItemType = HeadGear, DisplayName = "Tricorne hat",
			EnglishName = "Tricorne", JapaneseName = "さんかくぼうし",
			BuyPrice = 100, SellPrice = 50,
			WearableBy = Female|AllReligions,
			Power = 8, AuxPow = 4,
			Stat3 = 0x05, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 2, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x66, ItemType = HeadGear, DisplayName = "Dark crown",
			EnglishName = "DarKrown", JapaneseName = "ダーククラウン",
			BuyPrice = 220, SellPrice = 110,
			WearableBy = Male|AllReligions,
			Power = 10, AuxPow = 3,
			Stat3 = 0x05, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 2, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x67, ItemType = HeadGear, DisplayName = "Demoneater helmet",
			EnglishName = "DeetHelm", JapaneseName = "おにくいカブト",
			BuyPrice = 240, SellPrice = 120,
			WearableBy = Female|AllReligions,
			Power = 10, AuxPow = 5,
			Stat3 = 0x0A, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 2, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x68, ItemType = HeadGear, DisplayName = "Spirit crest",
			EnglishName = "SpCrest", JapaneseName = "せいれいまえだて",
			BuyPrice = 400, SellPrice = 200,
			WearableBy = Female|AllReligions,
			Power = 12, AuxPow = 4,
			Stat3 = 0x03, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 2, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x69, ItemType = HeadGear, DisplayName = "Dragon helmet",
			EnglishName = "DragHelm", JapaneseName = "ドラゴンヘルム",
			BuyPrice = 600, SellPrice = 300,
			WearableBy = Male|AllReligions,
			Power = 14, AuxPow = 6,
			Stat3 = 0x0A, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 2, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x6A, ItemType = HeadGear, DisplayName = "Crimson helmet",
			EnglishName = "CrimHelm", JapaneseName = "くれないのかぶと",
			BuyPrice = 650, SellPrice = 325,
			WearableBy = Female|AllReligions,
			Power = 15, AuxPow = 5,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 2, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x6B, ItemType = HeadGear, DisplayName = "Puzzle ring",
			EnglishName = "PuzRing", JapaneseName = "ちえのわ",
			BuyPrice = 800, SellPrice = 400,
			WearableBy = Everyone,
			Power = 16, AuxPow = 9,
			Stat3 = 0x05, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 2, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x6C, ItemType = HeadGear, DisplayName = "Masquerade",
			EnglishName = "Masque", JapaneseName = "マスカレード",
			BuyPrice = 1000, SellPrice = 500,
			WearableBy = BothGenders|Law,
			Power = 13, AuxPow = 4,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 1, MAGBonus = 1, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x6D, ItemType = HeadGear, DisplayName = "Safe",
			EnglishName = "Safe", JapaneseName = "きんこ",
			BuyPrice = 1400, SellPrice = 700,
			WearableBy = BothGenders|Chaos,
			Power = 18, AuxPow = 0,
			Stat3 = 0x08, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 1, INTBonus = 0, MAGBonus = 0, VITBonus = 1, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x6E, ItemType = HeadGear, DisplayName = "Hermes' helmet",
			EnglishName = "HermHelm", JapaneseName = "ヘルメスヘルム",
			BuyPrice = 1800, SellPrice = 900,
			WearableBy = Everyone,
			Power = 20, AuxPow = 2,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 1, LUKBonus = 1,
		},

		new Item {
			ID = 0x6F, ItemType = HeadGear, DisplayName = "Panzer helmet",
			EnglishName = "PanzHelm", JapaneseName = "パンツァーヘルム",
			BuyPrice = 3000, SellPrice = 1500,
			WearableBy = Female|AllReligions,
			Power = 24, AuxPow = 6,
			Stat3 = 0x07, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 2, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x70, ItemType = HeadGear, DisplayName = "Jagd helmet",
			EnglishName = "JagdHelm", JapaneseName = "ヤクトヘルム",
			BuyPrice = 3600, SellPrice = 1800,
			WearableBy = Male|AllReligions,
			Power = 25, AuxPow = 7,
			Stat3 = 0x07, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 2, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x71, ItemType = HeadGear, DisplayName = "Sturm helmet",
			EnglishName = "SturmHat", JapaneseName = "シュツルムヘルム",
			BuyPrice = 4000, SellPrice = 2000,
			WearableBy = Female|AllReligions,
			Power = 27, AuxPow = 7,
			Stat3 = 0x0B, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 2, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x72, ItemType = HeadGear, DisplayName = "Magician's mask",
			EnglishName = "MageMask", JapaneseName = "まどうしのマスク",
			BuyPrice = 0, SellPrice = 7500,
			WearableBy = BothGenders|Law,
			Power = 29, AuxPow = 27,
			Stat3 = 0x0B, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x01, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 3, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x73, ItemType = HeadGear, DisplayName = "Moonbeam string",
			EnglishName = "Moonbeam", JapaneseName = "つきかげのひも",
			BuyPrice = 0, SellPrice = 2000,
			WearableBy = BothGenders|Chaos,
			Power = 26, AuxPow = 30,
			Stat3 = 0x0D, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x01, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 3, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x74, ItemType = HeadGear, DisplayName = "Suwa Hossho's helmet",
			EnglishName = "SuwaHelm", JapaneseName = "すわほっしょう",
			BuyPrice = 0, SellPrice = 2500,
			WearableBy = BothGenders|Neutral,
			Power = 30, AuxPow = 26,
			Stat3 = 0x04, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x01, StatA = 0x00, StatB = 0x00,
			STRBonus = 3, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x75, ItemType = HeadGear, DisplayName = "Jesus helmet",
			EnglishName = "JbusHelm", JapaneseName = "ジーザスヘルム",
			BuyPrice = 0, SellPrice = 3000,
			WearableBy = Male|Law,
			Power = 22, AuxPow = 9,
			Stat3 = 0x01, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 3, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x76, ItemType = HeadGear, DisplayName = "Tenma helmet",
			EnglishName = "Ten Helm", JapaneseName = "てんまのかぶと",
			BuyPrice = 0, SellPrice = 4000,
			WearableBy = Male|Chaos,
			Power = 24, AuxPow = 10,
			Stat3 = 0x02, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 3, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x77, ItemType = HeadGear, DisplayName = "Masakado's helmet",
			EnglishName = "MasaHelm", JapaneseName = "マサカドのかぶと",
			BuyPrice = 0, SellPrice = 5000,
			WearableBy = Male|Neutral,
			Power = 23, AuxPow = 12,
			Stat3 = 0x08, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 3, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		// Body armor
		new Item {
			ID = 0x78, ItemType = BodyGear, DisplayName = "Survival vest",
			EnglishName = "SurVest", JapaneseName = "サバイバーベスト",
			BuyPrice = 25, SellPrice = 12,
			WearableBy = Male|AllReligions,
			Power = 6, AuxPow = 2,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x79, ItemType = BodyGear, DisplayName = "Kevlar vest",
			EnglishName = "Kevlar", JapaneseName = "ケブラーベスト",
			BuyPrice = 45, SellPrice = 22,
			WearableBy = Male|AllReligions,
			Power = 8, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x7A, ItemType = BodyGear, DisplayName = "Fire guard",
			EnglishName = "Fire Grd", JapaneseName = "ファイアガード",
			BuyPrice = 100, SellPrice = 50,
			WearableBy = Male|AllReligions,
			Power = 13, AuxPow = 0,
			Stat3 = 0x01, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x7B, ItemType = BodyGear, DisplayName = "Thunder guard",
			EnglishName = "Thnd Grd", JapaneseName = "サンダーガード",
			BuyPrice = 140, SellPrice = 70,
			WearableBy = Male|AllReligions,
			Power = 14, AuxPow = 3,
			Stat3 = 0x04, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x7C, ItemType = BodyGear, DisplayName = "Highleg armor",
			EnglishName = "HL armor", JapaneseName = "ハイレグアーマー",
			BuyPrice = 120, SellPrice = 60,
			WearableBy = Female|AllReligions,
			Power = 15, AuxPow = 5,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x7D, ItemType = BodyGear, DisplayName = "Butterfly dress",
			EnglishName = "PapiDrss", JapaneseName = "アゲハドレス",
			BuyPrice = 250, SellPrice = 125,
			WearableBy = Female|AllReligions,
			Power = 13, AuxPow = 14,
			Stat3 = 0x09, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 2, LUKBonus = 0,
		},

		new Item {
			ID = 0x7E, ItemType = BodyGear, DisplayName = "Italian armor",
			EnglishName = "Lui Mail", JapaneseName = "イタリアーマー",
			BuyPrice = 370, SellPrice = 185,
			WearableBy = Male|AllReligions,
			Power = 17, AuxPow = 6,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 1,
		},

		new Item {
			ID = 0x7F, ItemType = BodyGear, DisplayName = "Tetrajammer",
			EnglishName = "4jammer", JapaneseName = "テトラジャマー",
			BuyPrice = 500, SellPrice = 250,
			WearableBy = Everyone,
			Power = 20, AuxPow = 9,
			Stat3 = 0x03, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 1, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x80, ItemType = BodyGear, DisplayName = "Haou's armor",
			EnglishName = "HaouBody", JapaneseName = "はおうのよろい",
			BuyPrice = 780, SellPrice = 390,
			WearableBy = Male|Chaos,
			Power = 25, AuxPow = 8,
			Stat3 = 0x07, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 2, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x81, ItemType = BodyGear, DisplayName = "Robe of Law",
			EnglishName = "Law Robe", JapaneseName = "ほうのころも",
			BuyPrice = 980, SellPrice = 490,
			WearableBy = BothGenders|Law,
			Power = 12, AuxPow = 12,
			Stat3 = 0x0D, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 2, INTBonus = 2, MAGBonus = 2, VITBonus = 2, SPDBonus = 2, LUKBonus = 2,
		},

		new Item {
			ID = 0x82, ItemType = BodyGear, DisplayName = "Dragon mail",
			EnglishName = "DragMail", JapaneseName = "ドラゴンメイル",
			BuyPrice = 1250, SellPrice = 625,
			WearableBy = Male|AllReligions,
			Power = 30, AuxPow = 15,
			Stat3 = 0x06, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 2, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x83, ItemType = BodyGear, DisplayName = "Crimson armor",
			EnglishName = "Red Mail", JapaneseName = "くれないのよろい",
			BuyPrice = 1420, SellPrice = 710,
			WearableBy = Female|AllReligions,
			Power = 32, AuxPow = 5,
			Stat3 = 0x03, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 2, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x84, ItemType = BodyGear, DisplayName = "Devil corset",
			EnglishName = "Corset", JapaneseName = "デビルコルセット",
			BuyPrice = 1900, SellPrice = 950,
			WearableBy = Female|AllReligions,
			Power = 38, AuxPow = 10,
			Stat3 = 0x05, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 2, LUKBonus = 0,
		},

		new Item {
			ID = 0x85, ItemType = BodyGear, DisplayName = "Black armor",
			EnglishName = "Blk Mail", JapaneseName = "しっこくのよろい",
			BuyPrice = 2400, SellPrice = 1200,
			WearableBy = Male|AllReligions,
			Power = 35, AuxPow = 15,
			Stat3 = 0x01, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 2,
		},

		new Item {
			ID = 0x86, ItemType = BodyGear, DisplayName = "Powered suit",
			EnglishName = "Pow Suit", JapaneseName = "パワードスーツ",
			BuyPrice = 2800, SellPrice = 1400,
			WearableBy = Everyone,
			Power = 20, AuxPow = 20,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 2, INTBonus = 2, MAGBonus = 2, VITBonus = 2, SPDBonus = 2, LUKBonus = 2,
		},

		new Item {
			ID = 0x87, ItemType = BodyGear, DisplayName = "Hakuma's armor",
			EnglishName = "HakuMail", JapaneseName = "はくまのよろい",
			BuyPrice = 3000, SellPrice = 1500,
			WearableBy = Male|AllReligions,
			Power = 40, AuxPow = 17,
			Stat3 = 0x02, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 2, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x88, ItemType = BodyGear, DisplayName = "Panzer suit",
			EnglishName = "PanzSuit", JapaneseName = "パンツァースーツ",
			BuyPrice = 3500, SellPrice = 1750,
			WearableBy = Female|AllReligions,
			Power = 46, AuxPow = 14,
			Stat3 = 0x07, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 1, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x89, ItemType = BodyGear, DisplayName = "Jagd armor",
			EnglishName = "JagdArmr", JapaneseName = "ヤクトアーマー",
			BuyPrice = 4000, SellPrice = 2000,
			WearableBy = Male|AllReligions,
			Power = 50, AuxPow = 12,
			Stat3 = 0x07, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 2, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x8A, ItemType = BodyGear, DisplayName = "Sturm suit",
			EnglishName = "SturmTop", JapaneseName = "シュツルムスーツ",
			BuyPrice = 5000, SellPrice = 2500,
			WearableBy = Female|AllReligions,
			Power = 56, AuxPow = 16,
			Stat3 = 0x07, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 2, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x8B, ItemType = BodyGear, DisplayName = "Earth mail",
			EnglishName = "DirtMail", JapaneseName = "アースメイル",
			BuyPrice = 8000, SellPrice = 4000,
			WearableBy = Everyone,
			Power = 65, AuxPow = 15,
			Stat3 = 0x09, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 2,
		},

		new Item {
			ID = 0x8C, ItemType = BodyGear, DisplayName = "Argama suit",
			EnglishName = "ArgaSuit", JapaneseName = "アーガマスーツ",
			BuyPrice = 10000, SellPrice = 5000,
			WearableBy = Everyone,
			Power = 66, AuxPow = 15,
			Stat3 = 0x05, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 1, MAGBonus = 3, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x8D, ItemType = BodyGear, DisplayName = "Jesus armor",
			EnglishName = "JbusArmr", JapaneseName = "ジーザスアーマー",
			BuyPrice = 12000, SellPrice = 6000,
			WearableBy = Male|Law,
			Power = 75, AuxPow = 20,
			Stat3 = 0x03, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 3, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x8E, ItemType = BodyGear, DisplayName = "Tenma armor",
			EnglishName = "Ten Mail", JapaneseName = "てんまのよろい",
			BuyPrice = 16000, SellPrice = 8000,
			WearableBy = Male|Chaos,
			Power = 79, AuxPow = 18,
			Stat3 = 0x06, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 3, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 1, LUKBonus = 0,
		},

		new Item {
			ID = 0x8F, ItemType = BodyGear, DisplayName = "Masakado's armor",
			EnglishName = "MasaMail", JapaneseName = "マサカドのよろい",
			BuyPrice = 0, SellPrice = 10000,
			WearableBy = Male|Neutral,
			Power = 86, AuxPow = 25,
			Stat3 = 0x0A, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 3, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		// Arms
		new Item {
			ID = 0x90, ItemType = ArmGear, DisplayName = "Leather glove",
			EnglishName = "Gloves", JapaneseName = "レザーグラブ",
			BuyPrice = 10, SellPrice = 5,
			WearableBy = Male|AllReligions,
			Power = 1, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x91, ItemType = ArmGear, DisplayName = "Rivet knuckle",
			EnglishName = "Rivets", JapaneseName = "リベットナックル",
			BuyPrice = 25, SellPrice = 12,
			WearableBy = Male|AllReligions,
			Power = 2, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x92, ItemType = ArmGear, DisplayName = "Kaiser knuckle",
			EnglishName = "Kaisers", JapaneseName = "カイザーナックル",
			BuyPrice = 40, SellPrice = 20,
			WearableBy = Male|AllReligions,
			Power = 3, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x93, ItemType = ArmGear, DisplayName = "Gauntlet",
			EnglishName = "Gauntlet", JapaneseName = "ガントレット",
			BuyPrice = 45, SellPrice = 15,
			WearableBy = Female|AllReligions,
			Power = 4, AuxPow = 1,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x94, ItemType = ArmGear, DisplayName = "Cyber arm",
			EnglishName = "CyberArm", JapaneseName = "サイバーアーム",
			BuyPrice = 120, SellPrice = 60,
			WearableBy = Everyone,
			Power = 5, AuxPow = 2,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 2, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x95, ItemType = ArmGear, DisplayName = "Iron claw",
			EnglishName = "IronClaw", JapaneseName = "アイアンクロー",
			BuyPrice = 170, SellPrice = 85,
			WearableBy = Male|AllReligions,
			Power = 6, AuxPow = 4,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 1, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x96, ItemType = ArmGear, DisplayName = "Atlas gauntlet",
			EnglishName = "AtlasMit", JapaneseName = "アトラスのこて",
			BuyPrice = 230, SellPrice = 115,
			WearableBy = Male|AllReligions,
			Power = 7, AuxPow = 3,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 1, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x97, ItemType = ArmGear, DisplayName = "Noble gauntlet",
			EnglishName = "NobleMit", JapaneseName = "きしんのこて",
			BuyPrice = 450, SellPrice = 275,
			WearableBy = Everyone,
			Power = 7, AuxPow = 5,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 1, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x98, ItemType = ArmGear, DisplayName = "Draupnir",
			EnglishName = "Draupnir", JapaneseName = "ドラウプニル",
			BuyPrice = 500, SellPrice = 250,
			WearableBy = Male|AllReligions,
			Power = 8, AuxPow = 7,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 1, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x99, ItemType = ArmGear, DisplayName = "Crimson gauntlet",
			EnglishName = "CrimHand", JapaneseName = "くれないのこて",
			BuyPrice = 950, SellPrice = 475,
			WearableBy = Female|AllReligions,
			Power = 10, AuxPow = 5,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 2, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x9A, ItemType = ArmGear, DisplayName = "Panzer fist",
			EnglishName = "PanzFist", JapaneseName = "パンツァフィスト",
			BuyPrice = 1200, SellPrice = 600,
			WearableBy = Female|AllReligions,
			Power = 12, AuxPow = 6,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 1, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x9B, ItemType = ArmGear, DisplayName = "Jagd glove",
			EnglishName = "JagdMitt", JapaneseName = "ヤクトグラブ",
			BuyPrice = 1400, SellPrice = 700,
			WearableBy = Male|AllReligions,
			Power = 11, AuxPow = 6,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 2, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x9C, ItemType = ArmGear, DisplayName = "Sturm glove",
			EnglishName = "SturmMit", JapaneseName = "シュツルムグラブ",
			BuyPrice = 2000, SellPrice = 1000,
			WearableBy = Female|AllReligions,
			Power = 13, AuxPow = 6,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x9D, ItemType = ArmGear, DisplayName = "Jesus glove",
			EnglishName = "JbusMitt", JapaneseName = "ジーザスグラブ",
			BuyPrice = 1800, SellPrice = 900,
			WearableBy = Male|Law,
			Power = 15, AuxPow = 9,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 3, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x9E, ItemType = ArmGear, DisplayName = "Tenma gauntlet",
			EnglishName = "Ten Mitt", JapaneseName = "てんまのこて",
			BuyPrice = 3000, SellPrice = 1500,
			WearableBy = Male|Chaos,
			Power = 18, AuxPow = 8,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 3, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0x9F, ItemType = ArmGear, DisplayName = "Masakado's gauntlet",
			EnglishName = "MasaGlov", JapaneseName = "マサカドのこて",
			BuyPrice = 6000, SellPrice = 3000,
			WearableBy = Male|Neutral,
			Power = 20, AuxPow = 10,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 3, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		// Legs
		new Item {
			ID = 0xA0, ItemType = LegGear, DisplayName = "Leather boots",
			EnglishName = "WorkBoot", JapaneseName = "レザーブーツ",
			BuyPrice = 18, SellPrice = 9,
			WearableBy = Male|AllReligions,
			Power = 1, AuxPow = 3,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0xA1, ItemType = LegGear, DisplayName = "Combat boots",
			EnglishName = "ArmyBoot", JapaneseName = "コンバットブーツ",
			BuyPrice = 30, SellPrice = 15,
			WearableBy = Male|AllReligions,
			Power = 2, AuxPow = 4,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0xA2, ItemType = LegGear, DisplayName = "Rider boots",
			EnglishName = "Riders", JapaneseName = "ライダーブーツ",
			BuyPrice = 70, SellPrice = 35,
			WearableBy = Male|AllReligions,
			Power = 3, AuxPow = 5,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 0, LUKBonus = 0,
		},

		new Item {
			ID = 0xA3, ItemType = LegGear, DisplayName = "Jet boots",
			EnglishName = "JetBoots", JapaneseName = "ジェットブーツ",
			BuyPrice = 120, SellPrice = 60,
			WearableBy = Male|AllReligions,
			Power = 4, AuxPow = 8,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 1, LUKBonus = 0,
		},

		new Item {
			ID = 0xA4, ItemType = LegGear, DisplayName = "Sky heels",
			EnglishName = "SkyHeels", JapaneseName = "スカイヒール",
			BuyPrice = 160, SellPrice = 80,
			WearableBy = Female|AllReligions,
			Power = 5, AuxPow = 12,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 1, LUKBonus = 0,
		},

		new Item {
			ID = 0xA5, ItemType = LegGear, DisplayName = "Metal boots",
			EnglishName = "IronBoot", JapaneseName = "メタルブーツ",
			BuyPrice = 500, SellPrice = 250,
			WearableBy = Male|AllReligions,
			Power = 12, AuxPow = 0,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 1, LUKBonus = 0,
		},

		new Item {
			ID = 0xA6, ItemType = LegGear, DisplayName = "Dancing heels",
			EnglishName = "TapShoes", JapaneseName = "ダンシングヒール",
			BuyPrice = 870, SellPrice = 435,
			WearableBy = Female|AllReligions,
			Power = 7, AuxPow = 15,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 1, LUKBonus = 0,
		},

		new Item {
			ID = 0xA7, ItemType = LegGear, DisplayName = "Dragon boots",
			EnglishName = "DragBoot", JapaneseName = "ドラゴンブーツ",
			BuyPrice = 1100, SellPrice = 550,
			WearableBy = Male|AllReligions,
			Power = 4, AuxPow = 10,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 2, LUKBonus = 0,
		},

		new Item {
			ID = 0xA8, ItemType = LegGear, DisplayName = "Musha greaves",
			EnglishName = "MushaLeg", JapaneseName = "むしゃのぐそく",
			BuyPrice = 1550, SellPrice = 775,
			WearableBy = Male|AllReligions,
			Power = 14, AuxPow = 6,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 2, LUKBonus = 0,
		},

		new Item {
			ID = 0xA9, ItemType = LegGear, DisplayName = "Crimson greaves",
			EnglishName = "CrimLegs", JapaneseName = "くれないのぐそく",
			BuyPrice = 1450, SellPrice = 725,
			WearableBy = Female|AllReligions,
			Power = 9, AuxPow = 20,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 2, LUKBonus = 0,
		},

		new Item {
			ID = 0xAA, ItemType = LegGear, DisplayName = "Panzer legs",
			EnglishName = "PanzLegs", JapaneseName = "パンツァーレッグ",
			BuyPrice = 1700, SellPrice = 850,
			WearableBy = Female|AllReligions,
			Power = 10, AuxPow = 14,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 2, LUKBonus = 0,
		},

		new Item {
			ID = 0xAB, ItemType = LegGear, DisplayName = "Jagd legs",
			EnglishName = "JagdLegs", JapaneseName = "ヤクトレッグ",
			BuyPrice = 2100, SellPrice = 1050,
			WearableBy = Male|AllReligions,
			Power = 12, AuxPow = 15,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 2, LUKBonus = 0,
		},

		new Item {
			ID = 0xAC, ItemType = LegGear, DisplayName = "Sturm legs",
			EnglishName = "SturmLeg", JapaneseName = "シュツルムレッグ",
			BuyPrice = 2800, SellPrice = 1400,
			WearableBy = Female|AllReligions,
			Power = 11, AuxPow = 15,
			Stat3 = 0x00, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 3, LUKBonus = 0,
		},

		new Item {
			ID = 0xAD, ItemType = LegGear, DisplayName = "Jesus legs",
			EnglishName = "JbusLegs", JapaneseName = "ジーザスレッグ",
			BuyPrice = 1000, SellPrice = 500,
			WearableBy = Male|Law,
			Power = 12, AuxPow = 16,
			Stat3 = 0x07, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 3, LUKBonus = 0,
		},

		new Item {
			ID = 0xAE, ItemType = LegGear, DisplayName = "Tenma greaves",
			EnglishName = "Ten Legs", JapaneseName = "てんまのぐそく",
			BuyPrice = 2000, SellPrice = 1000,
			WearableBy = Male|Chaos,
			Power = 15, AuxPow = 17,
			Stat3 = 0x07, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 3, LUKBonus = 0,
		},

		new Item {
			ID = 0xAF, ItemType = LegGear, DisplayName = "Masakado's greaves",
			EnglishName = "MasaLegs", JapaneseName = "マサカドのぐそく",
			BuyPrice = 3000, SellPrice = 1500,
			WearableBy = Male|Neutral,
			Power = 16, AuxPow = 16,
			Stat3 = 0x0B, Stat7 = 0x00, Stat8 = 0x00, Stat9 = 0x00, StatA = 0x00, StatB = 0x00,
			STRBonus = 0, INTBonus = 0, MAGBonus = 0, VITBonus = 0, SPDBonus = 3, LUKBonus = 0,
		},

		// Use items
		new Item {
			ID = 0xB0, ItemType = UseItem, DisplayName = "Ointment",
			EnglishName = "Ointment", JapaneseName = "きずぐすり",
			BuyPrice = 4, SellPrice = 1,
		},

		new Item {
			ID = 0xB1, ItemType = UseItem, DisplayName = "Gyoutan",
			EnglishName = "Gyoutan", JapaneseName = "ぎゅうおうたん",
			BuyPrice = 10, SellPrice = 2,
		},

		new Item {
			ID = 0xB2, ItemType = UseItem, DisplayName = "Magic stone",
			EnglishName = "Magstone", JapaneseName = "ませき",
			BuyPrice = 100, SellPrice = 8,
		},

		new Item {
			ID = 0xB3, ItemType = UseItem, DisplayName = "Muscle drink",
			EnglishName = "Gatorade", JapaneseName = "マッスルドリンコ",
			BuyPrice = 40, SellPrice = 10,
		},

		new Item {
			ID = 0xB4, ItemType = UseItem, DisplayName = "Orb",
			EnglishName = "Orb", JapaneseName = "ほうぎょく",
			BuyPrice = 750, SellPrice = 50,
		},

		new Item {
			ID = 0xB5, ItemType = UseItem, DisplayName = "Hiranya",
			EnglishName = "Hiranya", JapaneseName = "ヒランヤ",
			BuyPrice = 60, SellPrice = 15,
		},

		new Item {
			ID = 0xB6, ItemType = UseItem, DisplayName = "Dis-poison",
			EnglishName = "Dis-pois", JapaneseName = "ディスポイズン",
			BuyPrice = 4, SellPrice = 1,
		},

		new Item {
			ID = 0xB7, ItemType = UseItem, DisplayName = "Dis-paralyze",
			EnglishName = "Dis-para", JapaneseName = "ディスパライズ",
			BuyPrice = 5, SellPrice = 1,
		},

		new Item {
			ID = 0xB8, ItemType = UseItem, DisplayName = "De-stone",
			EnglishName = "Dis-rock", JapaneseName = "ディストーン",
			BuyPrice = 10, SellPrice = 2,
		},

		new Item {
			ID = 0xB9, ItemType = UseItem, DisplayName = "Soma",
			EnglishName = "Soma", JapaneseName = "ソーマ",
			BuyPrice = 1000, SellPrice = 80,
		},

		new Item {
			ID = 0xBA, ItemType = UseItem, DisplayName = "Gold pill",
			EnglishName = "GoldPill", JapaneseName = "きんたん",
			BuyPrice = 70, SellPrice = 17,
		},

		new Item {
			ID = 0xBB, ItemType = UseItem, DisplayName = "Soul incense",
			EnglishName = "SoulBalm", JapaneseName = "はんごんこう",
			BuyPrice = 400, SellPrice = 100,
		},

		new Item {
			ID = 0xBC, ItemType = UseItem, DisplayName = "Magic bottle",
			EnglishName = "Bottle", JapaneseName = "まほうびん",
			BuyPrice = 48, SellPrice = 12,
		},

		// Incense
		new Item {
			ID = 0xBD, ItemType = Incense, DisplayName = "Strength incense",
			EnglishName = "STR balm", JapaneseName = "つよさのこう",
			BuyPrice = 7500, SellPrice = 5,
		},

		new Item {
			ID = 0xBE, ItemType = Incense, DisplayName = "Intelligence incense",
			EnglishName = "INT balm", JapaneseName = "ちえのこう",
			BuyPrice = 7500, SellPrice = 5,
		},

		new Item {
			ID = 0xBF, ItemType = Incense, DisplayName = "Magic incense",
			EnglishName = "MAG balm", JapaneseName = "まりょくのこう",
			BuyPrice = 7500, SellPrice = 5,
		},

		new Item {
			ID = 0xC0, ItemType = Incense, DisplayName = "Stamina incense",
			EnglishName = "VIT balm", JapaneseName = "たいりょくのこう",
			BuyPrice = 7500, SellPrice = 5,
		},

		new Item {
			ID = 0xC1, ItemType = Incense, DisplayName = "Speed incense",
			EnglishName = "SPD balm", JapaneseName = "はやさのこう",
			BuyPrice = 7500, SellPrice = 5,
		},

		new Item {
			ID = 0xC2, ItemType = Incense, DisplayName = "Luck incense",
			EnglishName = "LUK balm", JapaneseName = "うんのこう",
			BuyPrice = 7500, SellPrice = 5,
		},

		// Use weapons
		new Item {
			ID = 0xC3, ItemType = UseWeapon, DisplayName = "Molotov cocktail",
			EnglishName = "Molotov", JapaneseName = "かえんびん",
			BuyPrice = 2, SellPrice = 1,
		},

		new Item {
			ID = 0xC4, ItemType = UseWeapon, DisplayName = "Hand grenade",
			EnglishName = "Grenade", JapaneseName = "ハンドグレネード",
			BuyPrice = 15, SellPrice = 3,
		},

		new Item {
			ID = 0xC5, ItemType = UseWeapon, DisplayName = "Stinger",
			EnglishName = "Stinger", JapaneseName = "スティンガー",
			BuyPrice = 55, SellPrice = 18,
		},

		new Item {
			ID = 0xC6, ItemType = UseWeapon, DisplayName = "Dragon ATM",
			EnglishName = "FGM-77", JapaneseName = "ドラゴンATM",
			BuyPrice = 120, SellPrice = 30,
		},

		new Item {
			ID = 0xC7, ItemType = UseWeapon, DisplayName = "Poison bottle",
			EnglishName = "PSN jar", JapaneseName = "どくやくびん",
			BuyPrice = 10, SellPrice = 2,
		},

		new Item {
			ID = 0xC8, ItemType = UseWeapon, DisplayName = "Agirao stone",
			EnglishName = "Agiro St", JapaneseName = "アギラオストーン",
			BuyPrice = 16, SellPrice = 4,
		},

		new Item {
			ID = 0xC9, ItemType = UseWeapon, DisplayName = "Maha agi stone",
			EnglishName = "MhAgi St", JapaneseName = "マハラギストーン",
			BuyPrice = 15, SellPrice = 3,
		},

		new Item {
			ID = 0xCA, ItemType = UseWeapon, DisplayName = "Jionga stone",
			EnglishName = "JiongaSt", JapaneseName = "ジオンガストーン",
			BuyPrice = 13, SellPrice = 3,
		},

		new Item {
			ID = 0xCB, ItemType = UseWeapon, DisplayName = "Maha zio stone",
			EnglishName = "MhZio St", JapaneseName = "マハジオストーン",
			BuyPrice = 18, SellPrice = 5,
		},

		new Item {
			ID = 0xCC, ItemType = UseWeapon, DisplayName = "Maha bufu stone",
			EnglishName = "MhBufuSt", JapaneseName = "マハブフストーン",
			BuyPrice = 17, SellPrice = 4,
		},

		// Artifacts
		new Item {
			ID = 0xCD, ItemType = Artifact, DisplayName = "Holy water",
			EnglishName = "Holy H2O", JapaneseName = "せいすい",
			BuyPrice = 11, SellPrice = 3,
		},

		new Item {
			ID = 0xCE, ItemType = Artifact, DisplayName = "Soul returner",
			EnglishName = "SoulRet", JapaneseName = "たまがえり",
			BuyPrice = 40, SellPrice = 10,
		},

		new Item {
			ID = 0xCF, ItemType = Artifact, DisplayName = "Hamaya",
			EnglishName = "HamaDart", JapaneseName = "はまや",
			BuyPrice = 30, SellPrice = 8,
		},

		new Item {
			ID = 0xD0, ItemType = Artifact, DisplayName = "Hell soul",
			EnglishName = "HellSoul", JapaneseName = "じごくだま",
			BuyPrice = 28, SellPrice = 7,
		},

		new Item {
			ID = 0xD1, ItemType = Artifact, DisplayName = "Charm",
			EnglishName = "Charm", JapaneseName = "チャーム",
			BuyPrice = 16, SellPrice = 4,
		},

		new Item {
			ID = 0xD2, ItemType = Artifact, DisplayName = "Poison arrow",
			EnglishName = "PSN Dart", JapaneseName = "どくや",
			BuyPrice = 9, SellPrice = 2,
		},

		new Item {
			ID = 0xD3, ItemType = Artifact, DisplayName = "Hikobari",
			EnglishName = "Hikobari", JapaneseName = "ひこうばり",
			BuyPrice = 13, SellPrice = 4,
		},

		new Item {
			ID = 0xD4, ItemType = Artifact, DisplayName = "Angel hair",
			EnglishName = "AnglHair", JapaneseName = "エンゼルヘアー",
			BuyPrice = 4800, SellPrice = 120,
		},

		new Item {
			ID = 0xD5, ItemType = Artifact, DisplayName = "Ashura hand",
			EnglishName = "AshuHand", JapaneseName = "アシュラのて",
			BuyPrice = 4800, SellPrice = 120,
		},

		new Item {
			ID = 0xD6, ItemType = Artifact, DisplayName = "Pentagram",
			EnglishName = "5pt star", JapaneseName = "ペンタグラム",
			BuyPrice = 40, SellPrice = 10,
		},

		new Item {
			ID = 0xD7, ItemType = Artifact, DisplayName = "Segaki rice",
			EnglishName = "Rice", JapaneseName = "せがきまい",
			BuyPrice = 36, SellPrice = 9,
		},

		new Item {
			ID = 0xD8, ItemType = Artifact, DisplayName = "Kodokuzara",
			EnglishName = "Kodokuza", JapaneseName = "こどくざら",
			BuyPrice = 16, SellPrice = 4,
		},

		new Item {
			ID = 0xD9, ItemType = Artifact, DisplayName = "Smoke bomb",
			EnglishName = "SmokBomb", JapaneseName = "えんまくだん",
			BuyPrice = 4, SellPrice = 1,
		},

		new Item {
			ID = 0xDA, ItemType = Artifact, DisplayName = "Nyorai statue",
			EnglishName = "Nyor Fig", JapaneseName = "にょらいぞう",
			BuyPrice = 12, SellPrice = 30,
		},

		new Item {
			ID = 0xDB, ItemType = Artifact, DisplayName = "Amida beads",
			EnglishName = "Amida", JapaneseName = "あみだじゅず",
			BuyPrice = 54, SellPrice = 14,
		},

		new Item {
			ID = 0xDC, ItemType = Artifact, DisplayName = "Rosary beads",
			EnglishName = "Rosary", JapaneseName = "ロザリオ",
			BuyPrice = 150, SellPrice = 38,
		},

		new Item {
			ID = 0xDD, ItemType = Artifact, DisplayName = "Amulet",
			EnglishName = "Amulet", JapaneseName = "アムレット",
			BuyPrice = 48, SellPrice = 12,
		},

		new Item {
			ID = 0xDE, ItemType = Artifact, DisplayName = "Talisman",
			EnglishName = "Talisman", JapaneseName = "タリスマン",
			BuyPrice = 50, SellPrice = 12,
		},

		new Item {
			ID = 0xDF, ItemType = Artifact, DisplayName = "Fuma bell",
			EnglishName = "FumaBell", JapaneseName = "ふうまのすず",
			BuyPrice = 400, SellPrice = 10,
		},

		new Item {
			ID = 0xE0, ItemType = Artifact, DisplayName = "Core shield",
			EnglishName = "CoreShld", JapaneseName = "コアシールド",
			BuyPrice = 2000, SellPrice = 10,
		},

		new Item {
			ID = 0xE1, ItemType = Artifact, DisplayName = "Gushing jar",
			EnglishName = "Gush Jar", JapaneseName = "わきみのつぼ",
			BuyPrice = 4000, SellPrice = 100,
		},

		new Item {
			ID = 0xE2, ItemType = Artifact, DisplayName = "Fortune slips",
			EnglishName = "Fortune", JapaneseName = "おみくじ",
			BuyPrice = 7, SellPrice = 2,
		},

		new Item {
			ID = 0xE3, ItemType = Artifact, DisplayName = "Indulgence",
			EnglishName = "Indulge", JapaneseName = "めんざいふ",
			BuyPrice = 12, SellPrice = 3,
		},

		// Gemstones
		// TODO come up with gem values? flat rate for all of them maybe? should they even be sold?
		new Item {
			ID = 0xE4, ItemType = Gemstone, DisplayName = "Garnet",
			EnglishName = "Garnet", JapaneseName = "ガーネット",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xE5, ItemType = Gemstone, DisplayName = "Amethyst",
			EnglishName = "Amethyst", JapaneseName = "アメジスト",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xE6, ItemType = Gemstone, DisplayName = "Aquamarine",
			EnglishName = "Aqua gem", JapaneseName = "アクアマリン",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xE7, ItemType = Gemstone, DisplayName = "Diamond",
			EnglishName = "Diamond", JapaneseName = "ダイヤモンド",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xE8, ItemType = Gemstone, DisplayName = "Emerald",
			EnglishName = "Emerald", JapaneseName = "エメラルド",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xE9, ItemType = Gemstone, DisplayName = "Pearl",
			EnglishName = "Pearl", JapaneseName = "パール",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xEA, ItemType = Gemstone, DisplayName = "Ruby",
			EnglishName = "Ruby", JapaneseName = "ルビー",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xEB, ItemType = Gemstone, DisplayName = "Onyx",
			EnglishName = "Onyx", JapaneseName = "オニキス",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xEC, ItemType = Gemstone, DisplayName = "Sapphire",
			EnglishName = "Sapphire", JapaneseName = "サファイア",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xED, ItemType = Gemstone, DisplayName = "Opal",
			EnglishName = "Opal", JapaneseName = "オパール",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xEE, ItemType = Gemstone, DisplayName = "Topaz",
			EnglishName = "Topaz", JapaneseName = "トパーズ",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xEF, ItemType = Gemstone, DisplayName = "Turquoise",
			EnglishName = "Turquois", JapaneseName = "ターコイズ",
			BuyPrice = 0, SellPrice = 0,
		},

		// Key items
		new Item {
			ID = 0xF0, ItemType = KeyItem, DisplayName = "ID card",
			EnglishName = "ID Card", JapaneseName = "IDカード",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xF1, ItemType = KeyItem, DisplayName = "Angel ring",
			EnglishName = "HolyRing", JapaneseName = "エンゼルリング",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xF2, ItemType = KeyItem, DisplayName = "Gizou ID card",
			EnglishName = "Fake ID", JapaneseName = "ぎぞうIDカード",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xF3, ItemType = KeyItem, DisplayName = "Box of bar matches",
			EnglishName = "Matches", JapaneseName = "BARのマッチ",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xF4, ItemType = KeyItem, DisplayName = "Golden apple",
			EnglishName = "Au Apple", JapaneseName = "おうごんのリンゴ",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xF5, ItemType = KeyItem, DisplayName = "Memory board",
			EnglishName = "PCB", JapaneseName = "メモリーボード",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xF6, ItemType = KeyItem, DisplayName = "Turtle shell",
			EnglishName = "Shell", JapaneseName = "きっこうのすず",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xF7, ItemType = KeyItem, DisplayName = "Octupus tentacle",
			EnglishName = "Tentacle", JapaneseName = "タコのふえ",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xF8, ItemType = KeyItem, DisplayName = "Slut's claw",
			EnglishName = "SutrClaw", JapaneseName = "スルトのつめ",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xF9, ItemType = KeyItem, DisplayName = "Astaroth's feather",
			EnglishName = "Feather", JapaneseName = "アスタロトのはね",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xFA, ItemType = KeyItem, DisplayName = "Ariok's fang",
			EnglishName = "A Fang", JapaneseName = "アリオクのきば",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xFB, ItemType = KeyItem, DisplayName = "Devil ring",
			EnglishName = "Dev Ring", JapaneseName = "デビルリング",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xFC, ItemType = KeyItem, DisplayName = "Belial vase",
			EnglishName = "BeliVase", JapaneseName = "ベリアルのつぼ",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xFD, ItemType = KeyItem, DisplayName = "King's fingerprint",
			EnglishName = "Door gem", JapaneseName = "しもんのぎょく",
			BuyPrice = 0, SellPrice = 0,
		},

		new Item {
			ID = 0xFE, ItemType = KeyItem, DisplayName = "Stack of cash",
			EnglishName = "Yen wad", JapaneseName = "￥のたば",
			BuyPrice = 0, SellPrice = 0,
		},

		// Placeholder
		new Item {
			ID = 0xFF, ItemType = NotAnItem, DisplayName = "null",
			EnglishName = "", JapaneseName = "",
			BuyPrice = 0, SellPrice = 0,
		},
	};

}
