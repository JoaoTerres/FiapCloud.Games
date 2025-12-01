using FiapCloud.Games.Domain.Entities;

namespace FiapCloud.Games.Infra.Repositories.Interfaces;

public interface IUserGameLibraryRepository
{
    Task<UserGameLibrary?> GetByUserIdAsync(Guid userId);
    Task AddAsync(UserGameLibrary library);
    Task UpdateAsync(UserGameLibrary library);

    Task<int> SaveChangesAsync();
}
