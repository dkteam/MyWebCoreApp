using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebCoreApp.Data.EF.Extensions;
using MyWebCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebCoreApp.Data.EF.Configurations
{
    public class PostTagConfiguration: DbEntityConfiguration<PostTag>
    {
        public override void Configure(EntityTypeBuilder<PostTag> entity)
        {
            entity.Property(c => c.TagId).HasMaxLength(100).IsRequired()
            .HasMaxLength(100).IsUnicode(false);
            // etc.
        }
    }
}
