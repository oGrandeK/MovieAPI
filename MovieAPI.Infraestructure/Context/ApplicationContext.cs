using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Infraestructure.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    public DbSet<Director> Directors { get; set; }
    public DbSet<Movie> Movies { get; set; }
}