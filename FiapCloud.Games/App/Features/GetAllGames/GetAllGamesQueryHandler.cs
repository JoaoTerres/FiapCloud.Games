using FiapCloud.Games.App.common;
using FiapCloud.Games.App.Dtos;
using FiapCloud.Games.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Games.App.Features.GetAllGames;
public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, Result<IEnumerable<GameResult>>>
{
    private readonly IGameRepository _repository;

    public GetAllGamesQueryHandler(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<GameResult>>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
    {
        var games = await _repository.GetAllAsync();

        var result = games.Select(g => new GameResult
        {
            Id = g.Id,
            Title = g.Title,
            Price = g.Price,
            CreatedAt = g.CreatedAt
        });

        return Result<IEnumerable<GameResult>>.Ok(result, "Lista de jogos obtida com sucesso.");
    }
}