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
    public class UserRoleEntityConfigration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(u => u.RoleName).IsRequired().HasMaxLength(100);

            //************************Relations*****************************

            builder.HasMany<User>()
                   .WithOne()
                   .HasForeignKey(c => c.UserRoleID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
