using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.DTOs.Directors;

public record GetDirectorsDTO(int Id, string FullName, List<Movie>? Movies);