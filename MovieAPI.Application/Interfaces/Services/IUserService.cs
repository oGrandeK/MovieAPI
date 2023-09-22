using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAllUsers();
    Task<User> ListUserById(int id);
    Task<User> ListUserByEmail(string email);
    Task<IEnumerable<User>> ListUserByName(string fullname);
    Task<User> AddUser(User user);
    Task<User> UpdateUser(int id, User user, string newHash);
    Task<User> DeleteUser(int id);
}