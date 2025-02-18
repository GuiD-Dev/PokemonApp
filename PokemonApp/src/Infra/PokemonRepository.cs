using Microsoft.EntityFrameworkCore;

namespace PokemonApp.src;

public class PokemonRepository : BaseRepository<Pokemon>, IPokemonRepository
{
    public PokemonRepository(Context context) : base(context) { }

    public IEnumerable<Pokemon> GetAll()
    {
        return _context.Pokemons.ToList();
    }

    public IEnumerable<Pokemon> GetPokemonsByColor(Color color)
    {
        return _context.Pokemons.Include(p => p.Trainer).Where(p => p.Color == color).ToList();
    }

    public IEnumerable<IGrouping<T, Pokemon>> GetPokemonsGroupedBy<T>(Func<Pokemon, T> predicate)
    {
        return _context.Pokemons.Include(p => p.Trainer).GroupBy(predicate);
    }
}