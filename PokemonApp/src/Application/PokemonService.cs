namespace PokemonApp.src;

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
}