using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Vega_API.DataAccess;

namespace Vega_API
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
           
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                
                var context = services.GetRequiredService<VegaDbContext>();
                await context.Database.MigrateAsync();
                
                var logger = services.GetRequiredService<ILogger<DatabaseSeed>>();
                await DatabaseSeed.SeedAsync(context, logger);
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
