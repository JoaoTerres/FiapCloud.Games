using FiapCloud.Games.Domain.Entities;
using FiapCloud.Games.Infra.Data;
using FiapCloud.Games.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiapCloud.Games.Infra.Repositories;

public class UserGameLibraryRepository : IUserGameLibraryRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<UserGameLibrary> _libraries;

    public UserGameLibraryRepository(AppDbContext context)
    {
        _context = context;
        _libraries = _context.Set<UserGameLibrary>();
    }

    public async Task<UserGameLibrary?> GetByUserIdAsync(Guid userId)
    {
        return await _libraries
            .Include(l => l.OwnedGames)
            .FirstOrDefaultAsync(l => l.UserId == userId);
    }

    public async Task AddAsync(UserGameLibrary library)
    {
        await _libraries.AddAsync(library);
    }

    public Task UpdateAsync(UserGameLibrary library)
    {
        _libraries.Update(library);
        return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
