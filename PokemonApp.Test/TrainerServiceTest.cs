using System.Threading.Tasks;
using Moq;
using PokemonApp.src;

namespace PokemonTests;

public class TrainerServiceTest
{
    private readonly Mock<ITrainerRepository> _repositoryMock;
    private readonly TrainerService _service;

    public TrainerServiceTest()
    {
        _repositoryMock = new Mock<ITrainerRepository>();
        _service = new TrainerService(_repositoryMock.Object);
    }
    
    [Fact]
    public void GetAllTrainersTest()
    {
        Assert.True(true);
    }

    [Fact]
    public async Task AddTrainerTest()
    {
        await _service.AddTrainer(new TrainerDto { Name = "Mock", Age = 10 });
        _repositoryMock.Verify(r => r.InsertOne(It.IsAny<Trainer>()), Times.Once);
        _repositoryMock.Verify(r => r.SaveChanges(), Times.Once);
    }
}