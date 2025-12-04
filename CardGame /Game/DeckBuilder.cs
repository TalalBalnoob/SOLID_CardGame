using CardGame.Cards;
using CardGame.Player;

namespace CardGame.Game;

public class DeckBuilder : IDeckBuilder {
	private readonly List<BaseCard> _cards = new();

	public DeckBuilder Add(string cardId, int copies = 1) {
		for (int i = 0; i < copies; i++) {
			if (_cards.Count >= Deck.MaxCardsInDeck)
				throw new InvalidOperationException("Has reached the maximum number of cards in a deck");
			_cards.Add(CardLibrary.GetCard(cardId));
		}

		return this; // fluent chaining
	}

	public DeckBuilder AddRange(string[] cardIds) {
		foreach (var id in cardIds) {
			if (_cards.Count >= Deck.MaxCardsInDeck)
				throw new InvalidOperationException("Has reached the maximum number of cards in a deck");
			_cards.Add(CardLibrary.GetCard(id));
		}

		return this;
	}

	public static BaseCard[] GetGeneratedRandomDeck(int? deckSize) {
		Random _rng = new();
		var result = new List<BaseCard>();
		var ids = CardLibrary.GetAllCardIds();
		if (deckSize == null) deckSize = Deck.MaxCardsInDeck;

		for (int i = 0; i < deckSize; i++) {
			string randomId = ids[_rng.Next(ids.Length)];
			result.Add(CardLibrary.GetCard(randomId));
		}

		return result.ToArray();
	}

	public static BaseCard[] GetBalancedStarterDeck() {
		return new DeckBuilder()
			.Add("FireDragon", 1)
			.Add("IceWolf", 2)
			.Add("GoldenKnight", 2)
			.Add("StoneGiant", 2)
			.Add("WindSpirit", 2)
			.Add("SandGolem", 2)
			.Add("ShadowAssassin", 2)
			.Add("BloodRaptor", 2)
			.Add("ToxicSlime", 2)
			.Add("BoneCrusher", 2)
			.Add("VoidReaper", 2)
			.Add("LavaBeast", 2)
			.Add("CrystalSeraph", 2)
			.Add("IronTortoise", 2)
			.Add("NightmareHorse", 2)
			.Add("OceanTitan", 1)
			.Build();
	}


	public BaseCard[] Build() {
		return _cards.ToArray();
	}
}
