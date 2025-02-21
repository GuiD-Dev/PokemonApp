using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PokemonApp.Domain;

public class Trainer
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    [JsonIgnore]
    public ICollection<Pokemon> Pokemons { get; set; }
}
