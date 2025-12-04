using CardGame.Cards;

namespace CardGame.Player;

public interface IDeck {
	public BaseCard Draw();
	public void Shuffle();
	public int Count();
}
