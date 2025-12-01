namespace FiapCloud.Games.Domain.Entities;

public class Game
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Game() { }

    public Game(string title, decimal price)
    {
        Id = Guid.NewGuid();
        Title = title;
        Price = price;
        CreatedAt = DateTime.UtcNow;

        Validate();
    }

    public void Update(string title, decimal price)
    {
        AssertValidation.NotEmpty(title, "Título é obrigatório.");
        AssertValidation.IsTrue(price >= 0, "Preço não pode ser negativo.");

        Title = title;
        Price = price;
    }

    private void Validate()
    {
        AssertValidation.NotEmpty(Title, "Título é obrigatório.");
        AssertValidation.IsTrue(Price >= 0, "Preço não pode ser negativo.");
    }
}
