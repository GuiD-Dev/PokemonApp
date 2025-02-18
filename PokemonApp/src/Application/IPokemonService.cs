namespace PokemonApp.src;

public interface IPokemonService
{
    IEnumerable<Pokemon> GetPokemonsByColor(Color color);
    IEnumerable<IGrouping<Color, Pokemon>> GetPokemonsGroupedByColor();
    // void GetPokemonsFromAPI();
}