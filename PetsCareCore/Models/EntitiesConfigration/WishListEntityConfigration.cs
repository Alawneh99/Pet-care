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
    public class WishListEntityConfigration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.ItemName).IsRequired().HasMaxLength(200);
            builder.Property(w => w.ItemImage).HasMaxLength(200);
        }
    }
}
