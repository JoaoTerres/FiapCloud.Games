using FiapCloud.Games.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapCloud.Games.Infra.Mappings;

public class GameMapping : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Games");
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Title)
            .IsRequired()
            .HasColumnType("varchar(150)");

        builder.Property(g => g.Price)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder.Property(g => g.CreatedAt)
            .IsRequired();
    }
}
