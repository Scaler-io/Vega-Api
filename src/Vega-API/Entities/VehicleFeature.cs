using System;

namespace Vega_API.Entities
{
    public class VehicleFeature
    {
        public Guid VehicleId { get; set; }
        public Guid FeatureId { get; set; }
        public VegaVehicle Vehicle { get; set; }
        public VegaFeature Feature { get; set; }
    }
}