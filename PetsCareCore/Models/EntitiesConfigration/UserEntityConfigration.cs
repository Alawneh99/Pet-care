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
    public class UserEntityConfigration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Phone).HasMaxLength(15);
            builder.Property(u => u.BirthDate).IsRequired();
            builder.Property(u => u.ResetPasswordToken).HasMaxLength(200).IsRequired(false);
            builder.Property(u => u.ResetPasswordExpiry).IsRequired(false);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(200);

            //************************Relations*****************************

            builder.HasMany<Cart>()
                   .WithOne()
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany<Pet>()
                   .WithOne()
                   .HasForeignKey(p => p.OwnerUserId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany<Login>()
                   .WithOne()
                   .HasForeignKey(l => l.UserId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany<Order>()
                   .WithOne()
                   .HasForeignKey(k => k.UserId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
