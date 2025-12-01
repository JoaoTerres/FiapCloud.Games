using FiapCloud.Games.App.common;
using FiapCloud.Games.App.Dtos;
using FiapCloud.Games.Domain.Entities;
using FiapCloud.Games.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Games.App.Features.CreateGame;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Result<GameResult>>
{
    private readonly IGameRepository _repository;

    public CreateGameCommandHandler(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GameResult>> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var game = new Game(request.Title, request.Price);

        await _repository.AddAsync(game);
        await _repository.SaveChangesAsync();

        var result = new GameResult
        {
            Id = game.Id,
            Title = game.Title,
            Price = game.Price,
            CreatedAt = game.CreatedAt
        };

        return Result<GameResult>.Ok(result, "Jogo criado com sucesso.");
    }
}
