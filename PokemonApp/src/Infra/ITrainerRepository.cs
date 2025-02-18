namespace PokemonApp.src;

public interface ITrainerRepository : IBaseRepository<Trainer>
{
    IEnumerable<Trainer> GetAll();
}