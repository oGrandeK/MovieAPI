using AutoMapper;
using MovieAPI.Application.DTOs.Directors;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Mappings.Directors;

public class DirectorsMapping : Profile
{
    public DirectorsMapping()
    {
        CreateMap<Director, CreateDirectorDTO>().ReverseMap();
        CreateMap<Director, GetDirectorsDTO>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Name.FirstName} {src.Name.LastName}")).ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies)).ReverseMap();
    }
}