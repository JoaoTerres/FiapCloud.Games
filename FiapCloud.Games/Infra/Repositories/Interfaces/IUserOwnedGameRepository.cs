using FiapCloud.Games.Domain.Entities;

namespace FiapCloud.Games.Infra.Repositories.Interfaces;

public interface IUserOwnedGameRepository
{
    Task<UserOwnedGame?> GetByIdAsync(Guid id);
    Task<IEnumerable<UserOwnedGame>> GetByUserIdAsync(Guid userId);
    Task AddAsync(UserOwnedGame ownedGame);
    Task RemoveAsync(Guid id);
    Task<int> SaveChangesAsync();
}
