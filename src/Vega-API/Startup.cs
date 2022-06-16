using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vega_API.VegaInjections;

namespace Vega_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBusinessLayerServices();
            services.AddApplicationServices(Configuration);
            services.AddDatabaseServices(Configuration);
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.AddApplicationConfigPipeline(env);
        }
    }
}
