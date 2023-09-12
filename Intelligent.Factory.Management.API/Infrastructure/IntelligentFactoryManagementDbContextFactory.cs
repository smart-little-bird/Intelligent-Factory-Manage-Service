using Intelligent.Factory.Management.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Intelligent.Factory.Management.API.Infrastructure;

public class ProductDbContextFactory : IDesignTimeDbContextFactory<IntelligentFactoryManagementContext>
{
    public IntelligentFactoryManagementContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<IntelligentFactoryManagementContext>();

        optionsBuilder.UseSqlServer(config.GetConnectionString("db"),
            sqlServerOptionsAction: builder => builder.MigrationsAssembly(typeof(Program).Assembly.FullName));

        return new IntelligentFactoryManagementContext(optionsBuilder.Options);
    }
}