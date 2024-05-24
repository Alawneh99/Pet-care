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
    public class CategoryEntityConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            //************************Relations*****************************

            builder.HasMany<Item>()
                   .WithOne()
                   .HasForeignKey(l => l.CategoryID)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
