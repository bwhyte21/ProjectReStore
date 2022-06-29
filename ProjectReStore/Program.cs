using System;
using System.Threading.Tasks;
using API.Data.Context;
using API.Data.Initializer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Create and seed DB if none exists.
        var host = CreateHostBuilder(args).Build();
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        try
        {
            // Get data context as a service.
            var storeContext = services.GetRequiredService<StoreContext>();

            // Apply pending migrations, if any.
            await storeContext.Database.MigrateAsync();

            // Seed database after migration.
            await DbInitializer.DataSeeder(storeContext);
        }
        catch (Exception ex)
        {
            // Log any exceptions.
            logger.LogError(ex, "An error has occurred during migration.");
        }

        // Run application.
        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}