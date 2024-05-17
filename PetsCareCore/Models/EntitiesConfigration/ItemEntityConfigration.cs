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
    public class ItemEntityConfigration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name).IsRequired().HasMaxLength(200);
            builder.Property(i => i.Description).HasMaxLength(1000);
            builder.Property(i => i.Image).HasMaxLength(200);
            builder.Property(i => i.Price).IsRequired();
            builder.Property(i => i.Price).HasColumnType("float");
            builder.Property(i => i.Quantity).IsRequired();
            builder.Property(i => i.IsHaveDiscount).IsRequired();
            builder.Property(i => i.DiscountAmount).HasColumnType("float");
            builder.Property(i => i.DiscountType).HasMaxLength(50);
        }
    }
}
