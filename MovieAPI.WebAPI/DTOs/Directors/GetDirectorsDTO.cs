using MovieAPI.WebAPI.DTOs.Movies;

namespace MovieAPI.WebAPI.DTOs.Directors;

public record GetDirectorsDTO(string FullName, List<MoviesDetailsDTO>? Movies);
