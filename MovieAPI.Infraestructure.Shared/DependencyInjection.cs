using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;
using MovieAPI.Application.Interfaces.UseCases.MovieUseCases;
using MovieAPI.Application.Services;
using MovieAPI.Application.UseCases.DirectorUseCases;
using MovieAPI.Application.UseCases.MovieUsecases;
using MovieAPI.Domain.interfaces;
using MovieAPI.Infraestructure.Context;
using MovieAPI.Infraestructure.Repositories;

namespace MovieAPI.Infraestructure.Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

        services.AddScoped<IDirectorRepository, DirectorRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();

        services.AddTransient<IEmailService, SendGridEmailService>();
        services.AddTransient<ISmsService, TwilioSmsService>();

        services.AddScoped<IDirectorService, DirectorService>();
        services.AddScoped<IMovieService, MovieService>();

        services.AddScoped<IAddDirectorUseCase, AddDirectorUseCase>();
        services.AddScoped<IDeleteDirectorUseCase, DeleteDirectorUseCase>();
        services.AddScoped<IListAllDirectorsUseCase, ListAllDirectorsUseCase>();
        services.AddScoped<IListDirectorByIdUseCase, ListDirectorByIdUseCase>();
        services.AddScoped<IListDirectorsByNameUseCase, ListDirectorsByNameUseCase>();
        services.AddScoped<IUpdateDirectorUseCase, UpdateDirectorUseCase>();
        services.AddScoped<IAddMovieUseCase, AddMovieUseCase>();
        services.AddScoped<IDeleteMovieUseCase, DeleteMovieUseCase>();
        services.AddScoped<IListAllMoviesUseCase, ListAllMoviesUseCase>();
        services.AddScoped<IListMovieByIdUseCase, ListMovieByIdUseCase>();
        services.AddScoped<IListMoviesByGenreUseCase, ListMoviesByGenreUseCase>();
        services.AddScoped<IListMoviesByTitleUseCase, ListMoviesByTitleUseCase>();
        services.AddScoped<IUpdateMovieUseCase, UpdateMovieUseCase>();

        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IPasswordService, PasswordService>();

        return services;
    }
}