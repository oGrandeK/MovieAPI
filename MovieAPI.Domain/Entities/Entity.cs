namespace MovieAPI.Domain.Entities;

/// <summary>
/// Representa uma entidade básica com uma propriedade de identificação.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Obtém ou define o identificador único da entidade.
    /// </summary>
    public int Id { get; protected set; }
}