using Microsoft.AspNetCore.Http;
using Serilog;
using System.Threading.Tasks;
using Vega_API.Extension;

namespace Vega_API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                _logger.Here().Debug(
                    "Request {@method} {@url} => {@statusCode}",
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode
                 );
            }
        } 
    }
}
