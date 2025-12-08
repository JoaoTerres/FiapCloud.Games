using MediatR;

namespace FiapCloud.Games.App.Features.AddOwnedGame;

public class AddOwnedGameCommand : IRequest<bool>
{
    public Guid UserId { get; }
    public Guid GameId { get; }

    public AddOwnedGameCommand(Guid userId, Guid gameId)
    {
        UserId = userId;
        GameId = gameId;
    }

}