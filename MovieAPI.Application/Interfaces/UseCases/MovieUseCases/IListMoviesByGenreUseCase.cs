using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

public interface IListMoviesByGenreUseCase
{
    public Task<IEnumerable<Movie>> Execute(GenreEnumerator genre);
}