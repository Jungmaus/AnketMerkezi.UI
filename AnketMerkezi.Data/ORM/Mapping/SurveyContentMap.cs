using AnketMerkezi.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Data.ORM.Mapping
{
    public class SurveyContentMap : IEntityTypeConfiguration<SurveyContent>
    {
        public void Configure(EntityTypeBuilder<SurveyContent> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.DataType).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(45).IsRequired();
        }
    }
}
