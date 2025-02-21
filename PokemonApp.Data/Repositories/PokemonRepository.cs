using Microsoft.EntityFrameworkCore;
using PokemonApp.Domain;

namespace PokemonApp.Data;

public class PokemonRepository : BaseRepository<Pokemon>, IPokemonRepository
{
    public PokemonRepository(MysqlContext context) : base(context) { }

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