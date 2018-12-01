using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebCoreApp.Data.EF.Extensions;
using MyWebCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebCoreApp.Data.EF.Configurations
{
    public class AdvertisementPositionConfiguration : DbEntityConfiguration<AdvertisementPosition>
    {
        public override void Configure(EntityTypeBuilder<AdvertisementPosition> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
            //entity.Property(a => a.PageId).HasMaxLength(50).IsRequired();
            //etc.
        }
    }
}
