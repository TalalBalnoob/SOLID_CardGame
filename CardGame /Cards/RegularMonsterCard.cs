namespace CardGame.Cards;

// Monster card that have HP and Damage points
public class RegularMonsterCard(string name, string description, int hp, int atk)
	: BaseCard(name,
		description), IHadHeal, IDamage {
	public override string Name { get; set; }
	public override string Description { get; set; }

	public int Health { get; private set; } = hp;
	public int MaxHealth { get; private set; } = hp;
	public int Damage { get; private set; } = atk;

	public int TakeDamage(int damage) {
		this.Health -= damage;

		if (this.Health <= 0) {
			this.Health = 0;
			return 0;
		}

		return this.Health;
	}

	public void Healed(int heal) {
		int newHealVal = this.Health + heal;

		if (newHealVal >= this.MaxHealth) this.Health = this.MaxHealth;
		else this.Health = newHealVal;
	}

	public void ReSetFullHealth(int newMaxHealth) {
		this.MaxHealth = newMaxHealth;
	}

	public void Attack(IHadHeal targetCard) {
		targetCard.TakeDamage(this.Damage);
	}

	public override string ToString() {
		return $"{Name} (HP: {((RegularMonsterCard)this).Health}, DMG: {((RegularMonsterCard)this).Damage})";
	}

	public override BaseCard Clone() {
		return new RegularMonsterCard(
			Name = this.Name,
			Description = this.Description,
			this.Health = this.Health,
			this.Damage = this.Damage
		);
	}
}
