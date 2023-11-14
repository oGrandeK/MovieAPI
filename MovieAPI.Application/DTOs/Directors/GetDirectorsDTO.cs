namespace MovieAPI.Application.DTOs.Directors;

/// <summary>
/// DTO para obter informações sobre diretores.
/// </summary>
/// <param name="Id">Obtém o ID do diretor.</param>
/// <param name="Name">Obtém o nome do diretor.</param>
/// <param name="Movies">Obtém a lista de filmes associados ao diretor.</param>
public record GetDirectorsDTO(int Id, string Name, List<MovieDTO>? Movies);

/// <summary>
/// DTO para obter informações sobre filmes associados a diretores.
/// </summary>
/// <param name="Id">Obtém o ID do filme.</param>
/// <param name="Title">Obtém o título do filme.</param>
/// <param name="ReleaseDate">Obtém a data de lançamento do filme.</param>
public record MovieDTO(int Id, string Title, string ReleaseDate);