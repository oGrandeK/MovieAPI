using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Infraestructure.EntitiesConfiguration;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Name).Property(x => x.FirstName).HasColumnType("NVARCHAR").HasMaxLength(100).HasColumnName("FirstName").IsRequired();

        builder.OwnsOne(x => x.Name).Property(x => x.LastName).HasColumnType("NVARCHAR").HasMaxLength(100).HasColumnName("LastName").IsRequired();

        builder.HasMany(x => x.Movies).WithOne(x => x.Director).HasForeignKey(x => x.DirectorId);
    }
}