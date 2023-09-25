using MovieAPI.Domain.Enumerators;

namespace MovieAPI.WebAPI.DTOs.Directors;

public record DirectorsMoviesDetailsDTO(string Title, GenreEnumerator? Genre, string? ReleaseDate, double? Rating);