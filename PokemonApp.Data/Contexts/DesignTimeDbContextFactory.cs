using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PokemonApp.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MysqlContext>
{
    private readonly IConfiguration _configuration;

    public DesignTimeDbContextFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public MysqlContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MysqlContext>();
        optionsBuilder.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));

        return new MysqlContext(optionsBuilder.Options, _configuration);
    }
}