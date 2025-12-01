using FiapCloud.Games.Domain.Entities;
using FiapCloud.Games.Infra.Data;
using FiapCloud.Games.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiapCloud.Games.Infra.Repositories;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Game> _games;

    public GameRepository(AppDbContext context)
    {
        _context = context;
        _games = _context.Set<Game>();
    }

    public async Task<Game?> GetByIdAsync(Guid id)
    {
        return await _games.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _games.ToListAsync();
    }

    public async Task AddAsync(Game game)
    {
        await _games.AddAsync(game);
    }

    public Task UpdateAsync(Game game)
    {
        _games.Update(game);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var game = await GetByIdAsync(id);
        if (game != null)
            _games.Remove(game);
    }

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
