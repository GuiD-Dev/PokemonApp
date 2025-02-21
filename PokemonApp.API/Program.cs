using PokemonApp.Aplication;
using PokemonApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MysqlContext>();
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/pokemons/grouped", (IPokemonService service) =>
{
    var result = service.GetPokemonsGroupedByColor();
    return Results.Ok(result);
});

app.Run();