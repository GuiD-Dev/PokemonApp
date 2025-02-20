using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokemonApp.Aplication;
using PokemonApp.Data;
using PokemonApp.Domain;

namespace PokemonApp.API;

[Route("[controller]")]
public class MainController : Controller
{
    private readonly ILogger<MainController> _logger;
    private readonly IPokemonService _pokemonService;
    private readonly ITrainerService _trainerService;

    public MainController(ILogger<MainController> logger, IPokemonService pokemonService, ITrainerService trainerService)
    {
        _logger = logger;
        _pokemonService = pokemonService;
        _trainerService = trainerService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }

    [HttpGet("listRedPokemons")]
    public IActionResult ListByColor()
    {
        var redPokemons = _pokemonService.GetPokemonsByColor(Color.Red);
        return Ok(redPokemons);
    }

    [HttpGet("listTrainers")]
    public IActionResult ListAllTrainers()
    {
        var trainers = _trainerService.GetAllTrainers();
        return Ok(trainers);
    }

    [HttpPost("insertTrainer")]
    public IActionResult InsertTrainer([FromBody] TrainerDto trainerDto)
    {
        var trainer = _trainerService.AddTrainer(trainerDto).Result;
        return Ok(trainer);
    }

    [HttpGet("listFromAPI")]
    public IActionResult ListFromAPI()
    {
        var teste = _pokemonService.GetPokemonsFromAPI().Result;
        return Ok(JsonConvert.SerializeObject(teste));
    }
}