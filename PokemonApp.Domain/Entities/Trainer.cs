using System.Text.Json.Serialization;

namespace PokemonApp.Domain;

public class Trainer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    [JsonIgnore]
    public List<Pokemon> Pokemons { get; set; } = new();
}
