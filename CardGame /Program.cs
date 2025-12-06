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


		//Player attack

		Console.WriteLine(gameEngine.Players[0].Board);
		Console.WriteLine("===");
		Console.WriteLine(gameEngine.Players[1].Board);
	}
}
