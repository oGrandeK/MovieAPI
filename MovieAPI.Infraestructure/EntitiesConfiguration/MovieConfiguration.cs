using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Infraestructure.EntitiesConfiguration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Title, titleBuilder => 
        {
            titleBuilder.Property(x => x.MovieTitle).HasMaxLength(50).IsRequired();
        });

        builder.Property(x => x.Description).HasMaxLength(255);
        builder.Property(x => x.Genre).HasConversion<string>();
        builder.Property(x => x.DurationInMinutes).HasColumnType("tinyint");
        builder.Property(x => x.ReleaseDate).HasConversion(x => x.ToString(), x => new DateOnly());
        builder.Property(x => x.Rating);
    }
}