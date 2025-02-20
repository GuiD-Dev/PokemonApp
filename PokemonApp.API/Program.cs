using PokemonApp.Aplication;
using PokemonApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<Context>();

    if (!dbContext.Database.CanConnect()) throw new Exception("Can't connect to the database");

    dbContext.Database.EnsureCreated();
}

app.MapGet("/pokemons/grouped", (IPokemonService service) =>
{
    var result = service.GetPokemonsGroupedByColor();
    return Results.Ok(result);
});

app.Run();