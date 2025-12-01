using FiapCloud.Games.App.common;
using FiapCloud.Games.App.Dtos;
using MediatR;

namespace FiapCloud.Games.App.Features.GetGameById;
public class GetGameByIdQuery : IRequest<Result<GameResult>>
{
    public GetGameByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}
