using FiapCloud.Games.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiapCloud.Games.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Game> Games { get; set; }
    public DbSet<UserGameLibrary> UserGameLibraries { get; set; }
    public DbSet<UserOwnedGame> UserOwnedGames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}