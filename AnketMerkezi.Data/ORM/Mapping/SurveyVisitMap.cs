using AnketMerkezi.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Data.ORM.Mapping
{
    public class SurveyVisitMap : IEntityTypeConfiguration<SurveyVisit>
    {
        public void Configure(EntityTypeBuilder<SurveyVisit> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.DeviceType).IsRequired();
            builder.Property(x => x.IpAdress).HasMaxLength(25).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
        }
    }
}
