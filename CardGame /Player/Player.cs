using CardGame.Board;
using CardGame.Game;

namespace CardGame.Player;

public class GamePlayer : IPlayer {
	public IGameEngine Game { get; set; }
	public IBoard Board { get; set; }
	public IHand Hand { get; set; }
	public IDeck Deck { get; set; }

	public Guid Id { get; private set; } = Guid.NewGuid();
	public string Name { get; private set; }
	private int Health { get; set; }

	public GamePlayer(string name) {
		Health = 30;
		Name = name;
	}

	public void Heal(int heal) {
		Health = int.Min(30, heal);
	}

	public void TakeDamage(int damage) {
		Health = int.Max(0, Health - damage);
	}

	public void PlayCard(int cardIndex, int boardSlot) {
		Hand.PlayCard(Hand.GetCardByIndex(cardIndex), Board, boardSlot);
	}
}
