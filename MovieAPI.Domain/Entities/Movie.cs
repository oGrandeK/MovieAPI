using System;
using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Entities
{
    public class Movie : Entity
    {
        // Properties
        public Title Title { get; private set; }
        public Description? Description { get; private set; }
        public GenreEnumerator? Genre { get; private set; }
        public short? DurationInMinutes { get; private set; }
        public DateOnly? ReleaseDate { get; private set; }
        public double? Rating { get; private set; }

        // Navigation Properties
        public int DirectorId { get; set; }
        public Director Director { get; set; }

        // Constructors
        // TODO -> validar o DIRECTORID e talves o DIRECTOR  
        public Movie(Title title, Description? description, GenreEnumerator? genre, short? durationInMinutes, DateOnly? releaseDate, double? rating, int directorId)
        {
            Validate(title, description, genre, durationInMinutes, releaseDate, rating);
            Title = title;
            Description = description;
            Genre = genre;
            DurationInMinutes = durationInMinutes;
            ReleaseDate = releaseDate;
            Rating = rating;
            DirectorId = directorId;
            // Director = GetDirectorByIdAsync(directorId);
        }

        // Methods
        private void Validate(Title title, Description? description, GenreEnumerator? genre, short? durationInMinutes, DateOnly? releaseDate, double? rating) {
            DomainExceptionValidation.HasError(title.MovieTitle.Length <= 1, "The movie title must be 1 or more characters long");
            DomainExceptionValidation.HasError(title.MovieTitle.Length >= 20, "The movie title must be 20 or less characters long");

            DomainExceptionValidation.HasError(description.MovieDescription.Length <= 10, "The movie description must be 10 or more characters long");
            DomainExceptionValidation.HasError(description.MovieDescription.Length > 255, "The movie description must be 255 or less characters long");

            DomainExceptionValidation.HasError(description.MovieDescription is " ", "Movie description cannot be white space");

            DomainExceptionValidation.HasError(!Enum.IsDefined(typeof(GenreEnumerator), genre), "The genre doesn't exist");

            DomainExceptionValidation.HasError(durationInMinutes <= 0, "The movie duration cannot be negative");
            DomainExceptionValidation.HasError(durationInMinutes > 600, "The movie duration cannot be more than 600 minutes");

            DomainExceptionValidation.HasError(releaseDate < new DateOnly(1985, 12, 28), "The movie release date cannot be inferior than 1985-12-28");

            DomainExceptionValidation.HasError(rating < 0, "The movie rating cannot be negative");
        }

        private void UpdateMovie(Title title, Description? description, GenreEnumerator? genre, short? durationInMinutes, DateOnly? releaseDate, double? rating) {
            Validate(title, description, genre, durationInMinutes, releaseDate, rating);

            Title = title;
            Description = description;
            Genre = genre;
            DurationInMinutes = durationInMinutes;
            ReleaseDate = releaseDate;
            Rating = rating;
        }
    }
}