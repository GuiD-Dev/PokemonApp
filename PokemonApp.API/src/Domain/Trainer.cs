using System.Text.Json.Serialization;

public class Trainer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    [JsonIgnore]
    public List<Pokemon> Pokemons { get; set; } = new();
}
