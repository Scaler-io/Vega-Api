using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Vega_API.Extension;
using Vega_API.Services.Features;

namespace Vega_API.Controllers.v1
{
    [ApiVersion("1")]
    public class FeatureController : BaseApiController
    {
        private readonly IFeatureService _featureService;
        public FeatureController(ILogger logger, IFeatureService featureService)
            : base(logger)
        {
            _featureService = featureService;
        }

        [HttpGet]
        [Route("request/features")]
        public async Task<IActionResult> GetFeatures(){
            Logger.Here().MethodEnterd();

            var result = await _featureService.GetFeatures();

            Logger.Here().MethodExited();
            return OkOrFail(result);
        }
    }
}