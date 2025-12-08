using FiapCloud.Games.Domain.Entities;

namespace FiapCloud.Games.Infra.Repositories.Interfaces;

public interface IUserOwnedGameRepository
{
    Task<IEnumerable<UserOwnedGame>> GetByUserIdAsync(Guid userId);
    Task AddAsync(UserOwnedGame ownedGame);
    Task<int> SaveChangesAsync();
}
