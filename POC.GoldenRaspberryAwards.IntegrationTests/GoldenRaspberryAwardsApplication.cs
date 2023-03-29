using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POC.GoldenRaspberryAwards.API.Data.Contexts;


namespace POC.GoldenRaspberryAwards.IntegrationTests;

public class GoldenRaspberryAwardsApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var root = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.AddDbContext<DataContext>(options =>
                options.UseInMemoryDatabase("golden_raspberry_awards_db", root)
            );
        });

        return base.CreateHost(builder);
    }
}
