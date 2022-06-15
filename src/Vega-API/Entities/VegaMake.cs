using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega_API.Entities
{
    public class VegaMake: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<VegaModel> Models { get; set; }

        public VegaMake()
        {
            Models = new Collection<VegaModel>();
        }
    }
}
