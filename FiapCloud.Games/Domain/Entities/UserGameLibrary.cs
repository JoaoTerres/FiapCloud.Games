namespace FiapCloud.Games.Domain.Entities;

public class UserGameLibrary
{
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public IReadOnlyCollection<UserOwnedGame> OwnedGames => _ownedGames;

    private readonly List<UserOwnedGame> _ownedGames = new();

    private UserGameLibrary() { }

    public UserGameLibrary(Guid userId)
    {
        AssertValidation.IsTrue(userId != Guid.Empty, "UserId inválido.");

        UserId = userId;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddGame(Guid gameId)
    {
        AssertValidation.IsTrue(gameId != Guid.Empty, "GameId inválido.");

        if (_ownedGames.Any(g => g.GameId == gameId))
            return;

        _ownedGames.Add(new UserOwnedGame(UserId, gameId, DateTime.UtcNow));
    }

    public void RemoveGame(Guid gameId)
    {
        var owned = _ownedGames.FirstOrDefault(x => x.GameId == gameId);
        if (owned != null)
            _ownedGames.Remove(owned);
    }
}
