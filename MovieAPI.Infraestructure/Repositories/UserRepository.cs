using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;
using MovieAPI.Infraestructure.Context;

namespace MovieAPI.Infraestructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync() => await _context.Users.Include(x => x.Name).Include(x => x.Email).Include(x => x.Password).AsNoTracking().ToListAsync();
    public async Task<User> GetUserByIdAsync(int id) => await _context.Users.Include(x => x.Name).Include(x => x.Email).Include(x => x.Password).FirstOrDefaultAsync(x => x.Id == id) ?? throw new DomainExceptionValidation($"User cannot be found by id - {id}");
    public async Task<IEnumerable<User>> GetUsersByNameAsync(string fullname)
    {
        var names = fullname.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var query = _context.Users.Include(x => x.Name).Include(x => x.Email).Include(x => x.Password);

        foreach (var name in names)
        {
            query.Where(x => x.Name.FirstName.Contains(name) || x.Name.LastName.Contains(name));
        }

        var users = await query.ToListAsync();

        if (users.Count == 0) throw new DomainExceptionValidation($"User cannot be found by name - {fullname}");

        return users;
    }
    public async Task<User> GetUserByEmailAsync(string email) => await _context.Users.Include(x => x.Name).Include(x => x.Email).Include(x => x.Password).FirstOrDefaultAsync(x => x.Email.Address == email) ?? throw new DomainExceptionValidation($"User cannot bet found by email - {email}");
    public async Task<User> CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return user;
    }
    public async Task<User> DeleteUserAsync(User user)
    {
        _context.Remove(user);
        await _context.SaveChangesAsync();

        return user;
    }
}