namespace CardGame.Cards;

public interface ICard {
	ICard Clone();
	string Name { get; }
}
