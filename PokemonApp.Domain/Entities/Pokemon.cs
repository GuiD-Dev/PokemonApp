using System.ComponentModel.DataAnnotations;

namespace PokemonApp.Domain;

public class Pokemon
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Height { get; set; }
    public Color Color { get; set; }
    public Trainer Trainer { get; set; }
}
