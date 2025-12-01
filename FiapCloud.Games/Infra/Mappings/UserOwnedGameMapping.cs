using FiapCloud.Games.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapCloud.Games.Infra.Mappings;

public class UserOwnedGameMapping : IEntityTypeConfiguration<UserOwnedGame>
{
    public void Configure(EntityTypeBuilder<UserOwnedGame> builder)
    {
        builder.ToTable("UserOwnedGames");

        builder.HasKey(ug => new { ug.UserId, ug.GameId });

        builder.Property(ug => ug.PurchaseDate)
            .IsRequired();

        builder.Property(ug => ug.UserId)
            .IsRequired();

        builder.Property(ug => ug.GameId)
            .IsRequired();
    }
}
