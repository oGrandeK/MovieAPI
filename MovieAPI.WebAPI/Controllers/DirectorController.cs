using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.DTOs.Directors;
using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Validation;

namespace MovieAPI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectorController : ControllerBase
{
    private readonly IDirectorService _directorService;
    private readonly IMapper _mapper;

    public DirectorController(IDirectorService directorService, IMapper mapper)
    {
        _directorService = directorService;
        _mapper = mapper;
    }

    [HttpGet("v1/directors")]
    public async Task<IActionResult> GetAllDirectors([FromQuery] int page = 1)
    {
        try
        {
            int pageSize = 3;

            var directors = await _directorService.ListAllDirectors();

            var paginatedDirectors = directors.Skip((page - 1) * pageSize).Take(pageSize);

            var directorsDTO = _mapper.Map<IEnumerable<GetDirectorsDTO>>(paginatedDirectors);

            return Ok(directorsDTO);
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

    [HttpGet("v1/directors/{id:int}")]
    public async Task<IActionResult> GetDirectorById(int id)
    {
        try
        {
            var director = await _directorService.ListDirectorById(id);
            var directorDTO = _mapper.Map<GetDirectorsDTO>(director);

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
            var directorsDTO = _mapper.Map<IEnumerable<GetDirectorsDTO>>(directors);
            return Ok(directorsDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [Authorize]
    [HttpPost("v1/directors")]
    public async Task<IActionResult> AddDirector(CreateDirectorDTO directorData)
    {
        try
        {
            var newDirector = _mapper.Map<Director>(directorData);
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

    [Authorize]
    [HttpPut("v1/directors/{id:int}")]
    public async Task<IActionResult> UpdateDirector(int id, CreateDirectorDTO directorData)
    {
        try
        {
            var director = new Director(directorData.Name);
            await _directorService.UpdateDirector(id, director);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [Authorize]
    [HttpDelete("v1/directors/{id:int}")]
    public async Task<IActionResult> DeleteDirector(int id)
    {
        try
        {
            var director = await _directorService.ListDirectorById(id);
            await _directorService.DeleteDirector(director.Id);
            return NoContent();
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