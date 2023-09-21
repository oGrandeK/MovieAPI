using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Infraestructure.Context;
using MovieAPI.WebAPI.DTOs.Users;

namespace MovieAPI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IPasswordService _passwordService;
    private readonly ITokenService _tokenService;

    public UserController(ApplicationContext applicationContext, IPasswordService passwordService, ITokenService tokenService)
    {
        _context = applicationContext;
        _passwordService = passwordService;
        _tokenService = tokenService;
    }

    [HttpPost("v1/accounts/register")]
    public async Task<IActionResult> Register(CreateUserDTO user)
    {
        var hashedPassword = _passwordService.Hash(user.Password);
        var newUser = new User(user.FullName, user.Email, hashedPassword);
        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();

        return Ok(newUser);
    }

    [HttpPost("v1/accounts/login")]
    public async Task<IActionResult> Login(User userData)
    {
        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == userData.Email) ?? throw new Exception("Usuário ou senha inválido");
        if (!_passwordService.Verify(user.Password.Hash, userData.Password)) throw new Exception("Usuário ou senha inválido");

        var token = _tokenService.GenerateToken(user);
        return Ok(token);
    }

    [Authorize]
    [HttpGet("v1/accounts/teste")]
    public IActionResult TESTE()
    {
        return Ok();
    }
}