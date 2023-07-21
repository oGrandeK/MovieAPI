using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Entities;

public class Director : Entity 
{
    // Properties
    public Name Name { get; private set; }

    // Navegation Properties
    public int MovieId { get; set; }
    public List<Movie>? Movies { get; set; }

    // Constructors
    public Director(Name name)
    {
        Validate(name);
        Name = name;
    }

    // Methods
    private void Validate(Name name) {
        DomainExceptionValidation.HasError(name.FirstName.Length <= 3, "The first name must be 3 or more characters long");
        DomainExceptionValidation.HasError(name.LastName.Length < 3, "The last name must be 3 or more characters long");
    }

    private void UpdateName(Name name) {
        Validate(name);
        Name = name;
    }
}