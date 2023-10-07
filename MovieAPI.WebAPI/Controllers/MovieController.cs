using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.DTOs.Movies;
using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.Validation;

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
        var movies = await _movieService.ListAllMovies();
        var moviesDTO = _mapper.Map<IEnumerable<GetMoviesDTO>>(movies);

        return Ok(moviesDTO);
    }

    [HttpGet("v1/movies/{id:int}")]
    public async Task<IActionResult> GetMovieById(int id)
    {
        try
        {
            var movie = await _movieService.ListMovieById(id);
            var movieDTO = _mapper.Map<GetMoviesDTO>(movie);

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
            var moviesDTO = _mapper.Map<IEnumerable<GetMoviesDTO>>(movies);

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
            var movies = await _movieService.ListMoviesByTitle(title);
            var moviesDTO = _mapper.Map<IEnumerable<GetMoviesDTO>>(movies);

            return Ok(moviesDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
    }

    [Authorize]
    [HttpPost("v1/movies")]
    public async Task<IActionResult> AddMovie(CreateMovieDTO movieData)
    {
        try
        {
            var movie = _mapper.Map<Movie>(movieData);
            await _movieService.AddMovie(movie);

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
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

    [Authorize]
    [HttpPut("v1/movies/{id:int}")]
    public async Task<IActionResult> UpdateMovie(int id, CreateMovieDTO movieData)
    {
        try
        {
            var movie = _mapper.Map<Movie>(movieData);
            await _movieService.UpdateMovie(id, movie);
            return Ok(movie);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
    }

    [Authorize]
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