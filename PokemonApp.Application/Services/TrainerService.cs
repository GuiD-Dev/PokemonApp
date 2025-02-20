using PokemonApp.Data;
using PokemonApp.Domain;

namespace PokemonApp.Aplication;

public class TrainerService : ITrainerService
{
    private readonly ITrainerRepository _trainerRepository;
    public TrainerService(ITrainerRepository trainerRepository) => _trainerRepository = trainerRepository;

    public IEnumerable<Trainer> GetAllTrainers()
    {
        return _trainerRepository.GetAll();
    }

    public async Task<Trainer> AddTrainer(TrainerDto trainerDto)
    {
        var trainer = new Trainer
        {
            Name = trainerDto.Name,
            Age = trainerDto.Age,
        };
        _trainerRepository.InsertOne(trainer);
        await _trainerRepository.SaveChanges();
        return trainer;
    }
}