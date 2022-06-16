using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vega_API.DataAccess;
using Vega_API.DataAccess.Interfaces;

namespace Vega_API.VegaInjections
{
    public static class ApplicationDbServices
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<VegaDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("SqlServerConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
