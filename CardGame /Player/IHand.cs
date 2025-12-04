using CardGame.Board;
using CardGame.Cards;

namespace CardGame.Player;

public interface IHand {
	int MaxNumberOfCards { get; }
	List<BaseCard> Cards { get; }
	BaseCard GetCardByIndex(int index);
	void DrawCard(BaseCard NewCard);
	void PlayCard(BaseCard card, IBoard board, int slot);
}
