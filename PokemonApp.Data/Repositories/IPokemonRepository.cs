using PokemonApp.Domain;

namespace PokemonApp.Data;

public interface IPokemonRepository
{
    public IEnumerable<Pokemon> GetAll();
    public IEnumerable<Pokemon> GetPokemonsByColor(Color color);
    public IEnumerable<IGrouping<T, Pokemon>> GetPokemonsGroupedBy<T>(Func<Pokemon, T> predicate);
}