using System.Runtime.Intrinsics;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;

namespace MovieAPI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;

    public MovieController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpGet("v1/movies")]
    public async Task<IActionResult> GetMoviesDirectorsAsync() {
        var movies = await _movieRepository.GetMoviesDirectorsAsync();

        return Ok(movies);
    }

    [HttpGet("v1/movies/{id:int}")]
    public async Task<IActionResult> GetMoviesDirectorsByIdAsync(int id) {
        var movie = await _movieRepository.GetMovieDirectorsByIdAsync(id) ?? null;
        if(movie is null) return NotFound($"Cannot find movie by id - {id}");

        return Ok(movie);
    }

    [HttpGet("v1/movies/{name}")]
    public async Task<IActionResult> GetMoviesDirectorsByNameAsync(string name) {
        var movies = await _movieRepository.GetMoviesDirectorsByNameAsync(name);

        return Ok(movies);
    }

    [HttpGet("v1/movies/{genre}")]
    public async Task<IActionResult> GetMoviesDirectorsByGenreAsync(string genre) {
        var movies = await _movieRepository.GetMoviesDirectorsByGenreAsync(genre);

        return Ok(movies);
    }

    [HttpPost("v1/movies")]
    public async Task<IActionResult> CreateMovieAsync(Movie movieData) {
        var movie = await _movieRepository.CreateMovieAsync(movieData);

        return Created($"api/[controller]/v1/{movieData.Id}", movie);
    }

    [HttpPut("v1/movies/{id:int}")]
    public async Task<IActionResult> UpdateMovieAsync(int id, Movie movieData) {
        var movie = await _movieRepository.GetMovieDirectorsByIdAsync(id) ?? null;
        if(movie is null) return NotFound($"Cannot found Movie by id - {id}");

        movie.UpdateMovie(movieData.Title, movieData.Description, movieData.Genre, movieData.DurationInMinutes, movieData.ReleaseDate, movieData.Rating, movieData.DirectorId);

        await _movieRepository.UpdateMovieAsync(movie);

        return Ok(movie);
    }

    [HttpDelete("v1/movies/{id:int}")]
    public async Task<IActionResult> DeleteMovieAsync(int id) {
        var movie = await _movieRepository.GetMovieDirectorsByIdAsync(id) ?? null;
        if(movie is null) return NotFound($"Movie cannot be found by id - {id}");

        await _movieRepository.DeleteMovieAsync(movie);
        
        return Ok(movie);
    }
}