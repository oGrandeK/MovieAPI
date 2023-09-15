using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Application.Interfaces.UseCases.MovieUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;

namespace MovieAPI.Application.Services;

public class MovieService : IMovieService
{
    private readonly IAddMovieUseCase _addMovieUseCase;
    private readonly IDeleteMovieUseCase _deleteMovieUseCase;
    private readonly IUpdateMovieUseCase _updateMovieUseCase;
    private readonly IListAllMoviesUseCase _listAllMoviesUseCase;
    private readonly IListMovieByIdUseCase _listMovieByIdUseCase;
    private readonly IListMoviesByGenreUseCase _listMoviesByGenreUseCase;
    private readonly IListMoviesByTitleUseCase _listMoviesByTitleUseCase;

    public MovieService(IAddMovieUseCase addMovieUseCase, IDeleteMovieUseCase deleteMovieUseCase, IUpdateMovieUseCase updateMovieUseCase, IListAllMoviesUseCase listAllMoviesUseCase, IListMovieByIdUseCase listMovieByIdUseCase, IListMoviesByGenreUseCase listMoviesByGenreUseCase, IListMoviesByTitleUseCase listMoviesByTitleUseCase)
    {
        _addMovieUseCase = addMovieUseCase;
        _deleteMovieUseCase = deleteMovieUseCase;
        _updateMovieUseCase = updateMovieUseCase;
        _listAllMoviesUseCase = listAllMoviesUseCase;
        _listMovieByIdUseCase = listMovieByIdUseCase;
        _listMoviesByGenreUseCase = listMoviesByGenreUseCase;
        _listMoviesByTitleUseCase = listMoviesByTitleUseCase;
    }

    public async Task AddMovie(Movie movieData) => await _addMovieUseCase.Execute(movieData);

    public async Task DeleteMovie(int id) => await _deleteMovieUseCase.Execute(id);

    public async Task<IEnumerable<Movie>> ListAllMovies() => await _listAllMoviesUseCase.Execute();

    public async Task<Movie> ListMovieById(int id) => await _listMovieByIdUseCase.Execute(id);

    public async Task<IEnumerable<Movie>> ListMoviesByGenre(GenreEnumerator genre) => await _listMoviesByGenreUseCase.Execute(genre);

    public async Task<IEnumerable<Movie>> ListMoviesByTitle(string title) => await _listMoviesByTitleUseCase.Execute(title);

    public async Task UpdateMovie(int id, Movie movieData) => await _updateMovieUseCase.Execute(id, movieData);
}