using FiapCloud.Games.Domain.Entities;
using FiapCloud.Games.Infra.Data;
using FiapCloud.Games.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiapCloud.Games.Infra.Repositories;

public class UserOwnedGameRepository : IUserOwnedGameRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<UserOwnedGame> _ownedGames;

    public UserOwnedGameRepository(AppDbContext context)
    {
        _context = context;
        _ownedGames = _context.Set<UserOwnedGame>();
    }

    public async Task<UserOwnedGame?> GetByIdAsync(Guid id)
    {
        return await _ownedGames.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<UserOwnedGame>> GetByUserIdAsync(Guid userId)
    {
        return await _ownedGames
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(UserOwnedGame ownedGame)
    {
        await _ownedGames.AddAsync(ownedGame);
    }

    public async Task RemoveAsync(Guid id)
    {
        var ownedGame = await GetByIdAsync(id);
        if (ownedGame != null)
            _ownedGames.Remove(ownedGame);
    }

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
