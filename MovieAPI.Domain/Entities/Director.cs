using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Entities;

public class Director : Entity 
{
    // Properties
    public Name Name { get; private set; }

    // Navegation Properties
    public int MovieId { get; set; }
    public List<Movie> Movies { get; set; }

    // Constructors
    public Director(Name name)
    {
        Validate(name);
        Name = name;
        Movies = new List<Movie>();
    }

    // Methods
    // TODO: Validar Name se tiver mais de 30 caracteres, se for null, se for whitespace, se tiver digito, se tiver char especial
    private void Validate(Name name) {
        DomainExceptionValidation.HasError(name is null, "The name cannot be null");

        DomainExceptionValidation.HasError(name.FirstName.Length <= 3, "The first name must be 3 or more characters long");
        DomainExceptionValidation.HasError(name.LastName.Length < 3, "The last name must be 3 or more characters long");

        DomainExceptionValidation.HasError(name.FirstName.Length >= 30, "The first name must be 30 or less characters");
        DomainExceptionValidation.HasError(name.LastName.Length >= 30, "The last name must be 30 or less characters");

    }

    private void UpdateName(Name name) {
        Validate(name);
        Name = name;
    }

    private void AddMovie(Movie movie) {
        Movies.Add(movie);
    }
}