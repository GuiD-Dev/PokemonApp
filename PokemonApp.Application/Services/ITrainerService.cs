using PokemonApp.Data;
using PokemonApp.Domain;

namespace PokemonApp.Aplication;

public interface ITrainerService
{
    IEnumerable<Trainer> GetAllTrainers();
    Task<Trainer> AddTrainer(TrainerDto trainerDto);
}
