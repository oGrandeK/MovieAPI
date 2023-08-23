using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
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
    private readonly IMovieRepository _movieRepository;

    public MovieController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpGet("v1/movies")]
    public async Task<IActionResult> GetMoviesDirectorsAsync() {
        var movies = await _movieRepository.GetMoviesDirectorsAsync();

        var moviesDto = movies.Select(movie => new GetMoviesDTO {
            Id = movie.Id,
            Title = movie.Title.MovieTitle,
            Description = movie.Description,
            Genre = movie.Genre,
            DurationInMinutes = movie.DurationInMinutes,
            ReleaseDate = movie.ReleaseDate,
            Rating = movie.Rating,
            Director = new DirectorDTO {
                Id = movie.DirectorId,
                FullName = movie.Director.Name.FirstName + " " + movie.Director.Name.LastName
            }
        }).ToList();

        return Ok(moviesDto);
    }

    [HttpGet("v1/movies/{id:int}")]
    public async Task<IActionResult> GetMoviesDirectorsByIdAsync(int id) {
        var movie = await _movieRepository.GetMovieDirectorsByIdAsync(id) ?? null;
        if(movie is null) return NotFound($"Cannot find movie by id - {id}");

        var movieDto = new GetMoviesDTO {
            Id = movie.Id,
            Title = movie.Title.MovieTitle,
            Description = movie.Description,
            Genre = movie.Genre,
            DurationInMinutes = movie.DurationInMinutes,
            ReleaseDate = movie.ReleaseDate,
            Rating = movie.Rating,
            Director = new DirectorDTO {
                Id = movie.DirectorId,
                FullName = movie.Director.Name.FirstName + " " + movie.Director.Name.LastName
            }
        };

        return Ok(movieDto);
    }

    [HttpGet("v1/movies/name/{name}")]
    public async Task<IActionResult> GetMoviesDirectorsByNameAsync(string name) {
        var movies = await _movieRepository.GetMoviesDirectorsByNameAsync(name);

        return Ok(movies);
    }

    [HttpGet("v1/movies/genre/{genre}")]
    public async Task<IActionResult> GetMoviesDirectorsByGenreAsync(GenreEnumerator genre) {
        var movies = await _movieRepository.GetMoviesDirectorsByGenreAsync(genre);
        var moviesDto = movies.Select(movie => new GetMoviesDTO {
            Id = movie.Id,
            Title = movie.Title.MovieTitle,
            Description = movie.Description,
            Genre = movie.Genre,
            DurationInMinutes = movie.DurationInMinutes,
            ReleaseDate = movie.ReleaseDate,
            Rating = movie.Rating,
            Director = new DirectorDTO {
                Id = movie.DirectorId,
                FullName = movie.Director.Name.FirstName + " " + movie.Director.Name.LastName
            }
        });

        return Ok(moviesDto);
    }

    [HttpPost("v1/movies")]
    public async Task<IActionResult> CreateMovieAsync(CreateMovieDTO movieData) {
        
        var title = new Title(movieData.Title.MovieTitle);
        var movie = new Movie(title, movieData.Description, movieData.Genre, movieData.DurationInMinutes, movieData.ReleaseDate, movieData.Rating, movieData.DirectorId);

        await _movieRepository.CreateMovieAsync(movie);

        return Created($"api/[controller]/v1/{movie.Id}", movie);
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