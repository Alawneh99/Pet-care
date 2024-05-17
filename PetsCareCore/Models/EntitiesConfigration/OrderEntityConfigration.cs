using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsCareCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Models.EntitiesConfigration
{
    public class OrderEntityConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Title).IsRequired().HasMaxLength(200);
            builder.Property(o => o.TotalPrice).IsRequired();
            builder.Property(o => o.TotalPrice).HasColumnType("float");
            builder.Property(o => o.Date).IsRequired();
            builder.Property(o => o.Fee).HasColumnType("float");
            builder.Property(o => o.CustomerNote).HasMaxLength(1000);
        }
    }
}
