namespace PokemonApp.Aplication;


public struct PokeResult
{
    public List<Poke> results { get; set; }
}

public struct Poke
{
    public string name { get; set; }
    public PokeColor color { get; set; }
}

public struct PokeColor
{
    public string name { get; set; }
}

public struct PokeListByColor
{
    public string Color { get; set; }
    public IEnumerable<string> Pokemons { get; set; }
}