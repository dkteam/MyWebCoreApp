using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebCoreApp.Data.EF.Extensions;
using MyWebCoreApp.Data.Entities;

namespace MyWebCoreApp.Data.EF.Configurations
{
    public class FunctionConfiguration : DbEntityConfiguration<Function>
    {
        public override void Configure(EntityTypeBuilder<Function> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false);
            // etc.
        }
    }
}