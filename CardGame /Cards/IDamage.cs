namespace CardGame.Cards;

public interface IDamage {
	// Attack any card that implement IHealCard 
	// Because if it bleeds we can kill it 
	void Attack(IDamageable targetCard);
}
