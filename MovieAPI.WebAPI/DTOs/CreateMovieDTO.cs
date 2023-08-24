using System.Text.Json.Serialization;
using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.WebAPI.DTOs;

public class CreateMovieDTO
{
    public TitleDto Title { get; set; }
    public string? Description { get; set; }
    public GenreEnumerator? Genre { get; set; }
    public short? DurationInMinutes { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public double? Rating { get; set; }

    public int DirectorId { get; set; }
}