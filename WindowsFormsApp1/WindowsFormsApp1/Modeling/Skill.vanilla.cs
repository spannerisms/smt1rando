using static SMTRandoApp.Modeling.SkillType;
using static SMTRandoApp.Modeling.StatusAffliction;
using static SMTRandoApp.Modeling.SkillElement;

namespace SMTRandoApp.Modeling;

internal partial class Skill {
	private static readonly Skill[] VanillaList = {
		new Skill {
			ID = 0x00, IsValid = true,
			EnglishName = "Agi", JapaneseName = "アギ",
			Damage = 23, Cost = 3, Prop0 = 0x42, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = Elemental, StatusInflicted = None,
		},

		new Skill {
			ID = 0x01, IsValid = true,
			EnglishName = "Agilao", JapaneseName = "アギラオ",
			Damage = 64, Cost = 7, Prop0 = 0x42, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = StrongElemental, StatusInflicted = None,
		},

		new Skill {
			ID = 0x02, IsValid = true,
			EnglishName = "Maragi", JapaneseName = "マハラギ",
			Damage = 19, Cost = 5, Prop0 = 0x42, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = ElementalMultiTarget, StatusInflicted = None,
		},

		new Skill {
			ID = 0x03, IsValid = true,
			EnglishName = "Maragion", JapaneseName = "マハラギオン",
			Damage = 50, Cost = 9, Prop0 = 0x42, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = StrongElementalMultiTarget, StatusInflicted = None,
		},

		new Skill {
			ID = 0x04, IsValid = true,
			EnglishName = "Bufu", JapaneseName = "ブフ",
			Damage = 15, Cost = 3, Prop0 = 0x43, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = Elemental, StatusInflicted = Freeze,
		},

		new Skill {
			ID = 0x05, IsValid = true,
			EnglishName = "Bufula", JapaneseName = "ブフーラ",
			Damage = 40, Cost = 8, Prop0 = 0x43, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = StrongElemental, StatusInflicted = Freeze,
		},

		new Skill {
			ID = 0x06, IsValid = true,
			EnglishName = "Mabufu", JapaneseName = "マハーブフ",
			Damage = 12, Cost = 6, Prop0 = 0x43, AccuracyClass = 12, Prop2 = 0x0,
			MoveType = ElementalMultiTarget, StatusInflicted = Freeze,
		},

		new Skill {
			ID = 0x07, IsValid = true,
			EnglishName = "Mabufula", JapaneseName = "マハブフーラ",
			Damage = 32, Cost = 11, Prop0 = 0x43, AccuracyClass = 12, Prop2 = 0x0,
			MoveType = StrongElementalMultiTarget, StatusInflicted = Freeze,
		},

		new Skill {
			ID = 0x08, IsValid = true,
			EnglishName = "Zio", JapaneseName = "ジオ",
			Damage = 19, Cost = 4, Prop0 = 0x44, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = Elemental, StatusInflicted = Shock,
		},

		new Skill {
			ID = 0x09, IsValid = true,
			EnglishName = "Zionga", JapaneseName = "ジオンガ",
			Damage = 55, Cost = 9, Prop0 = 0x44, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = StrongElemental, StatusInflicted = Shock,
		},

		new Skill {
			ID = 0x0A, IsValid = true,
			EnglishName = "Mazio", JapaneseName = "マハジオ",
			Damage = 16, Cost = 7, Prop0 = 0x44, AccuracyClass = 10, Prop2 = 0x0,
			MoveType = ElementalMultiTarget, StatusInflicted = Shock,
		},

		new Skill {
			ID = 0x0B, IsValid = true,
			EnglishName = "Mazionga", JapaneseName = "マハジオンガ",
			Damage = 41, Cost = 12, Prop0 = 0x44, AccuracyClass = 10, Prop2 = 0x0,
			MoveType = StrongElementalMultiTarget, StatusInflicted = Shock,
		},

		new Skill {
			ID = 0x0C, IsValid = true,
			EnglishName = "Zan", JapaneseName = "ザン",
			Damage = 18, Cost = 2, Prop0 = 0x45, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = Elemental, StatusInflicted = None,
		},

		new Skill {
			ID = 0x0D, IsValid = true,
			EnglishName = "Zanma", JapaneseName = "ザンマ",
			Damage = 50, Cost = 5, Prop0 = 0x45, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = StrongElemental, StatusInflicted = None,
		},

		new Skill {
			ID = 0x0E, IsValid = true,
			EnglishName = "Mazan", JapaneseName = "マハザン",
			Damage = 14, Cost = 4, Prop0 = 0x45, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = ElementalMultiTarget, StatusInflicted = None,
		},

		new Skill {
			ID = 0x0F, IsValid = true,
			EnglishName = "Mazanma", JapaneseName = "マハザンマ",
			Damage = 38, Cost = 7, Prop0 = 0x45, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = StrongElemental, StatusInflicted = None,
		},

		new Skill {
			ID = 0x10, IsValid = true,
			EnglishName = "Tentrafu", JapaneseName = "テンタラフー",
			Damage = 44, Cost = 14, Prop0 = 0x46, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = ElementalMultiTarget, StatusInflicted = Panic,
		},

		new Skill {
			ID = 0x11, IsValid = true,
			EnglishName = "Rimdora", JapaneseName = "リムドーラ",
			Damage = 80, Cost = 8, Prop0 = 0x45, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = ElementalMultiTarget, StatusInflicted = None,
		},

		new Skill {
			ID = 0x12, IsValid = true,
			EnglishName = "Megido", JapaneseName = "メギド",
			Damage = 70, Cost = 15, Prop0 = 0x47, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = ElementalMultiTarget, StatusInflicted = None,
		},

		new Skill {
			ID = 0x13, IsValid = true,
			EnglishName = "Megidola", JapaneseName = "メギドラオン",
			Damage = 85, Cost = 30, Prop0 = 0x47, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = StrongElementalMultiTarget, StatusInflicted = None,
		},

		new Skill {
			ID = 0x14, IsValid = true,
			EnglishName = "Matrapo", JapaneseName = "マトラポー",
			Damage = 12, Cost = 3, Prop0 = 0x47, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = ElementalMultiTarget, StatusInflicted = None,
		},

		new Skill {
			ID = 0x15, IsValid = true,
			EnglishName = "Hama", JapaneseName = "ハンマ",
			Damage = 16, Cost = 5, Prop0 = 0x48, AccuracyClass = 1, Prop2 = 0x0,
			MoveType = OHKO, StatusInflicted = Dying,
		},

		new Skill {
			ID = 0x16, IsValid = true,
			EnglishName = "Mahama", JapaneseName = "マハンマ",
			Damage = 12, Cost = 10, Prop0 = 0x48, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = OHKO, StatusInflicted = Dying,
		},

		new Skill {
			ID = 0x17, IsValid = true,
			EnglishName = "Mudo", JapaneseName = "ムド",
			Damage = 16, Cost = 3, Prop0 = 0x49, AccuracyClass = 1, Prop2 = 0x0,
			MoveType = OHKO, StatusInflicted = Dead,
		},

		new Skill {
			ID = 0x18, IsValid = true,
			EnglishName = "Mudoon", JapaneseName = "ムドオン",
			Damage = 12, Cost = 9, Prop0 = 0x49, AccuracyClass = 9, Prop2 = 0x0,
			MoveType = OHKO, StatusInflicted = Dead,
		},

		new Skill {
			ID = 0x19, IsValid = true,
			EnglishName = "Dormina", JapaneseName = "ドルミナー",
			Damage = 20, Cost = 3, Prop0 = 0x46, AccuracyClass = 11, Prop2 = 0x0,
			MoveType = Status, StatusInflicted = Sleep,
		},

		new Skill {
			ID = 0x1A, IsValid = true,
			EnglishName = "Shibaboo", JapaneseName = "シバブー",
			Damage = 28, Cost = 3, Prop0 = 0x4B, AccuracyClass = 7, Prop2 = 0x0,
			MoveType = Status, StatusInflicted = Bind,
		},

		new Skill {
			ID = 0x1B, IsValid = true,
			EnglishName = "Pulinpa", JapaneseName = "プリンパ",
			Damage = 22, Cost = 2, Prop0 = 0x46, AccuracyClass = 10, Prop2 = 0x0,
			MoveType = Status, StatusInflicted = Panic,
		},

		new Skill {
			ID = 0x1C, IsValid = true,
			EnglishName = "Hapirma", JapaneseName = "ハピルマ",
			Damage = 18, Cost = 2, Prop0 = 0x46, AccuracyClass = 11, Prop2 = 0x0,
			MoveType = Status, StatusInflicted = Happy,
		},

		new Skill {
			ID = 0x1D, IsValid = true,
			EnglishName = "MariKari", JapaneseName = "マリンカリン",
			Damage = 24, Cost = 6, Prop0 = 0x4A, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = Status, StatusInflicted = Charm,
		},

		new Skill {
			ID = 0x1E, IsValid = true,
			EnglishName = "Makajam", JapaneseName = "マカジャマ",
			Damage = 12, Cost = 4, Prop0 = 0x4A, AccuracyClass = 12, Prop2 = 0x0,
			MoveType = Status, StatusInflicted = Sealed,
		},

		new Skill {
			ID = 0x1F, IsValid = true,
			EnglishName = "Makatora", JapaneseName = "マカトランダ",
			Damage = 0, Cost = 2, Prop0 = 0x4A, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = Status, StatusInflicted = None,
		},

		new Skill {
			ID = 0x20, IsValid = true,
			EnglishName = "Taruna", JapaneseName = "タルンダ",
			Damage = 0, Cost = 4, Prop0 = 0x4A, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Status, StatusInflicted = None,
		},

		new Skill {
			ID = 0x21, IsValid = true,
			EnglishName = "Rakunda", JapaneseName = "ラクンダ",
			Damage = 0, Cost = 4, Prop0 = 0x4A, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Status, StatusInflicted = None,
		},

		new Skill {
			ID = 0x22, IsValid = true,
			EnglishName = "Sukunda", JapaneseName = "スクンダ",
			Damage = 0, Cost = 2, Prop0 = 0x4A, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Status, StatusInflicted = None,
		},

		new Skill {
			ID = 0x23, IsValid = true,
			EnglishName = "Tarukaja", JapaneseName = "タルカジャ",
			Damage = 0, Cost = 4, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Status, StatusInflicted = None,
		},

		new Skill {
			ID = 0x24, IsValid = true,
			EnglishName = "Rakukaja", JapaneseName = "ラクカジャ",
			Damage = 0, Cost = 4, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Status, StatusInflicted = None,
		},

		new Skill {
			ID = 0x25, IsValid = true,
			EnglishName = "Sukukaja", JapaneseName = "スクカジャ",
			Damage = 0, Cost = 2, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Status, StatusInflicted = None,
		},

		new Skill {
			ID = 0x26, IsValid = true,
			EnglishName = "Makazia", JapaneseName = "マカカジャ",
			Damage = 0, Cost = 4, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Status, StatusInflicted = None,
		},

		new Skill {
			ID = 0x27, IsValid = true,
			EnglishName = "Tetraja", JapaneseName = "テトラジャ",
			Damage = 0, Cost = 5, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Status, StatusInflicted = None,
		},

		new Skill {
			ID = 0x28, IsValid = true,
			EnglishName = "Makala", JapaneseName = "マカラカーン",
			Damage = 0, Cost = 6, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Status, StatusInflicted = None,
		},

		new Skill {
			ID = 0x29, IsValid = true,
			EnglishName = "Tetrakan", JapaneseName = "テトラカーン",
			Damage = 0, Cost = 6, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Status, StatusInflicted = None,
		},

		new Skill {
			ID = 0x2A, IsValid = true,
			EnglishName = "Dia", JapaneseName = "ディア",
			Damage = 0, Cost = 2, Prop0 = 0xCF, AccuracyClass = 0, Prop2 = 0x8,
			MoveType = Healing, StatusInflicted = None,
		},

		new Skill {
			ID = 0x2B, IsValid = true,
			EnglishName = "Diarama", JapaneseName = "ディアラマ",
			Damage = 0, Cost = 4, Prop0 = 0xCF, AccuracyClass = 0, Prop2 = 0x8,
			MoveType = Healing, StatusInflicted = None,
		},

		new Skill {
			ID = 0x2C, IsValid = true,
			EnglishName = "Diarahan", JapaneseName = "ディアラハン",
			Damage = 0, Cost = 8, Prop0 = 0xCF, AccuracyClass = 0, Prop2 = 0x8,
			MoveType = Healing, StatusInflicted = None,
		},

		new Skill {
			ID = 0x2D, IsValid = true,
			EnglishName = "Media", JapaneseName = "メディア",
			Damage = 0, Cost = 6, Prop0 = 0xCF, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Healing, StatusInflicted = None,
		},

		new Skill {
			ID = 0x2E, IsValid = true,
			EnglishName = "Medirama", JapaneseName = "メディアラハン",
			Damage = 0, Cost = 14, Prop0 = 0xCF, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Healing, StatusInflicted = None,
		},

		new Skill {
			ID = 0x2F, IsValid = true,
			EnglishName = "Patra", JapaneseName = "パトラ",
			Damage = 0, Cost = 2, Prop0 = 0xCF, AccuracyClass = 2, Prop2 = 0x8,
			MoveType = Healing, StatusInflicted = Happy|Panic|Sealed|Shock|Freeze|Bind|Sleep,
		},

		new Skill {
			ID = 0x30, IsValid = true,
			EnglishName = "Me Patra", JapaneseName = "ペンパトラ",
			Damage = 0, Cost = 4, Prop0 = 0xCF, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Healing, StatusInflicted = Happy|Panic|Sealed|Shock|Freeze|Bind|Sleep,
		},

		new Skill {
			ID = 0x31, IsValid = true,
			EnglishName = "Posomdi", JapaneseName = "ポズムディ",
			Damage = 0, Cost = 4, Prop0 = 0xCF, AccuracyClass = 2, Prop2 = 0x8,
			MoveType = Healing, StatusInflicted = Poison,
		},

		new Skill {
			ID = 0x32, IsValid = true,
			EnglishName = "Paraladi", JapaneseName = "パララディ",
			Damage = 0, Cost = 6, Prop0 = 0xCF, AccuracyClass = 2, Prop2 = 0x8,
			MoveType = Healing, StatusInflicted = Paralysis,
		},

		new Skill {
			ID = 0x33, IsValid = true,
			EnglishName = "Petradi", JapaneseName = "ペトラディ",
			Damage = 0, Cost = 10, Prop0 = 0xCF, AccuracyClass = 2, Prop2 = 0x8,
			MoveType = Healing, StatusInflicted = Petrify,
		},

		new Skill {
			ID = 0x34, IsValid = true,
			EnglishName = "Recarm", JapaneseName = "リカーム",
			Damage = 0, Cost = 12, Prop0 = 0xCF, AccuracyClass = 2, Prop2 = 0x8,
			MoveType = Healing, StatusInflicted = Dying,
		},

		new Skill {
			ID = 0x35, IsValid = true,
			EnglishName = "Sarecarm", JapaneseName = "サマリカーム",
			Damage = 0, Cost = 24, Prop0 = 0xCF, AccuracyClass = 2, Prop2 = 0x8,
			MoveType = Healing, StatusInflicted = Dying|Dead,
		},

		new Skill {
			ID = 0x36, IsValid = true,
			EnglishName = "Recarmda", JapaneseName = "リカームドラ",
			Damage = 0, Cost = 8, Prop0 = 0xCF, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Healing, StatusInflicted = None,
		},

		new Skill {
			ID = 0x37, IsValid = true,
			EnglishName = "Makatora", JapaneseName = "マカトラ",
			Damage = 0, Cost = 10, Prop0 = 0xCF, AccuracyClass = 0, Prop2 = 0x8,
			MoveType = Healing, StatusInflicted = None,
		},

		new Skill {
			ID = 0x38, IsValid = true,
			EnglishName = "Mapper", JapaneseName = "マッパー",
			Damage = 0, Cost = 2, Prop0 = 0x8F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Exploration, StatusInflicted = None,
		},

		new Skill {
			ID = 0x39, IsValid = true,
			EnglishName = "Toraest", JapaneseName = "トラエスト",
			Damage = 0, Cost = 6, Prop0 = 0x8F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Exploration, StatusInflicted = None,
		},

		new Skill {
			ID = 0x3A, IsValid = true,
			EnglishName = "Toraport", JapaneseName = "トラポート",
			Damage = 0, Cost = 6, Prop0 = 0x8F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Exploration, StatusInflicted = None,
		},

		new Skill {
			ID = 0x3B, IsValid = true,
			EnglishName = "Torafuri", JapaneseName = "トラフーリ",
			Damage = 0, Cost = 2, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Exploration, StatusInflicted = None,
		},

		new Skill {
			ID = 0x3C, IsValid = true,
			EnglishName = "Estoma", JapaneseName = "エストマ",
			Damage = 0, Cost = 6, Prop0 = 0x8F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Exploration, StatusInflicted = None,
		},

		new Skill {
			ID = 0x3D, IsValid = true,
			EnglishName = "Sabbath", JapaneseName = "サバトマ",
			Damage = 0, Cost = 8, Prop0 = 0xCF, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = SpecialStatusMove, StatusInflicted = None,
		},

		new Skill {
			ID = 0x3E, IsValid = true,
			EnglishName = "Sabbatma", JapaneseName = "サバトマオン",
			Damage = 0, Cost = 20, Prop0 = 0xCF, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = SpecialStatusMove, StatusInflicted = None,
		},

		new Skill {
			ID = 0x3F, IsValid = false,
			EnglishName = "Dropkick", JapaneseName = "ドロップキック",
			Damage = 30, Cost = 8, Prop0 = 0x45, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = SpecialSpell, StatusInflicted = None,
		},

		new Skill {
			ID = 0x40, IsValid = true,
			EnglishName = "ParaEye", JapaneseName = "パララアイ",
			Damage = 12, Cost = 2, Prop0 = 0x49, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Paralysis,
		},

		new Skill {
			ID = 0x41, IsValid = true,
			EnglishName = "PetraEye", JapaneseName = "ペトラアイ",
			Damage = 10, Cost = 4, Prop0 = 0x49, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Petrify,
		},

		new Skill {
			ID = 0x42, IsValid = true,
			EnglishName = "Hellway", JapaneseName = "しへのみち",
			Damage = 12, Cost = 8, Prop0 = 0x49, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Dead,
		},

		new Skill {
			ID = 0x43, IsValid = true,
			EnglishName = "Bloodsap", JapaneseName = "ブラッドスチール",
			Damage = 9, Cost = 8, Prop0 = 0x49, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Curse,
		},

		new Skill {
			ID = 0x44, IsValid = false,
			EnglishName = "Bael vex", JapaneseName = "バエルののろい",
			Damage = 6, Cost = 8, Prop0 = 0x49, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Fly,
		},

		new Skill {
			ID = 0x45, IsValid = true,
			EnglishName = "SexySexy", JapaneseName = "セクシーダンス",
			Damage = 12, Cost = 6, Prop0 = 0x4A, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Charm,
		},

		new Skill {
			ID = 0x46, IsValid = true,
			EnglishName = "Hap Step", JapaneseName = "ハッピーステップ",
			Damage = 22, Cost = 4, Prop0 = 0x4A, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Happy,
		},

		new Skill {
			ID = 0x47, IsValid = true,
			EnglishName = "Pharrell", JapaneseName = "しあわせのうた",
			Damage = 14, Cost = 4, Prop0 = 0x46, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Happy,
		},

		new Skill {
			ID = 0x48, IsValid = true,
			EnglishName = "Lullaby", JapaneseName = "こもりうた",
			Damage = 23, Cost = 6, Prop0 = 0x46, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Sleep,
		},

		new Skill {
			ID = 0x49, IsValid = true,
			EnglishName = "Panic", JapaneseName = "パニックボイス",
			Damage = 10, Cost = 2, Prop0 = 0x4B, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Panic,
		},

		new Skill {
			ID = 0x4A, IsValid = true,
			EnglishName = "Binding", JapaneseName = "バインドボイス",
			Damage = 9, Cost = 8, Prop0 = 0x4B, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Bind,
		},

		new Skill {
			ID = 0x4B, IsValid = true,
			EnglishName = "Oni kiss", JapaneseName = "あくまのキス",
			Damage = 20, Cost = 4, Prop0 = 0x49, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = None,
		},

		new Skill {
			ID = 0x4C, IsValid = true,
			EnglishName = "Oni kiss", JapaneseName = "あくまのキス",
			Damage = 22, Cost = 4, Prop0 = 0x49, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = None,
		},

		new Skill {
			ID = 0x4D, IsValid = true,
			EnglishName = "Mischief", JapaneseName = "デビルスマイル",
			Damage = 18, Cost = 8, Prop0 = 0x49, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = None,
		},

		new Skill {
			ID = 0x4E, IsValid = true,
			EnglishName = "Resfire", JapaneseName = "ファイアブレス",
			Damage = 60, Cost = 8, Prop0 = 0x42, AccuracyClass = 11, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = None,
		},

		new Skill {
			ID = 0x4F, IsValid = true,
			EnglishName = "Resice", JapaneseName = "アイスブレス",
			Damage = 38, Cost = 8, Prop0 = 0x43, AccuracyClass = 10, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Freeze,
		},

		new Skill {
			ID = 0x50, IsValid = true,
			EnglishName = "Resvenom", JapaneseName = "どくガスブレス",
			Damage = 32, Cost = 7, Prop0 = 0x45, AccuracyClass = 8, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Poison,
		},

		new Skill {
			ID = 0x51, IsValid = true,
			EnglishName = "Resfog", JapaneseName = "フォッグブレス",
			Damage = 10, Cost = 4, Prop0 = 0x46, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = None,
		},

		new Skill {
			ID = 0x52, IsValid = true,
			EnglishName = "Fireball", JapaneseName = "ファイアボール",
			Damage = 52, Cost = 5, Prop0 = 0x42, AccuracyClass = 7, Prop2 = 0x0,
			MoveType = SpecialSpell, StatusInflicted = None,
		},

		new Skill {
			ID = 0x53, IsValid = true,
			EnglishName = "Blitz", JapaneseName = "でんげき",
			Damage = 44, Cost = 6, Prop0 = 0x44, AccuracyClass = 7, Prop2 = 0x0,
			MoveType = SpecialSpell, StatusInflicted = Shock,
		},

		new Skill {
			ID = 0x54, IsValid = true,
			EnglishName = "Mortem", JapaneseName = "デスタッチ",
			Damage = 30, Cost = 4, Prop0 = 0x4A, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialSpell, StatusInflicted = None,
		},

		new Skill {
			ID = 0x55, IsValid = true,
			EnglishName = "Niagrala", JapaneseName = "みずのかべ",
			Damage = 0, Cost = 4, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = SpecialSpell, StatusInflicted = None,
		},

		new Skill {
			ID = 0x56, IsValid = true,
			EnglishName = "Bombosla", JapaneseName = "ほのおのかべ",
			Damage = 0, Cost = 4, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = SpecialSpell, StatusInflicted = None,
		},

		new Skill {
			ID = 0x57, IsValid = true,
			EnglishName = "Bite", JapaneseName = "かみつき",
			Damage = 3, Cost = 3, Prop0 = 0x4C, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = None,
		},

		new Skill {
			ID = 0x58, IsValid = true,
			EnglishName = "Envenom", JapaneseName = "どくかみつき",
			Damage = 3, Cost = 4, Prop0 = 0x4C, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Poison,
		},

		new Skill {
			ID = 0x59, IsValid = true,
			EnglishName = "Enpara", JapaneseName = "まひかみつき",
			Damage = 3, Cost = 5, Prop0 = 0x4C, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Paralysis,
		},

		new Skill {
			ID = 0x5A, IsValid = true,
			EnglishName = "Enpatra", JapaneseName = "せきかかみつき",
			Damage = 3, Cost = 6, Prop0 = 0x4C, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Petrify,
		},

		new Skill {
			ID = 0x5B, IsValid = true,
			EnglishName = "Encharm", JapaneseName = "みわくかみつき",
			Damage = 1, Cost = 5, Prop0 = 0x4C, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialStatusMove, StatusInflicted = Charm,
		},

		new Skill {
			ID = 0x5C, IsValid = true,
			EnglishName = "Slash", JapaneseName = "ひっかき",
			Damage = 2, Cost = 3, Prop0 = 0x4D, AccuracyClass = 1, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = None,
		},

		new Skill {
			ID = 0x5D, IsValid = true,
			EnglishName = "Sovenom", JapaneseName = "どくひっかき",
			Damage = 2, Cost = 5, Prop0 = 0x4D, AccuracyClass = 1, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = Poison,
		},

		new Skill {
			ID = 0x5E, IsValid = true,
			EnglishName = "Sopara", JapaneseName = "まひひっかき",
			Damage = 2, Cost = 8, Prop0 = 0x4D, AccuracyClass = 1, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = Paralysis,
		},

		new Skill {
			ID = 0x5F, IsValid = true,
			EnglishName = "Stinger", JapaneseName = "どくばり",
			Damage = 2, Cost = 2, Prop0 = 0x4E, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = Poison,
		},

		new Skill {
			ID = 0x60, IsValid = true,
			EnglishName = "Obtund", JapaneseName = "まひばり",
			Damage = 3, Cost = 4, Prop0 = 0x4E, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = Paralysis,
		},

		new Skill {
			ID = 0x61, IsValid = true,
			EnglishName = "Flutter", JapaneseName = "はばたき",
			Damage = 1, Cost = 4, Prop0 = 0x45, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = None,
		},

		new Skill {
			ID = 0x62, IsValid = true,
			EnglishName = "Tweedle", JapaneseName = "つくもばり",
			Damage = 2, Cost = 6, Prop0 = 0x4E, AccuracyClass = 9, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = None,
		},

		new Skill {
			ID = 0x63, IsValid = false,
			EnglishName = "Suplex", JapaneseName = "たいあたり",
			Damage = 4, Cost = 6, Prop0 = 0x4C, AccuracyClass = 3, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = None,
		},

		new Skill {
			ID = 0x64, IsValid = true,
			EnglishName = "Strangle", JapaneseName = "まきつき",
			Damage = 3, Cost = 5, Prop0 = 0x4C, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = Bind,
		},

		new Skill {
			ID = 0x65, IsValid = true,
			EnglishName = "Rampage", JapaneseName = "あばれまわり",
			Damage = 2, Cost = 7, Prop0 = 0x4C, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = None,
		},

		new Skill {
			ID = 0x66, IsValid = true,
			EnglishName = "Crush", JapaneseName = "おしつぶし",
			Damage = 5, Cost = 5, Prop0 = 0x4C, AccuracyClass = 2, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = None,
		},

		new Skill {
			ID = 0x67, IsValid = true,
			EnglishName = "Fatality", JapaneseName = "ひっさつ",
			Damage = 4, Cost = 6, Prop0 = 0x4D, AccuracyClass = 3, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = None,
		},

		new Skill {
			ID = 0x68, IsValid = true,
			EnglishName = "Tail", JapaneseName = "テール",
			Damage = 3, Cost = 9, Prop0 = 0x4D, AccuracyClass = 15, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = None,
		},

		new Skill {
			ID = 0x69, IsValid = true,
			EnglishName = "Contrite", JapaneseName = "かいしん",
			Damage = 3, Cost = 4, Prop0 = 0x4D, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = SpecialAttack, StatusInflicted = None,
		},

		new Skill {
			ID = 0x6A, IsValid = false,
			EnglishName = "x", JapaneseName = "x",
			Damage = 0, Cost = 0, Prop0 = 0x45, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Unused, StatusInflicted = None,
		},

		new Skill {
			ID = 0x6B, IsValid = false,
			EnglishName = "x", JapaneseName = "x",
			Damage = 0, Cost = 0, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Unused, StatusInflicted = None,
		},

		new Skill {
			ID = 0x6C, IsValid = false,
			EnglishName = "x", JapaneseName = "x",
			Damage = 8, Cost = 0, Prop0 = 0x4F, AccuracyClass = 0, Prop2 = 0x0,
			MoveType = Unused, StatusInflicted = None,
		},

		new Skill {
			ID = 0x6D, IsValid = false,
			EnglishName = "x", JapaneseName = "x",
			Damage = 10, Cost = 0, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Unused, StatusInflicted = None,
		},

		new Skill {
			ID = 0x6E, IsValid = false,
			EnglishName = "x", JapaneseName = "x",
			Damage = 0, Cost = 0, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Unused, StatusInflicted = None,
		},

		new Skill {
			ID = 0x6F, IsValid = false,
			EnglishName = "x", JapaneseName = "x",
			Damage = 0, Cost = 0, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Unused, StatusInflicted = None,
		},

		new Skill {
			ID = 0x70, IsValid = false,
			EnglishName = "x", JapaneseName = "x",
			Damage = 0, Cost = 0, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Unused, StatusInflicted = None,
		},

		new Skill {
			ID = 0x71, IsValid = false,
			EnglishName = "x", JapaneseName = "x",
			Damage = 0, Cost = 0, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Unused, StatusInflicted = None,
		},

		new Skill {
			ID = 0x72, IsValid = false,
			EnglishName = "x", JapaneseName = "x",
			Damage = 0, Cost = 0, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = Unused, StatusInflicted = None,
		},

		new Skill {
			ID = 0x73, IsValid = false,
			EnglishName = "Defend", JapaneseName = "まもる",
			Damage = 0, Cost = 0, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = PseudoMove, StatusInflicted = None,
		},

		new Skill {
			ID = 0x74, IsValid = false,
			EnglishName = "Retreat", JapaneseName = "にける",
			Damage = 0, Cost = 0, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = PseudoMove, StatusInflicted = None,
		},

		new Skill {
			ID = 0x75, IsValid = false,
			EnglishName = "Rally", JapaneseName = "なかまよび",
			Damage = 0, Cost = 0, Prop0 = 0x4F, AccuracyClass = 15, Prop2 = 0xF,
			MoveType = PseudoMove, StatusInflicted = None,
		},
	};
}