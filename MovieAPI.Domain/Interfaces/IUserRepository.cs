using MovieAPI.Domain.Entities;

namespace MovieAPI.Domain.interfaces;

/// <summary>
/// Interface para repositório de usuarios.
/// </summary>
//TODO: Verificar quais exceções podem ser lançadas por cada método.
public interface IUserRepository
{
    /// <summary>
    /// Obtém todos os usuários.
    /// </summary>
    /// <returns>Uma coleção de usuários.</returns>
    Task<IEnumerable<User>> GetAllUsersAsync();

    /// <summary>
    /// Obtém um usuário pelo ID.
    /// </summary>
    /// <param name="id">O ID do usuário a ser pesquisado.</param>
    /// <returns>O usuário encontrado.</returns>
    Task<User> GetUserByIdAsync(int id);

    /// <summary>
    /// Obtém usuário pelo email.
    /// </summary>
    /// <param name="email">O email do usuário a ser pesquisado.</param>
    /// <returns>O usuário encontrado.</returns>
    Task<User> GetUserByEmailAsync(string email);

    /// <summary>
    /// Obtém uma coleção de usuários pelo nome.
    /// </summary>
    /// <param name="fullname">O nome do usuário a ser pesquisado separado por espaço. <example>"John Doe"</example></param>
    /// <returns>Uma coleção de usuários encontrados pelo nome.</returns>
    Task<IEnumerable<User>> GetUsersByNameAsync(string fullname);

    /// <summary>
    /// Cria um novo usuário. Consulte <see cref="User"/> para mais detalhes sobre usuários.
    /// </summary>
    /// <param name="user">O usuário a ser criado.</param>
    /// <returns>O usuário criado.</returns>
    Task<User> CreateUserAsync(User user);

    /// <summary>
    /// Atualiza as informações do usuário.
    /// </summary>
    /// <param name="user">O usuário com as informações atualizadas. Consulte <see cref="User"/> para mais detalhes sobre usuários.</param>
    /// <returns>O usuário atualizado.</returns>
    Task<User> UpdateUserAsync(User user);

    /// <summary>
    /// Deleta o usuário.
    /// </summary>
    /// <param name="user">O usuário a ser deletado. Consulte <see cref="User"/> para mais detalhes sobre usuários.</param>
    /// <returns>O usuário deletado.</returns>
    Task<User> DeleteUserAsync(User user);
}