using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;
using MovieAPI.Infraestructure.Context;

namespace MovieAPI.Infraestructure.Repositories;

public class DirectorRepository : IDirectorRepository
{
    private readonly ApplicationContext _context;

    public DirectorRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Director>> GetDirectorsMoviesAsync()
    {
        return await _context.Directors.Include(x => x.Movies).AsNoTracking().ToListAsync();
    }

    public async Task<Director> GetDirectorMoviesByIdAsync(int id)
    {
        return await _context.Directors.Include(x => x.Movies).FirstOrDefaultAsync(x => x.Id == id) ?? throw new DomainExceptionValidation($"Director cannot be found by id - {id}");
    }

    public async Task<IEnumerable<Director>> GetDirectorsMoviesByNameAsync(string directorName)
    {
        var test = directorName.Split(" ");
        return await _context.Directors.Include(x => x.Movies).AsNoTracking().Where(x => x.Name.FirstName.Contains(test[0]) || x.Name.FirstName.Contains(test[1]) || x.Name.LastName.Contains(test[0]) || x.Name.LastName.Contains(test[1])).ToListAsync();
        //return await _context.Directors.Include(x => x.Movies).AsNoTracking().Where(x => x.Name.FirstName.Contains(directorName) || x.Name.LastName.Contains(directorName)).ToListAsync();
    }

    public async Task<Director> CreateDirectorAsync(Director director)
    {
        _context.Directors.Add(director);
        await _context.SaveChangesAsync();

        return director;
    }

    public async Task<Director> UpdateDirectorAsync(Director director)
    {
        _context.Directors.Update(director);
        await _context.SaveChangesAsync();

        return director;
    }

    public async Task<Director> DeleteDirectorAsync(Director director)
    {
        _context.Directors.Remove(director);
        await _context.SaveChangesAsync();

        return director;
    }
}