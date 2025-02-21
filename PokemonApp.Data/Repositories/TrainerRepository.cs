using PokemonApp.Domain;

namespace PokemonApp.Data;

public class TrainerRepository : BaseRepository<Trainer>, ITrainerRepository
{
    public TrainerRepository(MysqlContext context) : base(context) { }

    public IEnumerable<Trainer> GetAll()
    {
        return _context.Trainers.ToList();
    }
}