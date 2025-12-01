using FiapCloud.Games.Domain.Entities;

namespace FiapCloud.Games.Infra.Repositories.Interfaces;

public interface IGameRepository
{
    Task<Game?> GetByIdAsync(Guid id);
    Task<IEnumerable<Game>> GetAllAsync();
    Task AddAsync(Game game);
    Task UpdateAsync(Game game);
    Task DeleteAsync(Guid id);

    Task<int> SaveChangesAsync();
}
