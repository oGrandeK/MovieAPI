using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Validation;
using MovieAPI.WebAPI.DTOs.Directors;

namespace MovieAPI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectorController : ControllerBase
{
    private readonly IDirectorService _directorService;

    public DirectorController(IDirectorService directorService)
    {
        _directorService = directorService;
    }

    [HttpGet("v1/directors")]
    public async Task<IActionResult> GetAllDirectors()
    {
        try
        {
            var directors = await _directorService.ListAllDirectors();
            var directorsDTO = directors.Select(director => new GetDirectorsDTO(
                director.Id,
                FullName: director.Name.ToString(),
                Movies: director.Movies?.Select(movie => new DirectorsMoviesDetailsDTO(
                    Title: movie.Title,
                    Genre: movie.Genre ?? null,
                    ReleaseDate: movie.ReleaseDate != null ? movie.ReleaseDate.Value.ToShortDateString() : string.Empty,
                    Rating: movie.Rating ?? null)).ToList()
                ));
            return Ok(directorsDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpGet("v1/directors/{id:int}")]
    public async Task<IActionResult> GetDirectorById(int id)
    {
        try
        {
            var director = await _directorService.ListDirectorById(id);
            var directorDTO = new GetDirectorsDTO(
                id,
                director.Name.ToString(),
                director.Movies?.Select(movie => new DirectorsMoviesDetailsDTO(
                    movie.Title,
                    movie.Genre ?? null,
                    movie.ReleaseDate != null ? movie.ReleaseDate.Value.ToShortDateString() : string.Empty,
                    movie.Rating ?? null
                )).ToList());

            return Ok(directorDTO);
        }
        catch (DomainExceptionValidation ex)
        {
            return NotFound($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpGet("v1/directors/{name}")]
    public async Task<IActionResult> GetDirectorsByName(string name)
    {
        try
        {
            var directors = await _directorService.ListDirectorByName(name);
            var directorsDTO = directors.Select(director => new GetDirectorsDTO(
                director.Id,
                director.Name.ToString(),
                director.Movies?.Select(movie => new DirectorsMoviesDetailsDTO(
                    movie.Title,
                    movie.Genre ?? null,
                    movie.ReleaseDate != null ? movie.ReleaseDate.Value.ToLongDateString() : string.Empty,
                    movie.Rating ?? null
                )).ToList()
            ));
            return Ok(await _directorService.ListDirectorByName(name));
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpPost("v1/directors")]
    public async Task<IActionResult> AddDirector(CreateDirectorDTO directorData)
    {
        try
        {
            var newDirector = new Director(directorData.Name);
            await _directorService.AddDirector(newDirector);
            return CreatedAtAction(nameof(GetDirectorById), new { id = newDirector.Id }, newDirector);
        }
        catch (DomainExceptionValidation ex)
        {
            return BadRequest($"Error message: {ex.Message} \nError stacktrace: {ex.StackTrace}");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpPut("v1/directors/{id:int}")]
    public async Task<IActionResult> UpdateDirector(int id, CreateDirectorDTO directorData)
    {
        try
        {
            var director = new Director(directorData.Name);
            await _directorService.UpdateDirector(id, director);
            return Ok(director);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpDelete("v1/directors/{id:int}")]
    public async Task<IActionResult> DeleteDirector(int id)
    {
        try
        {
            var director = await _directorService.ListDirectorById(id);
            await _directorService.DeleteDirector(director.Id);
            return Ok(director);
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
}