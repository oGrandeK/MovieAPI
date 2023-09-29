using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.WebAPI.DTOs.Users;

namespace MovieAPI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IPasswordService _passwordService;
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    public UserController(IPasswordService passwordService, ITokenService tokenService, IUserService userService, IUserRepository userRepository = null)
    {
        _passwordService = passwordService;
        _tokenService = tokenService;
        _userService = userService;
        _userRepository = userRepository;
    }

    [HttpPost("v1/accounts/register")]
    public async Task<IActionResult> Register(RegisterUserDTO user)
    {
        var hashedPassword = _passwordService.Hash(user.Password);
        var newUser = new User(user.Name, user.Email, hashedPassword);
        await _userService.AddUser(newUser);

        return Ok(newUser);
    }

    [HttpPost("v1/accounts/login")]
    public async Task<IActionResult> Login(LoginUserDTO userData)
    {
        var user = await _userService.ListUserByEmail(userData.Email);
        if (!_passwordService.Verify(user.Password.Hash, userData.Password)) throw new Exception("Usuário ou senha inválido");

        if (!user.Email.Verification.IsActive) return BadRequest("Email não verificado");

        var token = _tokenService.GenerateToken(user);
        return Ok(token);
    }

    [HttpPost("v1/accounts/verifyEmail/{verificatinCode}")]
    public async Task<IActionResult> VerifyEmail(string verificatinCode, string email)
    {
        var user = await _userService.ListUserByEmail(email);
        _userService.VerifyEmail(verificatinCode, user);
        await _userRepository.UpdateUserAsync(user);

        var response = (user.Email, " Email ativado com sucesso");

        return Ok(response);
    }

    [HttpPost("v1/accounts/resendVerificationCode/{email}")]
    public async Task<IActionResult> Resend(string email)
    {
        var user = await _userService.ListUserByEmail(email);
        user.Email.ResendVerification();
        await _userRepository.UpdateUserAsync(user);

        return Ok(user.Email.Verification.Code);
    }

    [Authorize]
    [HttpGet("v1/accounts/teste")]
    public IActionResult TESTE()
    {
        return Ok();
    }

    //TODO: Criar maneira de reenviar código de verificação
}