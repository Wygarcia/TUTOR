using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TUTOR.Context;
using System.IO;

public class TutorDbContextFactory : IDesignTimeDbContextFactory<TutorDbContext>
{
    public TutorDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TutorDbContext>();

        // Configura la cadena de conexión manualmente para las migraciones
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Connection");
        optionsBuilder.UseSqlServer(connectionString);

        return new TutorDbContext(optionsBuilder.Options);
    }
}
