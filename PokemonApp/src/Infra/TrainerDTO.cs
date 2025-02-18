namespace PokemonApp.src;

public record TrainerDto
{
    public required string Name { get; set; }
    public int Age { get; set; }
}