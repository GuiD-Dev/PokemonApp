namespace PokemonApp.Data;

public record TrainerDto
{
    public required string Name { get; set; }
    public int Age { get; set; }
}