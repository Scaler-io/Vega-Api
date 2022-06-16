using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega_API.Model.Response
{
    public class VegaMakeResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<VegaModelResponse> Models { get; set; }

        public VegaMakeResponse()
        {
            Models = new Collection<VegaModelResponse>();
        }

        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
