using CardGame.Board;
using CardGame.Cards;

namespace CardGame.Player;

public class Hand : IHand {
	public int MaxNumberOfCards { get; } = 10;
	public List<BaseCard> Cards { get; }

	public Hand(IEnumerable<BaseCard>? startingCards) {
		this.Cards = startingCards.ToList() ?? new List<BaseCard>();

		if (Cards.Count > MaxNumberOfCards)
			throw new InvalidOperationException("Starting cards exceed maximum hand size.");
	}

	public BaseCard GetCardByIndex(int index) {
		if (index < 0 || index > Cards.Count) throw new ArgumentOutOfRangeException(nameof(index));
		return Cards[index];
	}

	public void DrawCard(BaseCard NewCard) {
		if (Cards.Count == MaxNumberOfCards) throw new InvalidOperationException("Hand is full");
		Cards.Add(NewCard);
	}

	public void PlayCard(BaseCard card, IBoard board, int slot) {
		try {
			board.PlaceCard(card, slot);
		}
		catch (IOException e) {
			Console.WriteLine(e);
			throw;
		}
	}

	public override string ToString() {
		return string.Join("\n", Cards.Select(c => "- " + c.ToString()));
	}
}
