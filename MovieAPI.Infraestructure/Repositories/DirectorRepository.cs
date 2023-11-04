using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;
using MovieAPI.Infraestructure.Context;

namespace MovieAPI.Infraestructure.Repositories;

/// <summary>
/// Implementação do repositório para operações relacionadas a diretores no banco de dados.
/// </summary>
public class DirectorRepository : IDirectorRepository
{
    private readonly ApplicationContext _context;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DirectorRepository"/>.
    /// </summary>
    /// <param name="context">O contexto do banco de dados.</param>
    public DirectorRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Director>> GetDirectorsMoviesAsync() => await _context.Directors.Include(x => x.Movies).AsNoTracking().ToListAsync();

    /// <inheritdoc/>
    public async Task<Director> GetDirectorMoviesByIdAsync(int id) => await _context.Directors.Include(x => x.Movies).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id) ?? throw new DomainExceptionValidation($"Director cannot be found by id - {id}");

    /// <inheritdoc/>
    public async Task<IEnumerable<Director>> GetDirectorsMoviesByNameAsync(string directorName)
    {
        var names = directorName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var query = _context.Directors.Include(x => x.Movies).AsNoTracking();

        foreach (var name in names)
        {
            query = query.Where(x => x.Name.FirstName.Contains(name) || x.Name.LastName.Contains(name));
        }

        var directors = await query.ToListAsync();

        if (directors.Count == 0) throw new DomainExceptionValidation($"Director cannot by found by name - {directorName}");

        return directors;
    }

    /// <inheritdoc/>
    public async Task<Director> CreateDirectorAsync(Director director)
    {
        var directorExist = await DirectorExist(director.Name);

        if (!directorExist)
        {
            await _context.Directors.AddAsync(director);
            await _context.SaveChangesAsync();

            return director;
        }

        throw new DomainExceptionValidation("Director already exists");
    }

    /// <inheritdoc/>
    public async Task<Director> UpdateDirectorAsync(Director director)
    {
        _context.Directors.Update(director);
        await _context.SaveChangesAsync();

        return director;
    }

    /// <inheritdoc/>
    public async Task<Director> DeleteDirectorAsync(Director director)
    {
        _context.Directors.Remove(director);
        await _context.SaveChangesAsync();

        return director;
    }

    /// <summary>
    /// Verifica se o diretor já existe no banco de dados.
    /// </summary>
    /// <param name="directorName">O nome do diretor a ser verificado.</param>
    /// <returns>True se o diretor já existir no banco de dados; caso contrário False.</returns>
    public async Task<bool> DirectorExist(string directorName)
    {
        try
        {
            var existingDirector = await GetDirectorsMoviesByNameAsync(directorName);
            return true;
        }
        catch (DomainExceptionValidation)
        {
            return false;
        }
    }
}