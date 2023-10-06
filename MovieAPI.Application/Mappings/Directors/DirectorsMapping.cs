using AutoMapper;
using MovieAPI.Application.DTOs.Directors;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Mappings.Directors;

public class DirectorsMapping : Profile
{
    public DirectorsMapping()
    {
        CreateMap<Movie, MovieDTO>();

        CreateMap<Director, GetDirectorsDTO>()
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies.Select(x => new MovieDTO(x.Id, x.Title, x.ReleaseDate.ToString() ?? string.Empty))));
    }
}