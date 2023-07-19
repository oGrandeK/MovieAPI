using System;
using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Entities
{
    public class Movie
    {
        // Properties
        public int Id { get; private set; }
        public Title Title { get; private set; }
        public Description Description { get; private set; }
        public GenreEnumerator Genre { get; private set; }
        public short DurationInMinutes { get; private set; }
        public DateOnly ReleaseDate { get; private set; }
        public double Rating { get; private set; }

        // Navigation Properties
        public int DirectorId { get; set; }
        public Director Director { get; set; }

        // Constructors
        // TODO -> validar o DIRECTORID e talves o DIRECTOR  
        public Movie(Title title, Description description, GenreEnumerator genre, short durationInMinutes, DateOnly releaseDate, double rating, int directorId)
        {
            Validate(title, description, genre, DurationInMinutes, releaseDate, rating);
            Title = title;
            Description = description;
            Genre = genre;
            DurationInMinutes = durationInMinutes;
            ReleaseDate = releaseDate;
            Rating = rating;
            DirectorId = directorId;
        }

        // Methods
        // TODO -> Adicionar os demais métodos para alterar os campos da entidade
        public void Validate(Title title, Description description, GenreEnumerator genre, int DurationInMinutes, DateOnly releaseDate, double rating) {
            DomainExceptionValidation.HasError(title.MovieTitle.Length <= 1, "The movie title must be 1 or more characters long");
            DomainExceptionValidation.HasError(title.MovieTitle.Length > 20, "The movie title must be 19 or less characters long");

            DomainExceptionValidation.HasError(description.MovieDescription.Length <= 10, "The movie description must be 10 or more characters long");
            DomainExceptionValidation.HasError(description.MovieDescription.Length > 255, "The movie description must be 255 or less characters long");

            DomainExceptionValidation.HasError(Enum.IsDefined(typeof(GenreEnumerator), genre), "The genre doesn't exist");

            DomainExceptionValidation.HasError(DurationInMinutes <= 0, "The movie duration cannot be negative");
            DomainExceptionValidation.HasError(DurationInMinutes > 600, "The movie duration cannot be more than 600 minutes");

            DomainExceptionValidation.HasError(releaseDate < new DateOnly(1985, 12, 28), "The movie release date cannot be inferior than 1985-12-28");

            DomainExceptionValidation.HasError(rating < 0, "The movie rating cannot be negative");
        }
    }

}