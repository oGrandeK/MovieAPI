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
    internal void Validate(Name name) {
        DomainExceptionValidation.HasError(name is null, "Name cannot be null");

        DomainExceptionValidation.HasError(String.IsNullOrWhiteSpace(name.FirstName), "First name cannot be null or white space");
        DomainExceptionValidation.HasError(String.IsNullOrWhiteSpace(name.LastName), "Last name cannot be null or white space");

        DomainExceptionValidation.HasError(name.FirstName.Any(ch => char.IsDigit(ch)), "First name cannot contains digits");
        DomainExceptionValidation.HasError(name.LastName.Any(ch => char.IsDigit(ch)), "Last name cannot contains digits");

        DomainExceptionValidation.HasError(name.FirstName.Any(ch => char.IsPunctuation(ch)), "First name cannot contain special characters");
        DomainExceptionValidation.HasError(name.LastName.Any(ch => char.IsPunctuation(ch)), "Last name cannot contain special characters");

        DomainExceptionValidation.HasError(name.FirstName.Length <= 3, "First name must be 3 or more characters long");
        DomainExceptionValidation.HasError(name.LastName.Length < 3, "Last name must be 3 or more characters long");

        DomainExceptionValidation.HasError(name.FirstName.Length >= 30, "First name must be 30 or less characters");
        DomainExceptionValidation.HasError(name.LastName.Length >= 30, "Last name must be 30 or less characters");

    }

    private void UpdateName(Name name) {
        Validate(name);
        Name = name;
    }

    private void AddMovie(Movie movie) {
        Movies.Add(movie);
    }

    internal void Validate()
    {
        throw new NotImplementedException();
    }
}