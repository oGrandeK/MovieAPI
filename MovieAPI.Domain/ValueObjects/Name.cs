namespace MovieAPI.Domain.ValueObjects;

public class Name
{
    public string FirstName { get; set; }   
    public string LastName { get; set; }

    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}