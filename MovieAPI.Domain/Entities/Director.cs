#nullable enable

using System.Text.Json.Serialization;
using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Entities;

/// <summary> 
/// Representa um diretor de filmes.
/// </summary>
public class Director : Entity
{
    // Properties
    /// <summary>
    /// Obtém ou define nome do diretor.
    /// </summary>
    public Name Name { get; private set; } = null!;

    // Navegation Properties
    /// <summary>
    /// Obtém ou define o ID do filme associado ao diretor.
    /// </summary>
    public int? MovieId { get; set; }

    /// <summary>
    /// Obtém ou define a lista de filmes dirigidos pelo diretor.
    /// </summary>
    public List<Movie>? Movies { get; set; }

    // Constructors
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Director"/>.
    /// </summary>
    /// <param name="name">O nome do diretor. Consulte <see cref="Name"/> para mais detalhes sobre nome. </param>
    [JsonConstructor]
    public Director(Name name)
    {
        Name = ValidateName(name);
    }

    /// <summary>
    /// Construtor usado para criar um diretor com ID específico.
    /// </summary>
    /// <param name="id">O ID do diretor.</param>
    /// <param name="name">O nome do diretor.</param>
    /// <exception cref="DomainExceptionValidation">Disparada se alguma das propriedades violar alguma regra de validação.</exception>
    public Director(int id, Name name)
    {
        if (id < 1) throw new DomainExceptionValidation("Id não pode ser inferior a 1");

        Id = id;
        Name = name;

        Name = ValidateName(name);
    }

    /// <summary>
    /// Construtor privado sem parâmetros para permitir a criação via ORM ou serialização.
    /// </summary>
    private Director() { }

    // Methods
    /// <summary>
    /// Método para validar nome do diretor.
    /// </summary>
    /// <param name="name">O nome a ser validado.</param>
    /// <returns>O nome validado</returns>
    /// <exception cref="DomainExceptionValidation">Disparada se o nome violar alguma regra de validação. Consulte <see cref="Name"/> para mais detalhes sobre nome.</exception>
    //TODO: Aprimorar a validação.
    private static Name ValidateName(Name name)
    {
        var nameParts = name.ToString().Split(" ");

        return new Name(nameParts[0], nameParts[1]);
    }

    /// <summary>
    /// Método para atualizar nome do diretor.
    /// </summary>
    /// <param name="name">O novo nome do diretor.</param>
    /// <exception cref="DomainExceptionValidation">Disparada se o nome violar alguma regra de validação. Consulte <see cref="Name"/> para mais detalhes sobre nome.</exception>
    public void UpdateName(Name name)
    {
        Name = ValidateName(name);
    }

    /// <summary>
    /// Converte a entidade em uma representação de string, usando o nome do diretor.
    /// </summary>
    /// <returns>O nome do diretor como string.</returns>
    public override string ToString() => Name;
}