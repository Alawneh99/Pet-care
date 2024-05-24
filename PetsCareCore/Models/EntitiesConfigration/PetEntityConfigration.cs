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
    public class PetEntityConfigration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NickName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Gender).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Type).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Image).HasMaxLength(200);
            builder.Property(p => p.Age).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();

            //************************Relations*****************************

            builder.HasMany<ClinicAppointment>()
                   .WithOne()
                   .HasForeignKey(l => l.PetId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
