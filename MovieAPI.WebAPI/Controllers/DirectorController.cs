using Microsoft.AspNetCore.Mvc;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

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
    public async Task<IActionResult> PostDirectorAsync([FromBody]Director directorData) {
        var director = await _directorRepository.CreateDirectorAsync(directorData);

        return Ok(director);
    }

    // TODO: Adicionar o Update e o Delete
}