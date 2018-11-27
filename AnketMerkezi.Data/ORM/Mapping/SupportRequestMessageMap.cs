using AnketMerkezi.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Data.ORM.Mapping
{
    public class SupportRequestMessageMap : IEntityTypeConfiguration<SupportRequestMessage>
    {
        public void Configure(EntityTypeBuilder<SupportRequestMessage> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Content).HasMaxLength(700).IsRequired();
        }
    }
}
