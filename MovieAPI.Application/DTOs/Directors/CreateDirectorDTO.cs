using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Application.DTOs.Directors;

/// <summary>
/// DTO para criação de um Diretor.
/// </summary>
/// <param name="Name">Obtém ou define o nome do diretor. veja <see cref="Domain.ValueObjects.Name"/> para obter mais detalhes.</param>
public record CreateDirectorDTO(Name Name);