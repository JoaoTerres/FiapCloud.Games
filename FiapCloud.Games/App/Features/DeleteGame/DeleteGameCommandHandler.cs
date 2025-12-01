using FiapCloud.Games.App.common;
using FiapCloud.Games.App.common.Exceptions;
using FiapCloud.Games.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Games.App.Features.DeleteGame;

public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, Result<string>>
{
    private readonly IGameRepository _repository;

    public DeleteGameCommandHandler(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var game = await _repository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException("Game", request.Id.ToString());

        _repository.DeleteAsync(request.Id);
        await _repository.SaveChangesAsync();

        return Result<string>.Ok("Jogo removido com sucesso.");
    }
}
