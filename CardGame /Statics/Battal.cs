using CardGame.Cards;

namespace CardGame.Statics;

public static class Battle {
	public static BaseCard?[] Attack(IDamage attackCard, IHadHeal attackedCard) {
		int attackResult = attackedCard.TakeDamage(attackCard.Damage);
		if (attackResult == 0) return [attackCard as BaseCard, null];

		return [attackCard as BaseCard, attackedCard as BaseCard];
	}
}
