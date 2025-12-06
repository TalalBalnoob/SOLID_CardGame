using CardGame.Cards;

namespace CardGame.Board;

public class GameBoard : IBoard {
	private readonly BaseCard?[] _slots = new BaseCard?[8];
	public int SlotCount { get; } = 8;

	public void PlaceCard(BaseCard card, int slot) {
		if (_slots[slot] != null) throw new InvalidOperationException("Slot is already occupied.");
		_slots[slot] = card;
	}

	public void RemoveCard(int slot) {
		_slots[slot] = null;
	}

	public int? GetSlotOfCard(BaseCard card) {
		int cardSlot = Array.IndexOf(_slots, card);
		if (cardSlot == -1) return null;
		return cardSlot;
	}

	public BaseCard? GetCardAtSlot(int slot) {
		return _slots[slot];
	}

	public bool IsCardInSlotAttackable(int slot) {
		var card = this.GetCardAtSlot(slot);
		return card != null && typeof(IHadHeal) == card.GetType();
	}

	public override string ToString() {
		return string.Join("\n", _slots.Select(c => {
			if (c == null) return "Empty Slot";
			return "- " + c.ToString();
		}));
	}
}
