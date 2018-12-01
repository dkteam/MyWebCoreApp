using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebCoreApp.Data.EF.Extensions;
using MyWebCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebCoreApp.Data.EF.Configurations
{
    public class ContactConfiguration : DbEntityConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired().IsUnicode(false);
            // etc.
        }
    }
}
