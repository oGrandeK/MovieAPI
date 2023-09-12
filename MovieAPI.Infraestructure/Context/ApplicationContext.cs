using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using MovieAPI.Infraestructure.EntitiesConfiguration;

namespace MovieAPI.Infraestructure.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    public DbSet<Director> Directors { get; set; } = null!;
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new DirectorConfiguration());
        builder.ApplyConfiguration(new MovieConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
    }
}