using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega_API.Entities
{
    public class VegaVehicle: BaseEntity
    {
        public int ModelId { get; set; }
        public VegaModel Model { get; set; }
        public bool IsRegistered { get; set; }
        public Contact Contact { get; set; }
        public ICollection<VehicleFeature> Features { get; set; }

        public VegaVehicle()
        {
            Features = new Collection<VehicleFeature>();
        }
    }
}