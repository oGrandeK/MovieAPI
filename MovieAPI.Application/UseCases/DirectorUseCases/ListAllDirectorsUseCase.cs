using MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.DirectorUseCases;

public class ListAllDirectorsUseCase : IListAllDirectorsUseCase
{
    private readonly IDirectorRepository _directorRepository;

    public ListAllDirectorsUseCase(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task<IEnumerable<Director>> Execute()
    {
        try
        {
            var directors = await _directorRepository.GetDirectorsMoviesAsync();

            foreach (var director in directors)
            {
                if (director.Movies != null && director.Movies.Count > 3)
                    director.Movies.RemoveRange(3, director.Movies.Count - 3);
            }

            return directors;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
            throw;
        }
    }
}