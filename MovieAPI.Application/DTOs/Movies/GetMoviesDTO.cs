namespace MovieAPI.Application.DTOs.Movies;

/// <summary>
/// DTO para obter informações sobre filmes.
/// </summary>
/// <param name="Id">Obtém o ID do filme.</param>
/// <param name="Title">Obtém o título do filme.</param>
/// <param name="Description">Obtém a descrição do filme.</param>
/// <param name="Genre">Obtém o gênero do filme.</param>
/// <param name="DurationInMinutes">Obtém a duração do filme em minutos.</param>
/// <param name="ReleaseDate">Obtém a data de lançamento do filme.</param>
/// <param name="Rating">Obtém a classificação do filme.</param>
/// <param name="DirectorName">Obtém o nome do diretor associado ao filme.</param>
public record GetMoviesDTO(int Id, string Title, string? Description, string? Genre, short? DurationInMinutes, string? ReleaseDate, double? Rating, string DirectorName);