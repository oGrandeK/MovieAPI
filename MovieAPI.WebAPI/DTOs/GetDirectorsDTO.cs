using MovieAPI.Domain.Entities;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.WebAPI.DTOs;

public class GetDirectorDTO
{
    public int Id { get; set; }
    public Name Name { get; set; }
    public List<string>? Movies { get; set; }
}