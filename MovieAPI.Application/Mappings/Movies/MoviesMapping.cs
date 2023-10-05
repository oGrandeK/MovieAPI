using AutoMapper;
using MovieAPI.Application.DTOs.Movies;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Mappings.Movies;

public class MoviesMapping : Profile
{
    public MoviesMapping()
    {
        CreateMap<Movie, CreateMovieDTO>();
        CreateMap<CreateMovieDTO, Movie>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.DirectorId, opt => opt.MapFrom(src => src.DirectorId))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
            .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.DurationInMinutes))
            .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating));

        CreateMap<Movie, GetMoviesDTO>()
            .ForMember(dst => dst.DirectorName, opt => opt.MapFrom(x => x.Director.Name))
            .ReverseMap();
    }
}