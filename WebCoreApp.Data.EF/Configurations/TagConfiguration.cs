using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCoreApp.Data.EF.Extensions;
using WebCoreApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebCoreApp.Data.EF.Configurations
{
    public class TagConfiguration : DbEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(50)
                 .IsRequired().HasMaxLength(50).IsUnicode(false);
        }
    }
}
