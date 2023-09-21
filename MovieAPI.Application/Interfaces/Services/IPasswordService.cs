namespace MovieAPI.Application.Interfaces.Services;

public interface IPasswordService
{
    public string Hash(string password);

    public bool Verify(string hash, string password);
}