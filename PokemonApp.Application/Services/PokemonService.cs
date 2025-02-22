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

    public async Task<Dictionary<string, List<string>>> GetPokemonsFromAPI()
    {
        var respose = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon?limit=100");
        var pokeResponse = JsonConvert.DeserializeObject<PokeAPIResponse>(await respose.Content.ReadAsStringAsync());

        var tasks = pokeResponse.results.Select(async poke =>
        {
            var specieResponse = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon-species/{poke.name}");
            var pokemon = JsonConvert.DeserializeObject<PokeSpecie>(await specieResponse.Content.ReadAsStringAsync());
            return pokemon;
        });

        var pokeSpecies = await Task.WhenAll(tasks);

        return pokeSpecies.GroupBy(r => r.color.name)
            .ToDictionary(
                g => g.Key,
                g => g.Select(p => p.name).ToList()
            );
    }
}
