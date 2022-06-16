using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;
using Vega_API.Extension;
using Vega_API.Services.Makes;

namespace Vega_API.Controllers.v1
{
    [ApiVersion("1")]
    public class MakesController : BaseApiController
    {
        private readonly IMakeService _makeService;
        public MakesController(ILogger logger, IMakeService makeService)
            : base(logger)
        {
            _makeService = makeService;
        }

        [HttpGet]
        [Route("request/makes")]
        public async Task<IActionResult> GetMakes()
        {
            Logger.Here().MethodEnterd();

            var result = await _makeService.GetMakes();

            Logger.Here().MethodExited();
            return OkOrFail(result);
        }
    }
}
