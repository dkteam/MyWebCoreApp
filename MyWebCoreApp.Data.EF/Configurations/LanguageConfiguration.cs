using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebCoreApp.Data.EF.Extensions;
using MyWebCoreApp.Data.Entities;

namespace MyWebCoreApp.Data.EF.Configurations
{
    public class LanguageConfiguration : DbEntityConfiguration<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(100)
              .IsRequired()
              .HasColumnType("varchar(50)")
              .IsUnicode(false);
        }
    }
}