namespace SMTRandoApp.Randomization;
internal class ItemShuffler {

	private readonly Item[] ListOfItems = new Item[0x100];
	private readonly ROMWriter rom;
	public ItemShuffler(ROMWriter r) {
		ListOfItems = Item.GetFreshList();
		rom = r;
	}

	public void RandomizeItemStats() {
		// TODO will need some level of balance when doing this
		// so that there's a nice distribution for each equipment type
	}

	private void ForAllEquipment(Action<Item> action) {
		foreach (var item in ListOfItems) {
			if (!item.IsEquipment) continue;

			action(item);
		}
	}

	public void ForAllRealItems(Action<Item> act) {
		foreach (var item in ListOfItems) {
			if (item.ItemType is ItemType.NotAnItem) continue;

			act(item);
		}
	}

	public void ForAllGenericItems(Action<Item> act) {
		foreach (var item in ListOfItems) {
			if (item.IsKeyItem) continue;

			act(item);
		}
	}


	public static readonly ShuffleOption[] ItemBonusShuffles = {
		new ("Vanilla", null),

		new ("Weak", rom => rom.Items.RandomizeItemBonuses(195, 200)),

		new ("Medium", rom => rom.Items.RandomizeItemBonuses(145, 150)),

		new ("Powerful", rom => rom.Items.RandomizeItemBonuses(65, 75)),

		new ("Chaotic", rom => rom.Items.RandomizeItemBonuses(0, 15)),
	};

	private void RandomizeItemBonuses(byte crunch, byte max) {
		ForAllEquipment(item => {
			item.STRBonus = GetEquipmentBonus();
			item.INTBonus = GetEquipmentBonus();
			item.VITBonus = GetEquipmentBonus();
			item.MAGBonus = GetEquipmentBonus();
			item.SPDBonus = GetEquipmentBonus();
			item.LUKBonus = GetEquipmentBonus();
		});

		byte GetEquipmentBonus() {
			int r = GetRandomInt(0, max) - crunch;
			r = r < 0 ? 0 : r;
			return (byte) (r & 0xF);
		}
	}

	public void WriteAllItemData() => ForAllGenericItems(item => {
		if (item.IsEquipment) {
			rom.Write8(EQUIPMENTSTATS + 12 * item.ID, item.GetStats());
		}

		rom.Write16i(SHOPPRICES + item.ID * 4, item.BuyPrice, item.SellPrice);
	});

	// Genders
	public static readonly ShuffleOption[] ItemGenderShuffles = {
		new ("Vanilla", null),

		new ("Egalitarian", rom => {
			rom.Items.ForAllEquipment(item => item.SetGender(TargetAudience.BothGenders));
		}),

		new ("Random", rom => {
			rom.Items.ForAllEquipment(item => {
				bool male = GetRandomBool();
				bool female = !male || GetRandomBool();

				TargetAudience gender = TargetAudience.NoOne;

				if (male) {
					gender |= TargetAudience.Male;
				}

				if (female) {
					gender |= TargetAudience.Female;
				}

				item.SetGender(gender);
			});
		}),

		new ("Neutered", rom => {
			rom.Items.ForAllEquipment(item => {
				TargetAudience gender = TargetAudience.NoOne;

				if (GetRandomBool()) {
					gender |= TargetAudience.Male;
				}

				if (GetRandomBool()) {
					gender |= TargetAudience.Female;
				}

				item.SetGender(gender);
			});
		}),
	};

	// Alignments
	public static readonly ShuffleOption[] ItemReligionShuffles = {
		new ("Vanilla", null),

		new ("Random", rom => {
			rom.Items.ForAllEquipment(item => {
				item.SetAffiliation(
					GetRandomInt(0, 3) switch {
						0 => TargetAudience.Law,
						1 => TargetAudience.Neutral,
						2 => TargetAudience.Chaos,
						_ => TargetAudience.AllReligions,
					}
				);
			});
		}),

		new ("Mixed", rom => {
			rom.Items.ForAllEquipment(item => {
				item.SetAffiliation((TargetAudience) GetRandomByte(0x01, 0x07)); // exclude 0x00 which is no alignment
			});
		}),

		new ("Chaotic", rom => {
			rom.Items.ForAllEquipment(item => {
				item.SetAffiliation((TargetAudience) GetRandomByte(0x00, 0x07));
			});
		}),
	};

	// Shop price
	public static readonly ShuffleOption[] ShopPriceShuffles = {
		new ("MSRP", null),

		new ("Fair", rom => rom.Items.ForAllGenericItems(item => item.CalculateFairPrice())),

		new ("Stingy", rom => {
			var (low, high) = GetShopMultipliers();
			 rom.Items.ForAllGenericItems(item => {
				item.CalculateFairPrice();

				item.SellPrice = item.SellPrice * low / 100;
				item.BuyPrice = item.BuyPrice * high / 100;
			});
		}),

		new ("Cheap", rom => {
			var (low, high) = GetShopMultipliers();
			rom.Items.ForAllGenericItems(item => {
				item.CalculateFairPrice();

				item.SellPrice = item.SellPrice * high / 100;
				item.BuyPrice = item.BuyPrice * low / 100;
			});
		}),

		new ("Random", rom => rom.Items.ForAllGenericItems(item => {
			item.CalculateFairPrice();

			item.SellPrice = item.SellPrice * GetRandomInt(50, 150) / 100;
			item.BuyPrice = item.BuyPrice * GetRandomInt(50, 150) / 100;
		})),

		new ("Chaotic", rom => rom.Items.ForAllGenericItems(item => {
			item.BuyPrice = GetRandomInt(1, 60000);
			item.SellPrice = GetRandomInt(1, 60000);
		})),
	};

	private static (int, int) GetShopMultipliers() {
		return (GetRandomInt(50, 70), GetRandomInt(120, 150));
	}

	public static readonly TranslateOption[] ItemNameTranslations = {
		new ("English", rom => rom.Items.ListOfItems.Select(item => item.Name = item.EnglishName).ToArray()),

		new ("Japanese", rom => rom.Items.ListOfItems.Select(item => item.Name = item.JapaneseName).ToArray()),
	};
}
