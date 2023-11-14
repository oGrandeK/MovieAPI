namespace MovieAPI.Application.DTOs.Movies;

/// <summary>
/// DTO para criação de filmes.
/// </summary>
/// <param name="Title">Define o título do filme.</param>
/// <param name="Description">Define a descrição do filme.</param>
/// <param name="Genre">Define o gênero do filme.</param>
/// <param name="DurationInMinutes">Define a duração do filme em minutos.</param>
/// <param name="ReleaseDate">Define a data de lançamento do filme.</param>
/// <param name="Rating">Define a classificação do filme.</param>
/// <param name="DirectorId">Define o ID do diretor associado ao filme.</param>
public record CreateMovieDTO(string Title, string? Description, string? Genre, short? DurationInMinutes, string? ReleaseDate, double? Rating, int DirectorId);