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
    public class ClinicAppointmentEntityConfigration : IEntityTypeConfiguration<ClinicAppointment>
    {
        public void Configure(EntityTypeBuilder<ClinicAppointment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Date).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.IsPaid).IsRequired();
            builder.Property(c => c.IsConfirmed).IsRequired();
        }
    }
}
