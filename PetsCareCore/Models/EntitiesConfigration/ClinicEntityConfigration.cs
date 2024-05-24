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
    public class ClinicEntityConfigration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Bio).HasMaxLength(1000);
            builder.Property(c => c.Image).HasMaxLength(500);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Phone).HasMaxLength(15);

            //************************Relations*****************************

            builder.HasMany<ClinicAppointment>()
                   .WithOne()
                   .HasForeignKey(l => l.ClinicId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
