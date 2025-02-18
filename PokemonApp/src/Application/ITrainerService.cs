namespace PokemonApp.src;

public interface ITrainerService
{
    IEnumerable<Trainer> GetAllTrainers();
    Task<Trainer> AddTrainer(TrainerDto trainerDto);
}
