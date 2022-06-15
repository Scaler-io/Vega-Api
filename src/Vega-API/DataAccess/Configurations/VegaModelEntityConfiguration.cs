using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vega_API.Entities;
using Vega_API.Model.Constants;

namespace Vega_API.DataAccess.Configurations
{
    public class VegaModelEntityConfiguration : IEntityTypeConfiguration<VegaModel>
    {
        public void Configure(EntityTypeBuilder<VegaModel> builder)
        {
            builder.ToTable(SqlDbTableNames.VegaModelTable);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(255);
        }
    }
}
