using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCoreApp.Data.EF.Extensions;
using WebCoreApp.Data.Entities;

namespace WebCoreApp.Data.EF.Configurations
{
    public class BlogTagConfiguration : DbEntityConfiguration<BlogTag>
    {
        public override void Configure(EntityTypeBuilder<BlogTag> entity)
        {
            entity.Property(c => c.TagId).HasMaxLength(50).IsRequired()
            .HasMaxLength(50).IsUnicode(false);
            // etc.
        }
    }
}
