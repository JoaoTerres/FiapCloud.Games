using FiapCloud.Games.App.common;
using FiapCloud.Games.App.common.Exceptions;
using FiapCloud.Games.App.Dtos;
using FiapCloud.Games.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Games.App.Features.GetGameById;

public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, Result<GameResult>>
{
    private readonly IGameRepository _repository;

    public GetGameByIdQueryHandler(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GameResult>> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        var game = await _repository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException("Game", request.Id.ToString());

        var result = new GameResult
        {
            Id = game.Id,
            Title = game.Title,
            Price = game.Price,
            CreatedAt = game.CreatedAt
        };

        return Result<GameResult>.Ok(result, "Jogo encontrado com sucesso.");
    }
}
