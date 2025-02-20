using PokemonApp.Domain;

namespace PokemonApp.Aplication;

public interface IPokemonService
{
    IEnumerable<Pokemon> GetPokemonsByColor(Color color);
    IEnumerable<IGrouping<Color, Pokemon>> GetPokemonsGroupedByColor();
    Task<IEnumerable<PokeListByColor>> GetPokemonsFromAPI();
}