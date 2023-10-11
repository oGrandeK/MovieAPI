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
    private readonly IRegisterUserUseCase _RegisterUserUseCase;
    private readonly IUpdateUserUseCase _UpdateUserUseCase;
    private readonly IDeleteUserUseCase _DeleteUserUseCase;
    private readonly IVerifyEmailUseCase _VerifyEmailUseCase;
    private readonly IResendEmailVerificationCodeUseCase _ResendEmailVerificationCodeUseCase;
    private readonly IChangePasswordUseCase _ChangePasswordUseCase;

    public UserService(IListAllUsersUseCase listAllUsersUseCase, IListUserByIdUseCase listUserByIdUseCase, IListUserByEmailUseCase listUserByEmailUseCase, IListUsersByNameUseCase listUsersByNameUseCase, IUpdateUserUseCase updateUserUseCase, IDeleteUserUseCase deleteUserUseCase, IVerifyEmailUseCase verifyEmailUseCase, IResendEmailVerificationCodeUseCase resendEmailVerificationCodeUseCase, IChangePasswordUseCase changePasswordUseCase, IRegisterUserUseCase registerUserUseCase)
    {
        _listAllUsersUseCase = listAllUsersUseCase;
        _listUserByIdUseCase = listUserByIdUseCase;
        _listUserByEmailUseCase = listUserByEmailUseCase;
        _listUsersByNameUseCase = listUsersByNameUseCase;
        _UpdateUserUseCase = updateUserUseCase;
        _DeleteUserUseCase = deleteUserUseCase;
        _VerifyEmailUseCase = verifyEmailUseCase;
        _ResendEmailVerificationCodeUseCase = resendEmailVerificationCodeUseCase;
        _ChangePasswordUseCase = changePasswordUseCase;
        _RegisterUserUseCase = registerUserUseCase;
    }

    public async Task<IEnumerable<User>> ListAllUsers() => await _listAllUsersUseCase.Execute();
    public async Task<User> ListUserById(int id) => await _listUserByIdUseCase.Execute(id);
    public async Task<User> ListUserByEmail(string email) => await _listUserByEmailUseCase.Execute(email);
    public async Task<IEnumerable<User>> ListUserByName(string fullname) => await _listUsersByNameUseCase.Execute(fullname);
    public async Task<User> UpdateUser(int id, User user, string newHash) => await _UpdateUserUseCase.Execute(id, user, newHash);
    public async Task<User> DeleteUser(int id) => await _DeleteUserUseCase.Execute(id);
    public async Task<User> VerifyEmail(string verificatinCode, string email) => await _VerifyEmailUseCase.Verify(verificatinCode, email);
    public async Task<User> ResendEmailVerificationCode(string email) => await _ResendEmailVerificationCodeUseCase.Resend(email);
    public async Task<User> UpdatePassword(User user, string oldPassword, string newPassword) => await _ChangePasswordUseCase.Change(user, oldPassword, newPassword);

    public async Task<User> RegisterUser(string firstName, string lastName, string email, string password) => await _RegisterUserUseCase.Register(firstName, lastName, email, password);
}