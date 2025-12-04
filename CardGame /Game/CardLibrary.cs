using CardGame.Cards;

namespace CardGame.Game;

public static class CardLibrary {
	private static readonly Dictionary<string, BaseCard> _cards = new();

	private static readonly string[] _allCardIds = {
		"FireDragon",
		"IceWolf",
		"StoneGiant",
		"ThunderSerpent",
		"ForestGuardian",
		"ShadowAssassin",
		"GoldenKnight",
		"BoneCrusher",
		"SandGolem",
		"WindSpirit",
		"VoidReaper",
		"LavaBeast",
		"CrystalSeraph",
		"BloodRaptor",
		"IronTortoise",
		"NightmareHorse",
		"ToxicSlime",
		"OceanTitan",
		"SkyGriffin",
		"DoomImp"
	};

	public static void Init() {
		foreach (var id in _allCardIds) {
			_cards[id] = CardFactory.Create(id);
		}
	}

	public static string[] GetAllCardIds() {
		return _allCardIds;
	}

	public static BaseCard GetCard(string id) {
		if (!_cards.ContainsKey(id))
			throw new ArgumentException($"Card '{id}' not found in library.");

		return _cards[id].Clone(); // always return fresh instance
	}
}
