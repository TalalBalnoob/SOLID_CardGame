namespace CardGame.Cards;

public abstract class BaseCard {
	public Guid CardId { get; } = Guid.NewGuid();
	public abstract string Name { get; set; }
	public abstract string Description { get; set; }

	public BaseCard(string name, string description) {
		this.Name = name;
		this.Description = description;
	}

	public abstract BaseCard Clone();
}
