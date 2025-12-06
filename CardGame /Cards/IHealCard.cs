namespace CardGame.Cards;

public interface IHadHeal {
	int Health { get; }
	int MaxHealth { get; }
	void Healed(int heal);
	int TakeDamage(int damage);
	void ReSetFullHealth(int newMaxHealth);
}
