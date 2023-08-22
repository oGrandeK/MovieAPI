using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.WebAPI.DTOs;

public class GetMoviesDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public GenreEnumerator? Genre { get; set; }
    public short? DurationInMinutes { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public double? Rating { get; set; }

    public DirectorDTO Director { get; set; }
}