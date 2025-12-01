using FiapCloud.Games.App.common;
using FiapCloud.Games.App.common.Exceptions;
using FiapCloud.Games.App.Dtos;
using FiapCloud.Games.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Games.App.Features.UpdateGame;

public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Result<GameResult>>
{
    private readonly IGameRepository _repository;

    public UpdateGameCommandHandler(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GameResult>> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        var game = await _repository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException("Game", request.Id.ToString());

        game.Update(request.Title, request.Price);

        _repository.UpdateAsync(game);
        await _repository.SaveChangesAsync();

        var result = new GameResult
        {
            Id = game.Id,
            Title = game.Title,
            Price = game.Price,
            CreatedAt = game.CreatedAt
        };

        return Result<GameResult>.Ok(result, "Jogo atualizado com sucesso.");
    }
}
