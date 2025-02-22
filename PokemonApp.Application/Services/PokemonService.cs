using Newtonsoft.Json;
using PokemonApp.Data;
using PokemonApp.Domain;

namespace PokemonApp.Aplication;

public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly HttpClient _httpClient;

    public PokemonService(IPokemonRepository pokemonRepository, HttpClient httpClient)
    {
        _pokemonRepository = pokemonRepository;
        _httpClient = httpClient;
    }

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
        var respose = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon?limit=100");
        var resultado = JsonConvert.DeserializeObject<PokeResult>(await respose.Content.ReadAsStringAsync());
        var tasks = resultado.results.Select(async poke =>
        {
            var pokeResponse = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon-species/{poke.name}");
            var pokemon = JsonConvert.DeserializeObject<Poke>(await pokeResponse.Content.ReadAsStringAsync());
            return pokemon;
        });

        var teste = await Task.WhenAll(tasks);
        return teste.GroupBy(r => r.color.name).Select(g => new PokeListByColor { Color = g.Key, Pokemons = g.Select(p => p.name) });
    }
}
