using CardGame.Board;
using CardGame.Cards;
using CardGame.Player;

namespace CardGame.Game;

public interface IGameEngine2 {
	List<IPlayer> Players { get; }
	List<IBoard> Boards { get; }
	void StartGame();
}

public class GameEngine : IGameEngine {
	public List<IPlayer> Players { get; private set; }
	public List<IBoard> Boards { get; private set; }
	public int PlayerTurn { get; private set; }

	public GameEngine(IPlayer[] playersList, Func<IBoard> boardFactory) {
		Players = new List<IPlayer>(playersList);
		Boards = new List<IBoard>();
	}

	public void StartGame() {
		foreach (var player in Players) {
			player.Deck = new Deck(DeckBuilder.GetBalancedStarterDeck());
			player.Deck.Shuffle();
			player.Hand = new Hand([]);
			for (int i = 0; i < player.Hand.MaxNumberOfCards; i++) {
				player.Hand.DrawCard(player.Deck.Draw());
			}

			player.Board = new GameBoard();
			Boards.Add(player.Board);
			player.Game = this;
		}

		PlayerTurn = 0;
	}

	public void PlayerPlayCard(int player, int cardIndex, int BoardSlot) {
		if (player > 1 || player < 0) throw new ArgumentException("Invalid Player Number can only be 1 or 0");

		try {
			Players[player].PlayCard(cardIndex, BoardSlot);
		}
		catch (Exception e) {
			Console.WriteLine(e);
			throw;
		}

		PlayerTurn = player == 1 ? 0 : 1;
	}

	public void PlayerPlayCard(int cardIndex, int BoardSlot) {
		try {
			Players[PlayerTurn].PlayCard(cardIndex, BoardSlot);
		}
		catch (Exception e) {
			Console.WriteLine(e);
			throw;
		}

		PlayerTurn = PlayerTurn == 1 ? 0 : 1;
	}

	public void PlayerAttack(int playerSlot, int opponentSlot) {
		// Check if card is in the slot and if it can attack
		BaseCard? playerCard = Players[PlayerTurn].Board.GetCardAtSlot(playerSlot);
		if (playerCard == null) throw new InvalidOperationException("No attacking card in slot " + playerSlot);
		var attackingCard = playerCard as IDamage;
		if (attackingCard == null) throw new Exception("Card cannot attack.");

		// Check if card is in the slot and if it can be attacked
		BaseCard? oppenentCard = Players[PlayerTurn == 1 ? 0 : 1].Board.GetCardAtSlot(playerSlot);
		if (oppenentCard == null) throw new InvalidOperationException("No card to attack in slot " + playerSlot);
		var defendingCard = playerCard as IDamageable;
		if (defendingCard == null) throw new Exception("Card cannot be attacked.");

		// refactor so it regive the attack result
		// damage and heal exchange
		// destroy 0 heal cards
		attackingCard.Attack(defendingCard);
	}

	public void PlayerAttack(int player, int playerSlot, int opponentSlot) {
		throw new NotImplementedException();
	}
}
