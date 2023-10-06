namespace MovieAPI.Application.DTOs.Movies;

public record CreateMovieDTO(string Title, string? Description, string? Genre, short? DurationInMinutes, string? ReleaseDate, double? Rating, int DirectorId);