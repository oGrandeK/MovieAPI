using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Infraestructure.EntitiesConfiguration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title.MovieTitle).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(255);
        builder.Property(x => x.Genre).HasConversion<string>();
        builder.Property(x => x.DurationInMinutes).HasAnnotation("Range", new RangeAttribute(0, 600));
        builder.Property(x => x.ReleaseDate);
        builder.Property(x => x.Rating);
    }
}