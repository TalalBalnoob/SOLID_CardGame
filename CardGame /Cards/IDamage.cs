namespace CardGame.Cards;

public interface IDamage {
	int Damage { get; }
	void Attack(IHadHeal targetCard);
}
