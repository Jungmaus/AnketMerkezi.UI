using AnketMerkezi.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Data.ORM.Mapping
{
    public class SurveyMap : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.LinkCode).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(45).IsRequired();
        }
    }
}
