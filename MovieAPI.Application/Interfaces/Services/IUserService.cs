using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.Services;

/// <summary>
/// Interface para serviços relacionados aos usuários.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Retorna todos os usuários.
    /// </summary>
    /// <returns>Uma coleção de <see cref="User"/>.</returns>
    Task<IEnumerable<User>> ListAllUsers();

    /// <summary>
    /// Retorna um único <see cref="User"/> com base no ID informado.
    /// </summary>
    /// <param name="id">O ID a ser procurado.</param>
    /// <returns>Um único <see cref="User"/> que corresponde ao ID informado.</returns>
    Task<User> ListUserById(int id);

    /// <summary>
    /// Retorna um único <see cref="User"/> com base no e-mail informado.
    /// </summary>
    /// <param name="email">O e-mail a ser procurado.</param>
    /// <returns>Um único <see cref="User"/> que corresponde ao e-mail informado.</returns>
    Task<User> ListUserByEmail(string email);

    /// <summary>
    /// Retorna uma coleção de <see cref="User"/> com base no nome informado.
    /// </summary>
    /// <param name="fullname">O nome a ser procurado.</param>
    /// <returns>Uma coleção de <see cref="User"/> que correspondem ao nome informado.</returns>
    Task<IEnumerable<User>> ListUserByName(string fullname);

    /// <summary>
    /// Registra um novo usuário.
    /// </summary>
    /// <param name="firstName">O primeiro nome do usuário.</param>
    /// <param name="lastName">O sobrenome do usuário.</param>
    /// <param name="email">O e-mail do usuário.</param>
    /// <param name="password">A senha do usuário.</param>
    /// <returns>O <see cref="User"/> criado com base nas informações.</returns>
    Task<User> RegisterUser(string firstName, string lastName, string email, string password);

    /// <summary>
    /// Efetua o login de um usuário.
    /// </summary>
    /// <param name="email">O e-mail do usuário.</param>
    /// <param name="password">A senha do usuário.</param>
    /// <returns>O token gerado com base nas informações passadas.</returns>
    Task<string> Login(string email, string password);

    /// <summary>
    /// Atualiza um usuário existente.
    /// </summary>
    /// <param name="id">O ID a ser procurado.</param>
    /// <param name="user">Os novos dados do <see cref="User"/>.</param>
    /// <returns>O Novo <see cref="User"/> com as novas informações.</returns>
    // TODO: Remover argumento inútil newHash.
    Task<User> UpdateUser(int id, User user, string newHash);

    /// <summary>
    /// Deleta um usuário pelo ID.
    /// </summary>
    /// <param name="id">O ID a ser procurado.</param>
    /// <returns>O <see cref="User"/> deletado.</returns>
    Task<User> DeleteUser(int id);

    /// <summary>
    /// Verifica se o código de verificação está válido.
    /// </summary>
    /// <param name="verificationCode">O código informado.</param>
    /// <param name="email">O e-mail a ser verificado.</param>
    /// <returns>O <see cref="User"/> com o código verificado.</returns>
    Task<User> VerifyEmail(string verificationCode, string email);

    /// <summary>
    /// Reenvia o código de verificação para o e-mail.
    /// </summary>
    /// <param name="email">O e-mail a receber o novo código de verificação.</param>
    /// <returns>O <see cref="User"/> com o novo código de verificação.</returns>
    Task<User> ResendEmailVerificationCode(string email);

    /// <summary>
    /// Atualiza a senha do usuário.
    /// </summary>
    /// <param name="user">O <see cref="User"/> a ter a senha atualizada.</param>
    /// <param name="oldPassword">A antiga senha do <see cref="User"/> .</param>
    /// <param name="newPassword">A nova senha do <see cref="User"/> .</param>
    /// <returns>O <see cref="User"/> com a senha atualizada.</returns>
    Task<User> UpdatePassword(User user, string oldPassword, string newPassword);
}