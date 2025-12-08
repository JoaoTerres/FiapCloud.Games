using FiapCloud.Games.Domain.Entities;
using FiapCloud.Games.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Games.App.Features.AddOwnedGame;

public class AddOwnedGameCommandHandler : IRequestHandler<AddOwnedGameCommand, bool>
{
    private readonly IUserGameLibraryRepository _libraryRepository;

    public AddOwnedGameCommandHandler(IUserGameLibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    public async Task<bool> Handle(AddOwnedGameCommand request, CancellationToken cancellationToken)
    {
        var library = await _libraryRepository.GetByUserIdAsync(request.UserId);

        if (library == null)
        {
            library = new UserGameLibrary(request.UserId);
            library.AddGame(request.GameId);

            await _libraryRepository.AddAsync(library);
        }
        else
        {
            library.AddGame(request.GameId);
            _libraryRepository.UpdateAsync(library);
        }

        await _libraryRepository.SaveChangesAsync();
        return true;
    }
}
