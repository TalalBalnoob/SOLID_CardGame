using CardGame.Cards;

namespace CardGame.Game;

public interface IDeckBuilder {
	DeckBuilder Add(string cardId, int copies = 1);
	DeckBuilder AddRange(string[] cardIds);
	BaseCard[] Build();
}
