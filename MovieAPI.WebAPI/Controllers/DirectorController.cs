using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Interfaces;
using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Application.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;
using MovieAPI.WebAPI.DTOs;

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
    public async Task<IActionResult> GetAllDirector() => Ok(await _directorService.ListAllDirectors());

    [HttpGet("v1/directors/{id:int}")]
    public async Task<IActionResult> GetDirectorById(int id) {
        try
        {
            return Ok(await _directorService.ListDirectorById(id));
        }
        catch (DomainExceptionValidation ex)
        {
            return NotFound($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
        catch(Exception ex) {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpGet("v1/directors/{name}")]
    public async Task<IActionResult> GetDirectorsByName(string name) {
        try
        {
            return Ok(await _directorService.ListDirectorByName(name));
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpPost("v1/directors")]
    public async Task<IActionResult> AddDirector(Director directorData) {
        try
        {
            var newDirector = new Director(directorData.Name);
            await _directorService.AddDirector(newDirector);
            return CreatedAtAction($"{nameof(GetDirectorById)}", new { id = newDirector.Id }, newDirector);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpPut("v1/directors/{id:int}")]
    public async Task<IActionResult> UpdateDirector(int id, Director directorData) {
        try
        {
            var director = directorData;
            await _directorService.UpdateDirector(id, director);
            return Ok(director);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }

    [HttpDelete("v1/directors/{id:int}")]
    public async Task<IActionResult> DeleteDirector(int id) {
        try
        {
            var director = await _directorService.ListDirectorById(id);
            await _directorService.DeleteDirector(director.Id);
            return Ok(director);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error message: {ex.Message}; \nError stacktrace: {ex.StackTrace}");
        }
    }
}