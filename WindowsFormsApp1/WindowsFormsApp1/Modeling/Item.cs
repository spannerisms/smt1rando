namespace SMTRandoApp.Modeling;

internal partial class Item {
	public const byte MaxRealItem = 0xEF;

	public byte ID { get; init; }

	public string Name { get; set; }
	public string JapaneseName { get; init; }
	public string EnglishName { get; init; }
	public string DisplayName { get; init; }

	public int BuyPrice { get; set; }
	public int SellPrice { get; set; }

	public bool IsEquipment { get; init; }
	public bool IsKeyItem { get; init; }

	private readonly ItemType itemtype;
	public ItemType ItemType {
		get => itemtype;

		init {
			itemtype = value;

			IsKeyItem = value is ItemType.NotAnItem or ItemType.NotAnItem;

			IsEquipment = value switch {
				ItemType.MeleeWeapon => true,
				ItemType.Gun => true,
				ItemType.Ammunition => true,
				ItemType.HeadGear => true,
				ItemType.BodyGear => true,
				ItemType.ArmGear => true,
				ItemType.LegGear => true,
				_ => false
			};

		}
	}

	public TargetAudience WearableBy { get; private set; }

	public byte Power { get; set; }
	public byte AuxPow { get; set; }
	public byte Stat3 { get; set; }
	public byte Stat7 { get; set; }
	public byte Stat8 { get; set; }
	public byte Stat9 { get; set; }
	public byte StatA { get; set; }
	public byte StatB { get; set; }

	private byte _STRBonus;
	public byte STRBonus { get => _STRBonus; set => _STRBonus = value.NibbleClamp(); }

	private byte _INTBonus;
	public byte INTBonus { get => _INTBonus; set => _INTBonus = value.NibbleClamp(); }

	private byte _MAGBonus;
	public byte MAGBonus { get => _MAGBonus; set => _MAGBonus = value.NibbleClamp(); }

	private byte _VITBonus;
	public byte VITBonus { get => _VITBonus; set => _VITBonus = value.NibbleClamp(); }

	private byte _SPDBonus;
	public byte SPDBonus { get => _SPDBonus; set => _SPDBonus = value.NibbleClamp(); }

	private byte _LUKBonus;
	public byte LUKBonus { get => _LUKBonus; set => _LUKBonus = value.NibbleClamp(); }

	private Item() {}

	private Item(Item copy) {
		var properties = GetType().GetProperties();

		foreach (var p in properties) {
			if (!p.CanWrite) continue;
			p.SetValue(this, p.GetValue(copy));
		}
	}

	// TODO
	public void CalculateFairPrice() {
		if (IsKeyItem) return;

		if (IsEquipment) {
			// TODO implement
			// TODO some logarithmic curve?
			SellPrice = BuyPrice / 20 * 10;
		} else {
			SellPrice = BuyPrice / 40 * 10;
		}
	}


	public static byte GetRandomRealItem() => GetRandomByte(0x00, MaxRealItem);

	public byte[] GetStats() {
		byte[] ret = new byte[0x0C];

		ret[0x0] = (byte) WearableBy;

		ret[0x1] = Power;
		ret[0x2] = AuxPow;

		ret[0x3] = Stat3;

		ret[0x4] = MergeNibbles(STRBonus, INTBonus);
		ret[0x5] = MergeNibbles(MAGBonus, VITBonus);
		ret[0x6] = MergeNibbles(SPDBonus, LUKBonus);

		ret[0x7] = Stat7;
		ret[0x8] = Stat8;
		ret[0x9] = Stat9;
		ret[0xA] = StatA;
		ret[0xB] = StatB;

		return ret;
	}

	public Item Clone() => new(this);

	public void SetAffiliation(TargetAudience newAffil) {
		WearableBy &= ~TargetAudience.AllReligions;
		WearableBy |= newAffil & TargetAudience.AllReligions;
	}

	public void SetGender(TargetAudience newSEX) {
		WearableBy &= ~TargetAudience.BothGenders;
		WearableBy |= newSEX & TargetAudience.BothGenders;
	}

	public static Item[] GetFreshList() => VanillaList.Select(p => p.Clone()).ToArray();

}
