using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.DTOs.Movies;
using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.Validation;
using MovieAPI.WebAPI.DTOs.Movies;

namespace MovieAPI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;
    private readonly IMapper _mapper;

    public MovieController(IMovieService movieService, IMapper mapper)
    {
        _movieService = movieService;
        _mapper = mapper;
    }

    [HttpGet("v1/movies")]
    public async Task<IActionResult> GetAllMovies()
    {
        // try
        // {
        //     var movies = await _movieService.ListAllMovies();

        //     var moviesDTO = movies.Select(movie => new GetMoviesDTO(
        //         movie.Id,
        //         movie.Title,
        //         movie.Description ?? string.Empty,
        //         movie.Genre.ToString(),
        //         movie.DurationInMinutes ?? default,
        //         movie.ReleaseDate != null ? movie.ReleaseDate.Value.ToShortDateString() : string.Empty,
        //         movie.Rating ?? default,
        //         movie.Director?.Name ?? string.Empty
        //     ));

        //     return Ok(moviesDTO);
        // }
        // catch (Exception ex)
        // {
        //     return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        // }

        var movies = await _movieService.ListAllMovies();
        var moviesDTO = _mapper.Map<IEnumerable<Application.DTOs.Movies.GetMoviesDTO>>(movies);

        return Ok(moviesDTO);
    }

    [HttpGet("v1/movies/{id:int}")]
    public async Task<IActionResult> GetMovieById(int id)
    {
        try
        {
            var movie = await _movieService.ListMovieById(id);
            var movieDTO = new DTOs.Movies.GetMoviesDTO(
                id,
                movie.Title,
                movie.Description ?? string.Empty,
                movie.Genre.ToString(),
                movie.DurationInMinutes ?? default,
                movie.ReleaseDate != null ? movie.ReleaseDate.Value.ToShortDateString() : string.Empty,
                movie.Rating ?? default,
                movie.Director?.Name ?? string.Empty
            );

            return Ok(movieDTO);
        }
        catch (DomainExceptionValidation ex)
        {
            return NotFound($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpGet("v1/movies/genre/{genre}")]
    public async Task<IActionResult> GetMovieByGenre(GenreEnumerator genre)
    {
        try
        {
            var movies = await _movieService.ListMoviesByGenre(genre);
            var moviesDTO = movies.Select(movie => new DTOs.Movies.GetMoviesDTO(
                movie.Id,
                movie.Title,
                movie.Description ?? string.Empty,
                movie.Genre.ToString(),
                movie.DurationInMinutes ?? default,
                movie.ReleaseDate != null ? movie.ReleaseDate.Value.ToShortDateString() : string.Empty,
                movie.Rating ?? default,
                movie.Director?.Name ?? string.Empty
            ));

            return Ok(moviesDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpGet("v1/movies/{title}")]
    public async Task<IActionResult> GetMoviesByTitle(string title)
    {
        try
        {
            return Ok(await _movieService.ListMoviesByTitle(title));
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpPost("v1/movies")]
    public async Task<IActionResult> AddMovie(DTOs.Movies.CreateMovieDTO movieData)
    {
        try
        {
            GenreEnumerator? genre = !string.IsNullOrEmpty(movieData.Genre) ? (GenreEnumerator)Enum.Parse(typeof(GenreEnumerator), movieData.Genre, true) : null;

            var newMovie = new Movie(movieData.Title, movieData.Director, movieData.Description, genre, movieData.DurationInMinutes, DateTime.Parse(movieData.ReleaseDate ?? string.Empty), movieData.Rating);
            await _movieService.AddMovie(newMovie);
            return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.Id }, newMovie);
        }
        catch (DomainExceptionValidation ex)
        {
            return BadRequest($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpPut("v1/movies/{id:int}")]
    public async Task<IActionResult> UpdateMovie(int id, DTOs.Movies.CreateMovieDTO movieData)
    {
        try
        {
            GenreEnumerator? genre = !string.IsNullOrEmpty(movieData.Genre) ? (GenreEnumerator)Enum.Parse(typeof(GenreEnumerator), movieData.Genre, true) : null;

            var movie = new Movie(movieData.Title, movieData.Director, movieData.Description, genre, movieData.DurationInMinutes, DateTime.Parse(movieData.ReleaseDate ?? string.Empty), movieData.Rating);
            await _movieService.UpdateMovie(id, movie);
            return Ok(movie);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpDelete("v1/movies/{id:int}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        try
        {
            await _movieService.DeleteMovie(id);
            return Ok();
        }
        catch (DomainExceptionValidation ex)
        {
            return NotFound($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
    }
}