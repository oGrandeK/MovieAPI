using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;
using MovieAPI.Application.Interfaces.UseCases.MovieUseCases;
using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Application.Mappings.Directors;
using MovieAPI.Application.Mappings.Movies;
using MovieAPI.Application.Services;
using MovieAPI.Application.UseCases.DirectorUseCases;
using MovieAPI.Application.UseCases.MovieUsecases;
using MovieAPI.Application.UseCases.UserUseCases;
using MovieAPI.Domain.interfaces;
using MovieAPI.Infraestructure.Context;
using MovieAPI.Infraestructure.Repositories;

namespace MovieAPI.Infraestructure.Shared;

/// <summary>
/// Configuração de injeção de dependência para serviços e casos de uso.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adiciona serviços e casos de uso ä coleção de serviços.
    /// </summary>
    /// <param name="services">A coleção de serviços.</param>
    /// <param name="configuration">A configuração da aplicação.</param>
    /// <returns>A coleção de serviços configurada.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Não foi possivel conectar com o banco"), b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

        services.AddScoped<IDirectorRepository, DirectorRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddTransient<IEmailService, SendGridEmailService>();
        services.AddTransient<ISmsService, TwilioSmsService>();

        services.AddScoped<IDirectorService, DirectorService>();
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IUserService, UserService>();

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

        services.AddTransient<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddTransient<ILoginUseCase, LoginUseCase>();
        services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
        services.AddScoped<IListAllUsersUseCase, ListAllUsersUseCase>();
        services.AddScoped<IListUserByIdUseCase, ListUserByIdUseCase>();
        services.AddScoped<IListUsersByNameUseCase, ListUsersByNameUseCase>();
        services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        services.AddScoped<IListUserByEmailUseCase, ListUserByEmailUseCase>();
        services.AddTransient<IVerifyEmailUseCase, VerifyEmailUseCase>();
        services.AddTransient<IResendEmailVerificationCodeUseCase, ResendEmailVerificationCodeUseCase>();
        services.AddTransient<IChangePasswordUseCase, ChangePasswordUseCase>();

        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IPasswordService, PasswordService>();

        services.AddAutoMapper(typeof(DirectorsMapping), typeof(MoviesMapping));

        return services;
    }
}