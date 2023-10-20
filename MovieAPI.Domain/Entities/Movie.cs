#nullable enable

using System.Text.Json.Serialization;
using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Entities
{
    /// <summary>
    /// Classe que representa um filme.
    /// </summary>
    public class Movie : Entity
    {
        // Properties
        /// <summary>
        /// Obtém ou define um título para o filme.
        /// </summary>
        public Title Title { get; private set; } = null!;
        /// <summary>
        /// Obtém ou define a descrição do filme.
        /// </summary>
        public string? Description { get; private set; }
        /// <summary>
        /// Obtém ou define o gênero do filme.
        /// </summary>
        public GenreEnumerator? Genre { get; private set; }
        /// <summary>
        /// Obtém ou define a duração do filme em minutos.
        /// </summary>
        public short? DurationInMinutes { get; private set; }
        /// <summary>
        /// Obtém ou define a data de lançamento do filme.
        /// </summary>
        public DateTime? ReleaseDate { get; private set; }
        /// <summary>
        /// Obtém ou define a classificação do filme.
        /// </summary>
        public double? Rating { get; private set; }

        // Navigation Properties
        /// <summary>
        /// Obtém ou define o ID do diretor associado ao filme.
        /// </summary>
        public int DirectorId { get; set; }
        /// <summary>
        /// Obtém ou define o diretor associado ao filme.
        /// </summary>
        public Director? Director { get; set; }

        // Constructors
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Movie"/>.
        /// </summary>
        /// <param name="title">O título do filme.</param>
        /// <param name="directorId">O ID do diretor associado ao filme. Consulte <see cref="Director" para mais informações sobre diretores.</param>
        /// <param name="description">A descrição do filme.</param>
        /// <param name="genre">O gênero do filme.</param>
        /// <param name="durationInMinutes">A duração do filme em minutos.</param>
        /// <param name="releaseDate">A data de lançamento do filme.</param>
        /// <param name="rating">A classificação do filme.</param>
        [JsonConstructor]
        public Movie(Title title, int directorId, string? description = null, GenreEnumerator? genre = null, short? durationInMinutes = null, DateTime? releaseDate = null, double? rating = null)
        {
            Validate(title, description, genre, durationInMinutes, releaseDate, rating);

            DirectorId = directorId;
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Movie"/>.
        /// </summary>
        /// <param name="id">O ID único do filme</param>
        /// <param name="title">O título do filme.</param>
        /// <param name="directorId">O ID do diretor associado ao filme. Consulte <see cref="Director" para mais informações sobre diretores.</param>
        /// <param name="description">A descrição do filme.</param>
        /// <param name="genre">O gênero do filme.</param>
        /// <param name="durationInMinutes">A duração do filme em minutos.</param>
        /// <param name="releaseDate">A data de lançamento do filme.</param>
        /// <param name="rating">A classificação do filme.</param>
        /// <exception cref="DomainExceptionValidation">Disparada se o ID do diretor for inferior a 1.</exception>
        public Movie(int id, Title title, int directorId, string? description = null, GenreEnumerator? genre = null, short? durationInMinutes = null, DateTime? releaseDate = null, double? rating = null)
        {
            Validate(title, description, genre, durationInMinutes, releaseDate, rating);

            Id = id;

            if (directorId < 1) throw new DomainExceptionValidation("Id do diretor não pode ser inferior a 1");

            DirectorId = directorId;
        }

        /// <summary>
        /// Construtor privado e sem parâmetros para permitir a criação via ORM ou serialização.
        /// </summary>
        private Movie() { }

        // Methods
        /// <summary>
        /// Método para atualizar propriedades do filme.
        /// </summary>
        /// <param name="title">O título do filme. Consulte <see cref="Title" para mais informações sobre títulos.</param>
        /// <param name="directorId">O ID do diretor associado ao filme. Consulte <see cref="Director" para mais informações sobre diretores.</param>
        /// <param name="description">A descrição do filme.</param>
        /// <param name="genre">O gênero do filme.</param>
        /// <param name="durationInMinutes">A duração do filme em minutos.</param>
        /// <param name="releaseDate">A data de lançamento do filme.</param>
        /// <param name="rating">A classificação do filme.</param>
        /// <returns>O filme validado e atualizado.</returns>
        /// <exception cref="DomainExceptionValidation">Disparada se o ID do diretor for inferior a 1.</exception>
        public void UpdateMovie(Title title, int directorId, string? description = null, GenreEnumerator? genre = null, short? durationInMinutes = null, DateTime? releaseDate = null, double? rating = null)
        {
            Validate(title, description, genre, durationInMinutes, releaseDate, rating);

            if (directorId < 1) throw new DomainExceptionValidation("Id do diretor não pode ser inferior a 1");

            Title = new Title(title);
            DirectorId = directorId;
        }

        /// <summary>
        /// Método para validar propriedades do filme.
        /// </summary>
        /// <param name="title">O título do filme a ser validado. Consulte <see cref="Title"/> para mais informações sobre títulos.</param>
        /// <param name="description">A descrição do filme a ser validado.</param>
        /// <param name="genre">O gênero do filme a ser validado.</param>
        /// <param name="durationInMinutes">A duração do filme em minutos a ser validado.</param>
        /// <param name="releaseDate">A data de lançamento do filme a ser validado.</param>
        /// <param name="rating">A classificação do filme a ser validado.</param>
        /// <exception cref="DomainExceptionValidation">Disparado se algumas das propriedades violar as regras de validação.</exception>
        public void Validate(Title title, string? description = null, GenreEnumerator? genre = null, short? durationInMinutes = null, DateTime? releaseDate = null, double? rating = null)
        {
            if (!string.IsNullOrEmpty(description) && description.Trim().Length > 255) throw new DomainExceptionValidation("Descrição do filme não pode conter mais que 255 caracteres");

            if (genre != null && !Enum.IsDefined(typeof(GenreEnumerator), genre)) throw new DomainExceptionValidation("Genêro do filme não existe");

            if (durationInMinutes < 1 || durationInMinutes > 600) throw new DomainExceptionValidation("Duração do filme deve estar entre 1 e 600 minutos");

            if (releaseDate < new DateTime(1888, 10, 14)) throw new DomainExceptionValidation("Data de lançamento do filme não pode ser anterior que 14/10/1888");

            if (rating < 0) throw new DomainExceptionValidation("Nota do filme não pode ser inferior a 0");

            Title = new Title(title);
            Description = description?.Trim();
            Genre = genre;
            DurationInMinutes = durationInMinutes;
            ReleaseDate = releaseDate;
            Rating = rating;
        }

        /// <summary>
        /// Converte a entidade em uma representação de string, usando o título do filme.
        /// </summary>
        /// <returns>O título do filme como string.</returns>
        public override string ToString() => Title;
    }
}