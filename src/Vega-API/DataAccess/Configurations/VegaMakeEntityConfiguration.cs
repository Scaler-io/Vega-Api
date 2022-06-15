using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vega_API.Entities;
using Vega_API.Model.Constants;

namespace Vega_API.DataAccess.Configurations
{
    public class VegaMakeEntityConfiguration : IEntityTypeConfiguration<VegaMake>
    {
        public void Configure(EntityTypeBuilder<VegaMake> builder)
        {
            builder.ToTable(SqlDbTableNames.VegaMakeTable);
            builder.Property(make => make.Name).IsRequired().HasMaxLength(255);
        }
    }
}
