using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieAPI.Infraestructure.Context;

namespace MovieAPI.Infraestructure.Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<ApplicationContext>( options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

        return services;
    }
}