using MovieAPI.WebAPI.DTOs.Directors;

namespace MovieAPI.WebAPI.DTOs.Directors;

public record GetDirectorsDTO(string FullName, List<DirectorsMoviesDetailsDTO>? Movies);
