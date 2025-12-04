using CardGame.Board;
using CardGame.Cards;
using CardGame.Game;
using CardGame.Player;

namespace CardGame;

class Program {
	static void Main(string[] args) {
		CardLibrary.Init();

		GamePlayer[] players = new GamePlayer[] {
			new GamePlayer("Big John"),
			new GamePlayer("Small John")
		};

		IGameEngine gameEngine = new GameEngine(players, () => new GameBoard());

		gameEngine.StartGame();

		// Console.WriteLine(gameEngine.Players[0].Hand);
		// Console.WriteLine("===");
		// Console.WriteLine(gameEngine.Players[0].Deck);
		// Console.WriteLine("===");
		// Console.WriteLine(gameEngine.Players[1].Hand);
		// Console.WriteLine("===");
		// Console.WriteLine(gameEngine.Players[1].Deck);

		// Console.WriteLine(gameEngine.Players[0].Board);
		// Console.WriteLine("===");
		// Console.WriteLine(gameEngine.Players[1].Board);


		gameEngine.PlayerPlayCard(2, 1);
		gameEngine.PlayerPlayCard(1, 3);

		//Player attack

		Console.WriteLine(gameEngine.Players[0].Board);
		Console.WriteLine("===");
		Console.WriteLine(gameEngine.Players[1].Board);
	}
}
