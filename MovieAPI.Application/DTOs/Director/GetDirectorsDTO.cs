namespace MovieAPI.Application.DTOs.Directors;

public record GetDirectorsDTO(int Id, string Name, List<MovieDTO>? Movies);

public record MovieDTO(int Id, string Title);