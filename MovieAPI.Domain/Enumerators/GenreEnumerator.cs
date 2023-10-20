using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MovieAPI.Domain.Enumerators;

//TODO: Adicionar mais gêneros.

/// <summary>
/// Enumeração que representa gêneros de filmes.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GenreEnumerator
{
    /// <summary>
    /// Ação.
    /// </summary>
    [EnumMember(Value = "Action")]
    Action = 1,
    /// <summary>
    /// Horror.
    /// </summary>
    [EnumMember(Value = "Horror")]
    Horror = 2,
    /// <summary>
    /// Comédia.
    /// </summary>
    [EnumMember(Value = "Comedy")]
    Comedy = 3,
    /// <summary>
    /// Drama.
    /// </summary>
    [EnumMember(Value = "Drama")]
    Drama = 4,
    /// <summary>
    /// Aventura.
    /// </summary>
    [EnumMember(Value = "Adventure")]
    Adventure = 5
}