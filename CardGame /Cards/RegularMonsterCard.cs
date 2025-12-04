namespace CardGame.Cards;

// Monster card that have HP and Damage points  
public class RegularMonsterCard(string name, string description, int hp, int atk)
	: BaseCard(name,
		description), ICardHeal, IDamage, IDamageable {
	public override string Name { get; set; }
	public override string Description { get; set; }

	public int CardHealth { get; private set; } = hp;
	public int MaxCardHealth { get; private set; } = hp;
	private int CardDamage { get; set; } = atk;

	public void TakeDamage(int damage) {
		this.CardHealth -= damage;

		if (this.CardHealth <= 0) {
			// destroy card
		}
	}

	public void Healed(int heal) {
		int newHealVal = this.CardHealth + heal;

		if (newHealVal >= MaxCardHealth) this.CardHealth = this.MaxCardHealth;
		else this.CardHealth = newHealVal;
	}

	public void ReSetFullHealth(int newMaxHealth) {
		this.MaxCardHealth = newMaxHealth;
	}

	public void Attack(IDamageable targetCard) {
		targetCard.TakeDamage(this.CardDamage);
	}

	public override string ToString() {
		return $"{Name} (HP: {((RegularMonsterCard)this).CardHealth}, DMG: {((RegularMonsterCard)this).CardDamage})";
	}

	override
		public BaseCard Clone() {
		return new RegularMonsterCard(
			Name = this.Name,
			Description = this.Description,
			CardHealth = this.CardHealth,
			CardDamage = this.CardDamage
		);
	}
}
