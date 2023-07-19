namespace MovieAPI.Domain.ValueObjects;

public class Title
{
    public string MovieTitle { get; set; }

    public Title(string title)  
    {
        MovieTitle = title;
    }
}