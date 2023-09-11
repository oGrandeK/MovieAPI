using MovieAPI.Domain.interfaces;
using SecureIdentity.Password;

namespace MovieAPI.Infraestructure.Services;

public class PasswordService : IPasswordService
{
    public string Hash(string password) => PasswordHasher.Hash(password);

    public bool Verify(string hash, string password) => PasswordHasher.Verify(hash, password);
}