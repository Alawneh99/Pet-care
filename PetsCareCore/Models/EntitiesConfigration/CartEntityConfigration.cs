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
    public class CartEntityConfigration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IsActive).IsRequired();

            //************************Relations*****************************

            builder.HasMany<CartItem>()
                   .WithOne()
                   .HasForeignKey(l => l.CartId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
