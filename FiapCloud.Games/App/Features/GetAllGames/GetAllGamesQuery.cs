using FiapCloud.Games.App.common;
using FiapCloud.Games.App.Dtos;
using MediatR;

namespace FiapCloud.Games.App.Features.GetAllGames;

public class GetAllGamesQuery : IRequest<Result<IEnumerable<GameResult>>>
{
}
