using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebCoreApp.Data.EF.Extensions;
using MyWebCoreApp.Data.Entities;

namespace MyWebCoreApp.Data.EF.Configurations
{
    public class AdvertisementPageConfiguration : DbEntityConfiguration<AdvertisementPage>
    {
        public override void Configure(EntityTypeBuilder<AdvertisementPage> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(50).IsRequired().HasColumnType("varchar(50)");
        }
    }
}