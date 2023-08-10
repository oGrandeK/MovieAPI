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

        builder.OwnsOne(x => x.Name, nameBuilder => 
        {
            nameBuilder.Property(x => x.FirstName).HasColumnName("Name_FirstName").HasMaxLength(30).IsRequired();
            nameBuilder.Property(x => x.LastName).HasColumnName("Name_LastName").HasMaxLength(30).IsRequired();
        });

        builder.HasMany(x => x.Movies).WithOne(x => x.Director).HasForeignKey(x => x.DirectorId);
    }
}