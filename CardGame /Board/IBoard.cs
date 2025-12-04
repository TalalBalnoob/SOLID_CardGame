using CardGame.Cards;

namespace CardGame.Board;

public interface IBoard {
	int SlotCount { get; }
	void PlaceCard(BaseCard card, int slot);
	void RemoveCard(int slot);
	int? GetSlotOfCard(BaseCard card);
	BaseCard? GetCardAtSlot(int slot);
	bool IsCardInSlotAttackable(int slot);
}
