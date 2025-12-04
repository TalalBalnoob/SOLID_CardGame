using CardGame.Cards;

namespace CardGame.Player;

public class Deck : IDeck {
	private Stack<BaseCard> Cards { get; set; }
	public static int MaxCardsInDeck { get; } = 30;

	public Deck(BaseCard[] deckCards) {
		Cards = new Stack<BaseCard>();
		foreach (var card in deckCards) {
			Cards.Push(card);
		}
	}

	public BaseCard Draw() {
		if (Cards.Count == 0) throw new InvalidOperationException("No more cards left to draw from");
		return Cards.Pop();
	}

	public void Shuffle() {
		var rng = new Random();
		var array = Cards.ToArray();

		// Fisher–Yates shuffle
		for (int i = array.Length - 1; i > 0; i--) {
			int j = rng.Next(i + 1);
			(array[i], array[j]) = (array[j], array[i]);
		}

		Cards = new Stack<BaseCard>(array);
	}

	public int Count() => Cards.Count;

	public override string ToString() {
		return string.Join("\n", Cards.Select(c => "- " + c.ToString()));
	}
}
