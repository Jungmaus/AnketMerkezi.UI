using AnketMerkezi.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Data.ORM.Mapping
{
    public class UserOrderMap : IEntityTypeConfiguration<UserOrder>
    {
        public void Configure(EntityTypeBuilder<UserOrder> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.AccountType).IsRequired();
            builder.Property(x => x.DayCount).IsRequired();
        }
    }
}
