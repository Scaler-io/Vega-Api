using Microsoft.Extensions.DependencyInjection;
using Vega_API.Services.Makes;

namespace Vega_API.VegaInjections
{
    public static class ApplicationBusinessLayerInjection
    {
        public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IMakeService, MakeService>();
            return services;
        }
    }
}
