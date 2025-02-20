using PokemonApp.Domain;

namespace PokemonApp.Data;

public interface ITrainerRepository : IBaseRepository<Trainer>
{
    IEnumerable<Trainer> GetAll();
}