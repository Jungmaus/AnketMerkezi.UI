using AnketMerkezi.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Data.ORM.Mapping
{
    public class UserDetailMap : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(15);
            builder.Property(x => x.Surname).HasMaxLength(20).IsRequired();
        }
    }
}
