using MovieAPI.WebAPI.DTOs.Directors;

namespace MovieAPI.WebAPI.DTOs.Directors;

public record GetDirectorsDTO(int Id, string FullName, List<DirectorsMoviesDetailsDTO>? Movies);
