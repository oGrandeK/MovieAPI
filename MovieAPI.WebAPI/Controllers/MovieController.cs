using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.Intrinsics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;
using MovieAPI.WebAPI.DTOs;

namespace MovieAPI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("v1/movies")]
    public async Task<IActionResult> GetAllMovies()
    {
        try
        {
            return Ok(await _movieService.ListAllMovies());
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpGet("v1/movies/{id:int}")]
    public async Task<IActionResult> GetMovieById(int id)
    {
        try
        {
            return Ok(await _movieService.ListMovieById(id));
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
            return Ok(await _movieService.ListMoviesByGenre(genre));
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
    public async Task<IActionResult> AddMovie(Movie movieData)
    {
        try
        {
            var newMovie = new Movie(movieData.Title, movieData.DirectorId, movieData.Description, movieData.Genre, movieData.DurationInMinutes, movieData.ReleaseDate, movieData.Rating);
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
    public async Task<IActionResult> UpdateMovie(int id, Movie movieData)
    {
        try
        {
            var movie = movieData;
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
            var movie = await _movieService.ListMovieById(id);
            await _movieService.DeleteMovie(movie.DirectorId);
            return Ok(movie);
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