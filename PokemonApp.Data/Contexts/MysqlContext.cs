using Microsoft.EntityFrameworkCore;
using PokemonApp.Domain;

namespace PokemonApp.Data;

public class MysqlContext : DbContext
{
    public DbSet<Pokemon> Pokemons => Set<Pokemon>();
    public DbSet<Trainer> Trainers => Set<Trainer>();

    public MysqlContext(DbContextOptions<MysqlContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseMySQL("Server=localhost;Database=pokedb;User=pokeuser;Password=pokepass;Port=3306;");
    }
}