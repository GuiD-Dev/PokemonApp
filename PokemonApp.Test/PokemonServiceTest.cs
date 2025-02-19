using Moq;
using PokemonApp.src;

namespace PokemonTests;

public class PokemonServiceTest
{
    private readonly Mock<IPokemonRepository> _repositoryMock;
    private readonly PokemonService _service;

    public PokemonServiceTest()
    {
        _repositoryMock = new Mock<IPokemonRepository>();
        _service = new PokemonService(_repositoryMock.Object);
    }

    [Fact]
    public void GetPokemonsByColor_ShouldReturnPokemons()
    {
        // Arrange
        var expectedPokemons = new List<Pokemon> { new Pokemon { Color = Color.Red } };
        _repositoryMock.Setup(r => r.GetPokemonsByColor(Color.Red))
            .Returns(expectedPokemons);

        // Act
        var result = _service.GetPokemonsByColor(Color.Red);

        // Assert
        Assert.Equal(expectedPokemons, result);
        _repositoryMock.Verify(r => r.GetPokemonsByColor(Color.Red), Times.Once);
    }

    [Fact]
    public void GetPokemonsGroupedByColor_ShouldReturnGroupedPokemons()
    {
        // Arrange
        var pokemons = new List<Pokemon> { 
            new Pokemon { Color = Color.Red },
            new Pokemon { Color = Color.Blue }
        };
        var groupedPokemons = pokemons.GroupBy(p => p.Color);
        _repositoryMock.Setup(r => r.GetPokemonsGroupedBy(It.IsAny<Func<Pokemon, Color>>()))
            .Returns(groupedPokemons);

        // Act
        var result = _service.GetPokemonsGroupedByColor();

        // Assert
        Assert.Equal(groupedPokemons, result);
        _repositoryMock.Verify(r => r.GetPokemonsGroupedBy(It.IsAny<Func<Pokemon, Color>>()), Times.Once);
    }
}
