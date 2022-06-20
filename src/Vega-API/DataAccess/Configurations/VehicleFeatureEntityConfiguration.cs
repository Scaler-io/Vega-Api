using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vega_API.Entities;
using Vega_API.Model.Constants;

namespace Vega_API.DataAccess.Configurations
{
    public class VehicleFeatureEntityConfiguration : IEntityTypeConfiguration<VehicleFeature>
    {
        public void Configure(EntityTypeBuilder<VehicleFeature> builder)
        {
            builder.ToTable(SqlDbTableNames.VegaVehicleFeatureTable);
            builder.HasKey(vf => new {vf.VehicleId, vf.FeatureId});
        }
    }
}