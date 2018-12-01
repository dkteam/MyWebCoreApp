using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebCoreApp.Data.EF.Extensions;
using MyWebCoreApp.Data.Entities;

namespace MyWebCoreApp.Data.EF.Configurations
{
    public class SystemConfigConfiguration : DbEntityConfiguration<SystemConfig>
    {
        public override void Configure(EntityTypeBuilder<SystemConfig> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired().IsUnicode(false);
            // etc.
        }
    }
}