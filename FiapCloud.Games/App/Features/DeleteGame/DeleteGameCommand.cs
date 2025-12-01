using FiapCloud.Games.App.common;
using MediatR;

namespace FiapCloud.Games.App.Features.DeleteGame;

public class DeleteGameCommand : IRequest<Result<string>>
{
    public DeleteGameCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}
