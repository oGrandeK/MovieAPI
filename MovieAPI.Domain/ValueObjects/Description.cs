namespace MovieAPI.Domain.ValueObjects;

public class Description
{
    public string MovieDescription { get; set; }

    public Description(string movieDescription)
    {
        MovieDescription = movieDescription;
    }
}