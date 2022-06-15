using System;

namespace Vega_API.Entities
{
    public class VegaModel: BaseEntity
    {
        public string Name { get; set; }
        public VegaMake Make { get; set; }
        public Guid MakeId { get; set; }
    }
}
