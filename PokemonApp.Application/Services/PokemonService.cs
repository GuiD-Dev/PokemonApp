using Newtonsoft.Json;
using PokemonApp.Data;
using PokemonApp.Domain;

namespace PokemonApp.Aplication;

public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository;
    public PokemonService(IPokemonRepository pokemonRepository) => _pokemonRepository = pokemonRepository;

    public IEnumerable<Pokemon> GetPokemonsByColor(Color color)
    {
        return _pokemonRepository.GetPokemonsByColor(color);
    }

    public IEnumerable<IGrouping<Color, Pokemon>> GetPokemonsGroupedByColor()
    {
        return _pokemonRepository.GetPokemonsGroupedBy(p => p.Color);
    }

    public async Task<IEnumerable<PokeListByColor>> GetPokemonsFromAPI()
    {
        using var client = new HttpClient();
        var respose = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon?limit=100");
        var resultado = JsonConvert.DeserializeObject<PokeResult>(await respose.Content.ReadAsStringAsync());
        var tasks = resultado.results.Select(async poke =>
        {
            var pokeResponse = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon-species/{poke.name}");
            var pokemon = JsonConvert.DeserializeObject<Poke>(await pokeResponse.Content.ReadAsStringAsync());
            return pokemon;
        });

        var teste = await Task.WhenAll(tasks);
        return teste.GroupBy(r => r.color.name).Select(g => new PokeListByColor { Color = g.Key, Pokemons = g.Select(p => p.name) });
    }
}

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