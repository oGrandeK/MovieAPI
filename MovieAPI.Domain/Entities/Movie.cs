#nullable enable

using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Entities
{
    public class Movie : Entity
    {
        // Properties
        public Title Title { get; private set; } = null!;
        public string? Description { get; private set; }
        public GenreEnumerator? Genre { get; private set; }
        public short? DurationInMinutes { get; private set; }
        public DateTime? ReleaseDate { get; private set; }
        public double? Rating { get; private set; }

        // Navigation Properties
        public int DirectorId { get; set; }
        public Director Director { get; set; } = null!;

        // Constructors
        public Movie(Title title, int directorId, string? description = null, GenreEnumerator? genre = null, short? durationInMinutes = null, DateTime? releaseDate = null, double? rating = null)
        {
            Validate(title, description, genre, durationInMinutes, releaseDate, rating);

            DirectorId = directorId;
        }

        public Movie(int id, Title title, int directorId, string? description = null, GenreEnumerator? genre = null, short? durationInMinutes = null, DateTime? releaseDate = null, double? rating = null)
        {
            Validate(title, description, genre, durationInMinutes, releaseDate, rating);

            Id = id;

            if(directorId < 1) throw new DomainExceptionValidation("Id do diretor não pode ser inferior a 1");

            DirectorId = directorId;
        }

        private Movie() {}

        // Methods
        public void UpdateMovie(Title title, string? description, GenreEnumerator? genre, short? durationInMinutes, DateTime? releaseDate, double? rating, int directorId) {
            Validate(title, description, genre, durationInMinutes, releaseDate, rating);

            if(directorId < 1) throw new DomainExceptionValidation("Id do diretor não pode ser inferior a 1");

            Title = new Title(title);
            DirectorId = directorId;
        }

        public void Validate(Title title, string? description, GenreEnumerator? genre, short? durationInMinutes, DateTime? releaseDate, double? rating) {
            if(string.IsNullOrEmpty(description)) throw new DomainExceptionValidation("Descrição do filme não pode ser vazio ou nulo");
            if(description.Trim().Length > 255) throw new DomainExceptionValidation("Descrição do filme não pode conter mais que 255 caracteres");

            if(genre != null && !Enum.IsDefined(typeof(GenreEnumerator), genre)) throw new DomainExceptionValidation("Genêro do filme não existe");

            if(durationInMinutes < 1 || durationInMinutes > 600) throw new DomainExceptionValidation("Duração do filme deve estar entre 1 e 600 minutos");

            if(releaseDate < new DateTime(1888, 10, 14)) throw new DomainExceptionValidation("Data de lançamento do filme não pode ser anterior que 14/10/1888");

            if(rating < 0) throw new DomainExceptionValidation("Nota do filme não pode ser inferior a 0");

            Title = new Title(title);
            Description = description.Trim();
            Genre = genre;
            DurationInMinutes = durationInMinutes;
            ReleaseDate = releaseDate;
            Rating = rating;
        }
    }
}