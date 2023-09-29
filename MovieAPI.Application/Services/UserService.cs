using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Services;

public class UserService : IUserService
{
    private readonly IListAllUsersUseCase _listAllUsersUseCase;
    private readonly IListUserByIdUseCase _listUserByIdUseCase;
    private readonly IListUserByEmailUseCase _listUserByEmailUseCase;
    private readonly IListUsersByNameUseCase _listUsersByNameUseCase;
    private readonly IAddUserUseCase _AddUserUseCase;
    private readonly IUpdateUserUseCase _UpdateUserUseCase;
    private readonly IDeleteUserUseCase _DeleteUserUseCase;
    private readonly IVerifyEmailUseCase _VerifyEmailUseCase;

    public UserService(IListAllUsersUseCase listAllUsersUseCase, IListUserByIdUseCase listUserByIdUseCase, IListUserByEmailUseCase listUserByEmailUseCase, IListUsersByNameUseCase listUsersByNameUseCase, IAddUserUseCase addUserUseCase, IUpdateUserUseCase updateUserUseCase, IDeleteUserUseCase deleteUserUseCase, IVerifyEmailUseCase verifyEmailUseCase)
    {
        _listAllUsersUseCase = listAllUsersUseCase;
        _listUserByIdUseCase = listUserByIdUseCase;
        _listUserByEmailUseCase = listUserByEmailUseCase;
        _listUsersByNameUseCase = listUsersByNameUseCase;
        _AddUserUseCase = addUserUseCase;
        _UpdateUserUseCase = updateUserUseCase;
        _DeleteUserUseCase = deleteUserUseCase;
        _VerifyEmailUseCase = verifyEmailUseCase;
    }

    public async Task<IEnumerable<User>> ListAllUsers() => await _listAllUsersUseCase.Execute();
    public async Task<User> ListUserById(int id) => await _listUserByIdUseCase.Execute(id);
    public async Task<User> ListUserByEmail(string email) => await _listUserByEmailUseCase.Execute(email);
    public async Task<IEnumerable<User>> ListUserByName(string fullname) => await _listUsersByNameUseCase.Execute(fullname);
    public async Task<User> AddUser(User user) => await _AddUserUseCase.Execute(user);
    public async Task<User> UpdateUser(int id, User user, string newHash) => await _UpdateUserUseCase.Execute(id, user, newHash);
    public async Task<User> DeleteUser(int id) => await _DeleteUserUseCase.Execute(id);
    public async Task<User> VerifyEmail(string verificatinCode, string email) => await _VerifyEmailUseCase.Verify(verificatinCode, email);

}