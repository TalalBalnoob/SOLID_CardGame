using CardGame.Board;
using CardGame.Player;

namespace CardGame.Game;

public interface IGameEngine {
	List<IPlayer> Players { get; }
	List<IBoard> Boards { get; }
	void StartGame();
	void PlayerPlayCard(int cardIndex, int BoardSlot);
	void PlayerPlayCard(int player, int cardIndex, int BoardSlot);
	void PlayerAttack(int playerSlot, int opponentSlot);
	void PlayerAttack(int player, int playerSlot, int opponentSlot);
}
