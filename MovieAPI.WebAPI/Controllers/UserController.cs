using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Validation;
using MovieAPI.WebAPI.DTOs.Users;

namespace MovieAPI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IPasswordService _passwordService;
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public UserController(IPasswordService passwordService, ITokenService tokenService, IUserService userService)
    {
        _passwordService = passwordService;
        _tokenService = tokenService;
        _userService = userService;
    }

    [HttpPost("v1/accounts/register")]
    public async Task<IActionResult> Register(RegisterUserDTO user)
    {
        try
        {
            return Ok(await _userService.RegisterUser(user.Name.FirstName, user.Name.LastName, user.Email, user.Password));
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpPost("v1/accounts/login")]
    public async Task<IActionResult> Login(LoginUserDTO userData)
    {
        try
        {
            var user = await _userService.ListUserByEmail(userData.Email);
            if (!_passwordService.Verify(user.Password.Hash, userData.Password)) throw new Exception("Usuário ou senha inválido");

            if (!user.Email.Verification.IsActive) return BadRequest("Email não verificado");

            var token = _tokenService.GenerateToken(user);
            return Ok(token);
        }
        catch (DomainExceptionValidation)
        {
            return BadRequest("Usuário não cadastrado");
        }
    }

    [Authorize]
    [HttpPost("v1/accounts/resetPassword")]
    public async Task<IActionResult> ResetPassword([FromQuery, Required] string email, [FromQuery, Required] string oldPassword, [FromQuery, Required] string newPassword)
    {
        try
        {
            var user = await _userService.ListUserByEmail(email);

            await _userService.UpdatePassword(user, oldPassword, newPassword);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpPost("v1/accounts/verifyEmail")]
    public async Task<IActionResult> VerifyEmail([FromQuery, Required] string email, [FromQuery, Required] string verificationCode)
    {
        try
        {
            return Ok(await _userService.VerifyEmail(verificationCode, email));
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpPost("v1/accounts/resendVerificationCode/{email}")]
    public async Task<IActionResult> Resend(string email)
    {
        try
        {
            return Ok(await _userService.ResendEmailVerificationCode(email));
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
    }
}