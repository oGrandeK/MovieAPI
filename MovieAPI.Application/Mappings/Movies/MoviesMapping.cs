using AutoMapper;
using MovieAPI.Application.DTOs.Movies;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Mappings.Movies;

public class MoviesMapping : Profile
{
    public MoviesMapping()
    {
        CreateMap<Movie, CreateMovieDTO>().ReverseMap();
        CreateMap<Movie, GetMoviesDTO>()
        .ForMember(dst => dst.DirectorName, opt => opt.MapFrom(x => x.Director.Name))
        .ReverseMap();
    }
}