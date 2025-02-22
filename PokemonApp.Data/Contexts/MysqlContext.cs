using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PokemonApp.Domain;

namespace PokemonApp.Data;

public class MysqlContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Pokemon> Pokemons => Set<Pokemon>();
    public DbSet<Trainer> Trainers => Set<Trainer>();

    public MysqlContext(DbContextOptions<MysqlContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
    }
}