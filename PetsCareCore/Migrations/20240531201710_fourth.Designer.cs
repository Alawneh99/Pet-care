﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetsCareCore.Context;

#nullable disable

namespace PetsCareCore.Migrations
{
    [DbContext(typeof(PetCareDbcontext))]
    [Migration("20240531201710_fourth")]
    partial class fourth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PetsCareCore.Models.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ServiceId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Clinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.ClinicAppointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClinicId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("PetId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("PetId");

                    b.ToTable("ClinicsAppointment");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<float>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<string>("DiscountType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("IsHaveDiscount")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("OrderId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsLoggedIn")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastLoginTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CartID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerNote")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<float>("Fee")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartID")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("OwnerUserId")
                        .HasColumnType("int");

                    b.Property<string>("PetType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<float>("Duration")
                        .HasColumnType("float");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserRoleID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.WishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ItemImage")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("WishLists");
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Cart", b =>
                {
                    b.HasOne("PetsCareCore.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.CartItem", b =>
                {
                    b.HasOne("PetsCareCore.Models.Entities.Cart", null)
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("PetsCareCore.Models.Entities.Service", null)
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Clinic", b =>
                {
                    b.HasOne("PetsCareCore.Models.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("PetsCareCore.Models.Entities.Clinic", "UserID")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.ClinicAppointment", b =>
                {
                    b.HasOne("PetsCareCore.Models.Entities.Clinic", null)
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("PetsCareCore.Models.Entities.Pet", null)
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Item", b =>
                {
                    b.HasOne("PetsCareCore.Models.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("PetsCareCore.Models.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Login", b =>
                {
                    b.HasOne("PetsCareCore.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Order", b =>
                {
                    b.HasOne("PetsCareCore.Models.Entities.Cart", null)
                        .WithOne()
                        .HasForeignKey("PetsCareCore.Models.Entities.Order", "CartID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("PetsCareCore.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.Pet", b =>
                {
                    b.HasOne("PetsCareCore.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("OwnerUserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("PetsCareCore.Models.Entities.User", b =>
                {
                    b.HasOne("PetsCareCore.Models.Entities.UserRole", null)
                        .WithMany()
                        .HasForeignKey("UserRoleID")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
