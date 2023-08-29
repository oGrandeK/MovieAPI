using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Interfaces;
using MovieAPI.Application.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.WebAPI.DTOs;

namespace MovieAPI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectorController : ControllerBase
{
    private readonly IDirectorRepository _directorRepository;

    public DirectorController(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    [HttpGet("v1/directors")]
    public async Task<IActionResult> GetDirectorsAsync() {
        var directors = await _directorRepository.GetDirectorsMoviesAsync();
        
        var directorsDto = directors.Select(director => new GetDirectorDTO {
            Id = director.Id,
            Name = director.Name,
            Movies = director?.Movies?.Select(x => x.Title.MovieTitle).ToList()
        }).ToList();

        return Ok(directorsDto);
    }

    [HttpGet("v1/directors/{id:int}")]
    public async Task<IActionResult> GetDirectorMovieByIdAsync(int id) {
        var director = await _directorRepository.GetDirectorMoviesByIdAsync(id) ?? null;
        if(director is null) return NotFound($"Cannot find Director by id - {id}");

        var directorDto = new GetDirectorDTO {
            Id = id,
            Name = director.Name,
            Movies = director?.Movies?.Select(x => x.Title.MovieTitle).ToList()
        };

        return Ok(directorDto);
    }

    [HttpGet("v1/directors/{name}")]
    public async Task<IActionResult> GetDirectorMovieByNameAsync(string name) {
        var directors = await _directorRepository.GetDirectorsMoviesByNameAsync(name.Trim());
        var directorDto = directors.Select(director => new GetDirectorDTO {
            Id = director.Id,
            Name = director.Name,
            Movies = director?.Movies?.Select(x => x.Title.MovieTitle).ToList()
        });

        return Ok(directorDto);
    }

    [HttpPost("v1/directors")]
    public async Task<IActionResult> CreateDirectorAsync(CreateDirectorDTO directorDto) {
        var director = new Director(directorDto.Name);

        await _directorRepository.CreateDirectorAsync(director);

        return Created($"api/director/v1/directors/{director.Id}", directorDto);
    }

    [HttpPut("v1/directors/{id:int}")]
    public async Task<IActionResult> UpdateDirectorAsync(int id, CreateDirectorDTO directorData) {
        var director = await _directorRepository.GetDirectorMoviesByIdAsync(id) ?? null;
        if(director is null) return NotFound($"Cannot find Director by id - {id}");

        director.UpdateName(directorData.Name);

        await _directorRepository.UpdateDirectorAsync(director);

        return Ok(director);
    }

    [HttpDelete("v1/directors/{id:int}")]
    public async Task<IActionResult> DeleteDirectorAsync(int id) {
        var director = await _directorRepository.GetDirectorMoviesByIdAsync(id) ?? null;
        if(director is null) return NotFound($"Cannot find Director by id - {id}");

        await _directorRepository.DeleteDirectorAsync(director);

        return Ok(director);
    }
}