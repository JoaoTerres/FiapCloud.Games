using FiapCloud.Games.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapCloud.Games.Infra.Mappings;

public class UserGameLibraryMapping : IEntityTypeConfiguration<UserGameLibrary>
{
    public void Configure(EntityTypeBuilder<UserGameLibrary> builder)
    {
        builder.ToTable("UserGameLibraries");
        builder.HasKey(l => l.UserId); 

        builder.Property(l => l.CreatedAt)
            .IsRequired();

        builder.HasMany<UserOwnedGame>()
            .WithOne()
            .HasForeignKey(g => g.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}