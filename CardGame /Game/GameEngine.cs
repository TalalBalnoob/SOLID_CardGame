using CardGame.Board;
using CardGame.Cards;
using CardGame.Player;
using CardGame.Statics;

namespace CardGame.Game;

public class GameEngine : IGameEngine {
	public List<IPlayer> Players { get; private set; }
	public List<IBoard> Boards { get; private set; }
	public bool PlayerTurn { get; private set; }

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

		PlayerTurn = false;
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

		PlayerTurn = player == 1;
	}

	public void PlayerPlayCard(int cardIndex, int BoardSlot) {
		try {
			Players[PlayerTurn.ToInt()].PlayCard(cardIndex, BoardSlot);
		}
		catch (Exception e) {
			Console.WriteLine(e);
			throw;
		}

		PlayerTurn = !PlayerTurn;
	}

	public void PlayerAttack(int playerSlot, int opponentSlot) {
		// Check if card is in the slot and if it can attack
		BaseCard? playerCard = Players[PlayerTurn.ToInt()].Board.GetCardAtSlot(playerSlot);
		if (playerCard == null) throw new InvalidOperationException("No attacking card in slot " + playerSlot);
		var attackingCard = playerCard as IDamage;
		if (attackingCard == null) throw new Exception("Card cannot attack.");
		Console.WriteLine(attackingCard + " Attacking");

		// Check if card is in the slot and if it can be attacked
		BaseCard? opponentCard = Players[(!PlayerTurn).ToInt()].Board.GetCardAtSlot(opponentSlot);
		if (opponentCard == null) throw new InvalidOperationException("No card to attack in slot " + opponentSlot);
		var defendingCard = opponentCard as IHadHeal;
		if (defendingCard == null) throw new Exception("Card cannot be attacked.");
		Console.WriteLine(defendingCard + " Defending");

		// refactor so it returns the attack result
		var results = Battle.Attack(attackingCard, defendingCard);
		// damage and heal exchange
		// destroy 0 heal cards
		if (results[1] == null) Players[(!PlayerTurn).ToInt()].Board.RemoveCard(opponentSlot);

		PlayerTurn = !PlayerTurn;
	}

	public void PlayerAttack(int player, int playerSlot, int opponentSlot) {
		throw new NotImplementedException();
	}

	public void EndTurn() {
		PlayerTurn = !PlayerTurn;
	}
}
