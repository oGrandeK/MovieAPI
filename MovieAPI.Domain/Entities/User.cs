using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Entities;

//TODO: Refatorar a classe.

/// <summary>
/// Classe que representa um usuário.
/// </summary>
public class User : Entity
{
    /// <summary>
    /// Obtém ou define um nome para o usuário.
    /// </summary>
    public Name Name { get; private set; }
    /// <summary>
    /// Obtém ou define um email para o usuário.
    /// </summary>
    public Email Email { get; private set; }
    /// <summary>
    /// Obtém ou define uma senha para o usuário.
    /// </summary>
    public Password Password { get; private set; }

    /// <summary>
    /// Construtor privado e sem parâmetros para permitir a criação via ORM e serialização.
    /// </summary>
    private User()
    {

    }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="User"/>.
    /// </summary>
    /// <param name="name">O nome do usuário.</param>
    /// <param name="email">O email do usuário.</param>
    /// <param name="hashedPassword">A senha já hasheada do usuário.</param>
    public User(Name name, string email, string hashedPassword)
    {
        Name = name;
        Email = email;
        Password = hashedPassword;
    }

    /// <summary>
    /// Método para atualizar o usuário.
    /// </summary>
    /// <param name="fullname">O novo nome completo do usuário.</param>
    /// <param name="email">O novo email do usuário.</param>
    /// <param name="hash">A nova hash do usuário.</param>
    //TODO: Verificar se o parâmetro hash é realmente necessário.
    public void UpdateUser(string fullname, string email, string hash)
    {
        var names = fullname.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        Name = new Name(names[0], names[1]);
        Email = email;
        Password = hash;
    }

    /// <summary>
    /// Método para atualizar a senha do usuário.
    /// </summary>
    /// <param name="hash">A nova senha do usuário já hasheada. Veja <see cref="Password"/> para mais detalhes sobre senhas.</param>
    public void UpdatePassword(string hash)
    {
        Password = hash;
    }
}