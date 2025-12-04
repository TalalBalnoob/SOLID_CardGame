using CardGame.Cards;

namespace CardGame.Game;

public static class CardFactory {
	public static BaseCard Create(string cardKey) {
		return cardKey switch {
			"FireDragon" => new RegularMonsterCard("Fire Dragon", "Burns everything.", 8, 5),
			"IceWolf" => new RegularMonsterCard("Ice Wolf", "Freezing bite.", 5, 3),
			"StoneGiant" => new RegularMonsterCard("Stone Giant", "Big and angry.", 12, 4),
			"ThunderSerpent" => new RegularMonsterCard("Thunder Serpent", "Shocks enemies.", 6, 6),
			"ForestGuardian" => new RegularMonsterCard("Forest Guardian", "Protector of nature.", 7, 4),
			"ShadowAssassin" => new RegularMonsterCard("Shadow Assassin", "Strikes from the dark.", 4, 7),
			"GoldenKnight" => new RegularMonsterCard("Golden Knight", "Armored warrior.", 9, 3),
			"BoneCrusher" => new RegularMonsterCard("Bone Crusher", "Hits hard.", 6, 5),
			"SandGolem" => new RegularMonsterCard("Sand Golem", "Desert protector.", 10, 2),
			"WindSpirit" => new RegularMonsterCard("Wind Spirit", "Swift and deadly.", 3, 6),
			"VoidReaper" => new RegularMonsterCard("Void Reaper", "Eats souls.", 7, 7),
			"LavaBeast" => new RegularMonsterCard("Lava Beast", "Molten rage.", 10, 5),
			"CrystalSeraph" => new RegularMonsterCard("Crystal Seraph", "Shiny and deadly.", 6, 8),
			"BloodRaptor" => new RegularMonsterCard("Blood Raptor", "Fast killer.", 5, 6),
			"IronTortoise" => new RegularMonsterCard("Iron Tortoise", "Tank with legs.", 14, 1),
			"NightmareHorse" => new RegularMonsterCard("Nightmare Horse", "Bad dreams incarnate.", 7, 5),
			"ToxicSlime" => new RegularMonsterCard("Toxic Slime", "Sticky poison blob.", 4, 2),
			"OceanTitan" => new RegularMonsterCard("Ocean Titan", "Massive water brute.", 11, 4),
			"SkyGriffin" => new RegularMonsterCard("Sky Griffin", "Deadly from above.", 6, 6),
			"DoomImp" => new RegularMonsterCard("Doom Imp", "Annoying evil minion.", 3, 4),

			_ => throw new ArgumentException($"Unknown card key: {cardKey}")
		};
	}
}
