using System.Collections.Generic;
using System.Threading.Tasks;
using Vega_API.Model.Core;
using Vega_API.Model.Response;

namespace Vega_API.Services.Makes
{
    public interface IMakeService
    {
        Task<Result<IReadOnlyList<VegaMakeResponse>>> GetMakes();
    }
}
