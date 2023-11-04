using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;

namespace MovieAPI.Infraestructure.EntitiesConfiguration;

/// <summary>
/// Configuração da entidade <see cref="Movie"/> para mapeamento no banco de dados.
/// </summary>
public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    /// <summary>
    /// Configura o mapeamento da entidade <see cref="Movie"/>.
    /// </summary>
    /// <param name="builder">O construtor da entidade.</param>
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Title).Property(x => x.MovieTitle).HasColumnType("NVARCHAR").HasMaxLength(100).HasColumnName("Title").IsRequired();

        builder.Property(x => x.Description).HasColumnType("NVARCHAR").HasMaxLength(200).HasColumnName("Description").IsRequired(false);

        builder.Property(x => x.Genre)
        .HasConversion(
            x => x != null ? x.ToString() : null, // Convertendo enum GenreEnumerator para string
            x => string.IsNullOrEmpty(x) ? default(GenreEnumerator) : (GenreEnumerator)Enum.Parse(typeof(GenreEnumerator), x) // Convertendo string para enum GenreEnumerator
        ).HasMaxLength(100).IsRequired(false);

        builder.Property(x => x.DurationInMinutes).HasColumnType("SMALLINT").HasColumnName("Duration in minutes").IsRequired(false);

        builder.Property(x => x.ReleaseDate).HasColumnType("DATE").HasColumnName("Release date").IsRequired(false);

        builder.Property(x => x.Rating).HasColumnType("FLOAT").HasColumnName("Rating").IsRequired(false);

        // Redundância, não necessita ter mapeado em ambas as configs... somente em uma está bom.
        builder.HasOne(x => x.Director).WithMany(x => x.Movies).HasForeignKey(x => x.DirectorId);
    }
}