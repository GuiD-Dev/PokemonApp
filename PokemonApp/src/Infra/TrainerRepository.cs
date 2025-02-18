namespace PokemonApp.src;

public class TrainerRepository : BaseRepository<Trainer>, ITrainerRepository
{
    public TrainerRepository(Context context) : base(context) { }

    public IEnumerable<Trainer> GetAll()
    {
        return _context.Trainers.ToList();
    }
}