using Microsoft.EntityFrameworkCore;
using PetsCareCore.Models.Entities;
using PetsCareCore.Models.EntitiesConfigration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Context
{
    public class PetCareDbcontext : DbContext
    {
        public PetCareDbcontext(DbContextOptions<PetCareDbcontext> dbOptions) : base(dbOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ItemEntityConfigration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfigration());
            modelBuilder.ApplyConfiguration(new UserEntityConfigration());
            modelBuilder.ApplyConfiguration(new LoginEntityConfigration());
            modelBuilder.ApplyConfiguration(new WishListEntityConfigration());
            modelBuilder.ApplyConfiguration(new PetEntityConfigration());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }

    }
}
