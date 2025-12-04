using CardGame.Board;
using CardGame.Game;

namespace CardGame.Player;

public interface IPlayer {
	IGameEngine Game { get; set; }
	IBoard Board { get; set; }
	IHand Hand { get; set; }
	IDeck Deck { get; set; }
	Guid Id { get; }
	string Name { get; }
	void Heal(int heal);
	void TakeDamage(int damage);
	void PlayCard(int cardIndex, int boardSlot);
}
