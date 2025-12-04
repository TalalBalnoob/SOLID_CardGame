namespace CardGame.Cards;

public interface ICardHeal {
	int CardHealth { get; }
	int MaxCardHealth { get; }
	void Healed(int heal);
	void ReSetFullHealth(int newMaxHealth);
}
