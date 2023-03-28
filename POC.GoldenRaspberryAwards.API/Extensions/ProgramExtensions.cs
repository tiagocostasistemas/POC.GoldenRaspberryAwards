using Microsoft.EntityFrameworkCore;
using POC.GoldenRaspberryAwards.API.Application;
using POC.GoldenRaspberryAwards.API.Data.Contexts;
using POC.GoldenRaspberryAwards.API.Data.Repositories;

namespace POC.GoldenRaspberryAwards.API.Extensions;

public static class ProgramExtensions
{
    public static IServiceCollection AddAllServices(this IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddDbContext<DataContext>(options =>
            options.UseInMemoryDatabase("golden_raspberry_awards_db"),
            ServiceLifetime.Singleton
        );

        services.AddTransient<IAwardService, AwardService>();
        services.AddTransient<IMovieService, MovieService>();
        services.AddTransient<IMovieRepository, MovieRepository>(); ;

        return services;
    }

    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        return app;
    }
}
