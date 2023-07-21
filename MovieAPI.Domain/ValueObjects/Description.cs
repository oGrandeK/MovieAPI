namespace MovieAPI.Domain.ValueObjects;

public class Description : ValueObject
{
    public string MovieDescription { get; set; }

    public Description(string movieDescription)
    {
        MovieDescription = movieDescription;
    }
}