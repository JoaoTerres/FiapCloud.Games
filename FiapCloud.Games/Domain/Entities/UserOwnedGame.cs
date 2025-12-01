namespace FiapCloud.Games.Domain.Entities;

public class UserOwnedGame
{
    public Guid UserId { get; private set; }
    public Guid GameId { get; private set; }
    public DateTime PurchaseDate { get; private set; }

    private UserOwnedGame() { }

    public UserOwnedGame(Guid userId, Guid gameId, DateTime purchaseDate)
    {
        AssertValidation.IsTrue(userId != Guid.Empty, "UserId inválido.");
        AssertValidation.IsTrue(gameId != Guid.Empty, "GameId inválido.");
        AssertValidation.NotNull(purchaseDate, "Data de compra é obrigatória.");

        UserId = userId;
        GameId = gameId;
        PurchaseDate = purchaseDate;
    }
}
