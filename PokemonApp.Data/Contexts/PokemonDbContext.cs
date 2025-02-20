using Microsoft.EntityFrameworkCore;
using PokemonApp.Domain;

namespace PokemonApp.Data;

public class Context : DbContext
{
    public DbSet<Pokemon> Pokemons => Set<Pokemon>();
    public DbSet<Trainer> Trainers => Set<Trainer>();

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("Teste");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Color>(entity =>
        // {
        //     entity.ToTable("COLORS");
        //     entity.HasKey(c => c.Id);
        //     entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
        // });

        // modelBuilder.Entity<Pokemon>(entity =>
        // {
        //     entity.ToTable("POKEMONS");
        //     entity.HasKey(p => p.Id);
        //     entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
        //     entity.HasOne(p => p.Color)
        //           .WithMany(c => c.Pokemons)
        //           .HasForeignKey(p => p.ColorId);
        // });

        base.OnModelCreating(modelBuilder);

        var trainers = new List<Trainer>
        {
            new() { Id = 1, Name = "Ash", Age = 10 },
            new() { Id = 2, Name = "Misty", Age = 10 },
            new() { Id = 3, Name = "Brock", Age = 12 },
        };
        modelBuilder.Entity<Trainer>().HasData(trainers);

        var pokemons = new List<Pokemon>
        {
            new() { Id = 1, Name = "Charizard", Color = Color.Red, TrainerId = trainers[0].Id },
            new() { Id = 2, Name = "Starmie", Color = Color.Blue, TrainerId = trainers[1].Id },
            new() { Id = 3, Name = "Vulpix", Color = Color.Red, TrainerId = trainers[2].Id },
            new() { Id = 4, Name = "Bulbasaur", Color = Color.Green, TrainerId = trainers[0].Id },
            new() { Id = 5, Name = "Metapod", Color = Color.Green, TrainerId = trainers[0].Id },
        };
        modelBuilder.Entity<Pokemon>().HasData(pokemons);
    }
}