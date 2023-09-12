#nullable enable

using System.Text.Json.Serialization;
using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Entities;

public class Director : Entity 
{
    // Properties
    public Name Name { get; private set; } = null!;

    // Navegation Properties
    public int? MovieId { get; set; }
    public List<Movie>? Movies { get; set; }

    // Constructors
    [JsonConstructor]
    public Director(Name name)
    {
        ValidateName(name);
    }

    public Director(int id, Name name) {
        if(id < 1) throw new DomainExceptionValidation("Id não pode ser inferior a 1");

        Id = id;

        ValidateName(name);
    }

    private Director() {}

    // Methods
    private static Name ValidateName(Name name) {
        var nameParts = name.ToString().Split(" ");

        return new Name(nameParts[0], nameParts[1]);
    }

    public void UpdateName(Name name) {
        Name = ValidateName(name);
    }
}