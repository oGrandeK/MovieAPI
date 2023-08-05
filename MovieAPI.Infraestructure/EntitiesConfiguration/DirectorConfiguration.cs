using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Infraestructure.EntitiesConfiguration;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name.FirstName).HasMaxLength(30).IsRequired();
        builder.Property(x => x.Name.LastName).HasMaxLength(30).IsRequired();

        builder.HasData(
            new Director(1, new Name("John", "Lasseter")),
            new Director(2, new Name("Sam", "Raimi")),
            new Director(3, new Name("Quentin", "Tarantino")),
            new Director(4, new Name("Chad", "Stahelski"))
        );

        builder.HasMany(x => x.Movies).WithOne(x => x.Director).HasForeignKey(x => x.DirectorId);
    }
}