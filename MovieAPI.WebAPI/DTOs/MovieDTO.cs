using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.WebAPI.DTOs;

public class MovieDTO
{
    public int Id { get; set; }
    public Title Title { get; set; }
    public string? Description { get; set; }
    public GenreEnumerator? Genre { get; set; }
    public short? DurationInMinutes { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public double? Rating { get; set; }

    public int DirectorId { get; set; }
    public Director Director { get; set; }
}