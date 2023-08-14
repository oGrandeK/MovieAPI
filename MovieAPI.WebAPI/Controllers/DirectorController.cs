using Microsoft.AspNetCore.Mvc;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;

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

        return Ok(directors);
    }

    [HttpGet("v1/directors/{id:int}")]
    public async Task<IActionResult> GetDirectorMovieByIdAsync(int id) {
        var director = await _directorRepository.GetDirectorMoviesByIdAsync(id);

        return Ok(director);
    }

    [HttpGet("v1/directors/{name}")]
    public async Task<IActionResult> GetDirectorMovieByNameAsync(string name) {
        var director = await _directorRepository.GetDirectorsMoviesByNameAsync(name);

        return Ok(director);
    }

    [HttpPost("v1/directors")]
    public async Task<IActionResult> CreateDirectorAsync([FromBody]Director directorData) {
        var director = await _directorRepository.CreateDirectorAsync(directorData);

        return Ok(director);
    }

    [HttpPut("v1/directors/{id:int}")]
    public async Task<IActionResult> UpdateDirectorAsync([FromQuery]int id, [FromBody]Director directorData) {
        var director = await _directorRepository.GetDirectorMoviesByIdAsync(id) ?? null;
        if(director is null) return NotFound(director);

        director.UpdateName(directorData.Name);

        await _directorRepository.UpdateDirectorAsync(director);

        return Ok(director);
    }

    [HttpDelete("v1/directors/{id:int}")]
    public async Task<IActionResult> DeleteDirectorAsync([FromQuery]int id) {
        var director = await _directorRepository.GetDirectorMoviesByIdAsync(id) ?? null;
        if(director is null) return NotFound(director);

        await _directorRepository.DeleteDirectorAsync(director);

        return Ok(director);
    }
}