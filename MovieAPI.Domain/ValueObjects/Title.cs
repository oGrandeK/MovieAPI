namespace MovieAPI.Domain.ValueObjects;

public class Title : ValueObject
{
    public string MovieTitle { get; private set; }

    public Title(string title)  
    {
        MovieTitle = title;
    }

    private Title() {}
}