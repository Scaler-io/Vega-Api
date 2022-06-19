using System.Collections.Generic;
using System.Threading.Tasks;
using Vega_API.Model.Core;
using Vega_API.Model.Response;

namespace Vega_API.Services.Features
{
    public interface IFeatureService
    {
        Task<Result<IReadOnlyList<VegaFeatureResponse>>> GetFeatures(); 
    }
}