using AnketMerkezi.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Data.ORM.Mapping
{
    public class SupportRequestMap : IEntityTypeConfiguration<SupportRequest>
    {
        public void Configure(EntityTypeBuilder<SupportRequest> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.SubjectType).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
        }
    }
}
