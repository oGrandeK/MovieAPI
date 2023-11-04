using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using MovieAPI.Infraestructure.EntitiesConfiguration;

namespace MovieAPI.Infraestructure.Context;

/// <summary>
/// Representa o contexto de banco de dados para a aplicação.
/// </summary>
public class ApplicationContext : DbContext
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ApplicationContext"/>.
    /// </summary>
    /// <param name="options">As opções de configuração do contexto.</param>
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    /// <summary>
    /// Obtém ou define um conjunto de entidades de diretores no contexto do banco de dados.
    /// </summary>
    public DbSet<Director> Directors { get; set; } = null!;

    /// <summary>
    /// Obtém ou define um conjunto de entidades de filmes no contexto do banco de dados.
    /// </summary>
    public DbSet<Movie> Movies { get; set; } = null!;

    /// <summary>
    /// Obtém ou define um conjunto de entidades de usuários no contexto do banco de dados.
    /// </summary>
    public DbSet<User> Users { get; set; } = null!;

    /// <summary>
    /// Configura o modelo de banco de dados durante a inicialização.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new DirectorConfiguration());
        builder.ApplyConfiguration(new MovieConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
    }
}