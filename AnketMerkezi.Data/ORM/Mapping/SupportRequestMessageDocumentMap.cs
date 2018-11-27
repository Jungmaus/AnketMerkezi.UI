using AnketMerkezi.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Data.ORM.Mapping
{
    public class SupportRequestMessageDocumentMap : IEntityTypeConfiguration<SupportRequestMessageDocument>
    {
        public void Configure(EntityTypeBuilder<SupportRequestMessageDocument> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FilePath).IsRequired();
        }
    }
}
