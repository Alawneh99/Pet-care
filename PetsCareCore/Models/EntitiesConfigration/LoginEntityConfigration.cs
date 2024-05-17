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
    public class LoginEntityConfigration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.UserName).IsRequired().HasMaxLength(100);
            builder.Property(l => l.Password).IsRequired().HasMaxLength(200);
            builder.Property(l => l.LastLoginTime).IsRequired();
            builder.Property(l => l.IsLoggedIn).IsRequired();
        }
    }
}
