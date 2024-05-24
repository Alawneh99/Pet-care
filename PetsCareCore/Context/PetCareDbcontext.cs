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
            modelBuilder.ApplyConfiguration(new CartEntityConfigration());
            modelBuilder.ApplyConfiguration(new CartItemEntityConfigration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfigration());
            modelBuilder.ApplyConfiguration(new ClinicEntityConfigration());
            modelBuilder.ApplyConfiguration(new ClinicAppointmentEntityConfigration());
            modelBuilder.ApplyConfiguration(new ServiceEntityConfigration());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<ClinicAppointment> ClinicsAppointment { get; set;}
        public virtual DbSet<Service> Services { get; set; }
    }
}
