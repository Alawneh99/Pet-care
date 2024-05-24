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
    public class ServiceEntityConfigration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Description)
                   .HasMaxLength(1000)
                   .IsRequired(false);

            builder.Property(s => s.Price)
                   .IsRequired();

            builder.Property(s => s.Duration)
                   .IsRequired();

            //************************Relations*****************************

            builder.HasMany<CartItem>()
                   .WithOne()
                   .HasForeignKey(l => l.ServiceId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
