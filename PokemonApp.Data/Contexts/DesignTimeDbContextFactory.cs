using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PokemonApp.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MysqlContext>
{
    public MysqlContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MysqlContext>();
        optionsBuilder.UseMySQL("Server=localhost;Database=pokedb;User=pokeuser;Password=pokepass;Port=3306;");

        return new MysqlContext(optionsBuilder.Options);
    }
}