using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Data.EF.Extensions;
using WebCoreApp.Data.Entities;

namespace WebCoreApp.Data.EF.Configurations
{
    public class ProductTagConfiguration : DbEntityConfiguration<ProductTag>
    {
        public override void Configure(EntityTypeBuilder<ProductTag> entity)
        {
            entity.Property(c => c.TagId).HasMaxLength(255).IsRequired()
           .HasMaxLength(50).IsUnicode(false);
            // etc.
        }
    }
}
