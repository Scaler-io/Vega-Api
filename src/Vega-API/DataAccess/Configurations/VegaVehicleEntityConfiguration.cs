using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vega_API.Entities;
using Vega_API.Model.Constants;

namespace Vega_API.DataAccess.Configurations
{
    public class VegaVehicleEntityConfiguration : IEntityTypeConfiguration<VegaVehicle>
    {
        public void Configure(EntityTypeBuilder<VegaVehicle> builder)
        {
            builder.ToTable(SqlDbTableNames.VegaVehicleTable);
            builder.OwnsOne(o => o.Contact, c => {
                c.WithOwner();
            });
        }
    }
}