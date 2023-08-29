using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieAPI.Application.Interfaces;
using MovieAPI.Application.Services;
using MovieAPI.Domain.interfaces;
using MovieAPI.Infraestructure.Context;
using MovieAPI.Infraestructure.Repositories;

namespace MovieAPI.Infraestructure.Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

        services.AddTransient<IDirectorRepository, DirectorRepository>();
        services.AddTransient<IMovieRepository, MovieRepository>();

        services.AddSingleton<IEmailService, SendGridEmailService>();
        services.AddSingleton<ISmsService, TwilioSmsService>();

        return services;
    }
}