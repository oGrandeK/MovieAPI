#nullable enable

using System;
using System.Text.Json.Serialization;
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
        public string? Description { get; private set; }
        public GenreEnumerator? Genre { get; private set; }
        public short? DurationInMinutes { get; private set; }
        public DateOnly? ReleaseDate { get; private set; }
        public double? Rating { get; private set; }

        // Navigation Properties
        public int DirectorId { get; set; }
        public Director Director { get; set; }

        // Constructors
        public Movie(Title title, string? description, GenreEnumerator? genre, short? durationInMinutes, DateOnly? releaseDate, double? rating, int directorId)
        {
            Validate(title, description, genre, durationInMinutes, releaseDate, rating);
            DirectorId = directorId;
        }

        public Movie(int id, Title title, string? description, GenreEnumerator? genre, short? durationInMinutes, DateOnly? releaseDate, double? rating, int directorId)
        {
            Validate(title, description, genre, durationInMinutes, releaseDate, rating);
            DirectorId = directorId;
            Id = id;
        }

        private Movie() {}

        // Methods
        private void Validate(Title title, string? description, GenreEnumerator? genre, short? durationInMinutes, DateOnly? releaseDate, double? rating) {
            // Starting validations
            DomainExceptionValidation.HasError(title is null, "Movie title cannot be null");

            var trimmedTitle = new Title(title?.MovieTitle?.Trim() ?? "");
            if(description is not null) description = description.Trim();

            DomainExceptionValidation.HasError(trimmedTitle.MovieTitle.Length <= 1, "Movie title must be 1 or more characters long");
            DomainExceptionValidation.HasError(trimmedTitle.MovieTitle.Length > 50, "Movie title must be 50 or less characters long");
            DomainExceptionValidation.HasError(string.IsNullOrEmpty(trimmedTitle.MovieTitle), "Movie title cannot be empty or consist of only whitespace");
            DomainExceptionValidation.HasError(trimmedTitle.MovieTitle.Equals(" "), "Movie title cannot be white space");
            DomainExceptionValidation.HasError(trimmedTitle.MovieTitle.Any(ch => char.IsPunctuation(ch)), "Movie title cannot be special character");

            DomainExceptionValidation.HasError(description.Length < 10, "Movie description must be 10 or more characters long");
            DomainExceptionValidation.HasError(description.Length > 255, "Movie description must be 255 or less characters long");

            DomainExceptionValidation.HasError(!Enum.IsDefined(typeof(GenreEnumerator), genre), "The genre doesn't exist");

            DomainExceptionValidation.HasError(durationInMinutes < 0, "Movie duration cannot be negative");
            DomainExceptionValidation.HasError(durationInMinutes > 600, "Movie duration cannot be more than 600 minutes");

            DomainExceptionValidation.HasError(releaseDate < new DateOnly(1888, 10, 14), "Movie release date cannot be inferior than 1985-12-28");

            DomainExceptionValidation.HasError(rating < 0, "Movie rating cannot be negative");

            // Seting attributes
            Title = title;
            Description = description;
            Genre = genre;
            DurationInMinutes = durationInMinutes;
            ReleaseDate = releaseDate;
            Rating = rating;
        }

        public void UpdateMovie(Title title, string? description, GenreEnumerator? genre, short? durationInMinutes, DateOnly? releaseDate, double? rating, int directorId) {
            Validate(title, description, genre, durationInMinutes, releaseDate, rating);
            DomainExceptionValidation.HasError(directorId < 0, "directorId cannot be inferior than 0");
            DirectorId = directorId;
        }
    }
}