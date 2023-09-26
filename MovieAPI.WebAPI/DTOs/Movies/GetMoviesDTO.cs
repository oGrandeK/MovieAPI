namespace MovieAPI.WebAPI.DTOs.Movies;

public record GetMoviesDTO(int Id, string Title, string? Description, string? Genre, short? DurationInMinutes, string? ReleaseDate, double? Rating, string Director);