﻿// <auto-generated />
using System;
using Corbae;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Corbae.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Corbae.Models.Cart", b =>
                {
                    b.Property<string>("CartID")
                        .HasColumnType("text");

                    b.HasKey("CartID");

                    b.HasIndex("CartID")
                        .IsUnique();

                    b.ToTable("Carts", (string)null);
                });

            modelBuilder.Entity("Corbae.Models.CartProduct", b =>
                {
                    b.Property<string>("CartProductID")
                        .HasColumnType("text");

                    b.Property<string>("CartID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CartProductID");

                    b.HasIndex("CartID");

                    b.HasIndex("CartProductID")
                        .IsUnique();

                    b.HasIndex("ProductID");

                    b.ToTable("CartProducts", (string)null);
                });

            modelBuilder.Entity("Corbae.Models.Order", b =>
                {
                    b.Property<string>("OrderID")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2023, 2, 19, 19, 29, 23, 455, DateTimeKind.Utc).AddTicks(10));

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeliveryPlace")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OrderID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Corbae.Models.OrderProduct", b =>
                {
                    b.Property<string>("OrderProductID")
                        .HasColumnType("text");

                    b.Property<string>("OrderID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.HasKey("OrderProductID");

                    b.HasIndex("OrderProductID")
                        .IsUnique();

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("OrderProducts", (string)null);
                });

            modelBuilder.Entity("Corbae.Models.Product", b =>
                {
                    b.Property<string>("ProductID")
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2047)
                        .HasColumnType("character varying(2047)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<long>("QuantityInStock")
                        .HasColumnType("bigint");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductID");

                    b.HasIndex("ProductID")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Corbae.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<string>("Company")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2023, 2, 19, 19, 29, 23, 453, DateTimeKind.Utc).AddTicks(6514));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsCustomer")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSeller")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<decimal>("Money")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("UserID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Corbae.Models.Cart", b =>
                {
                    b.HasOne("Corbae.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("Corbae.Models.Cart", "CartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Corbae.Models.CartProduct", b =>
                {
                    b.HasOne("Corbae.Models.Cart", "Cart")
                        .WithMany("CartProducts")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Corbae.Models.Product", "Product")
                        .WithMany("CartProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Corbae.Models.Order", b =>
                {
                    b.HasOne("Corbae.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Corbae.Models.OrderProduct", b =>
                {
                    b.HasOne("Corbae.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Corbae.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Corbae.Models.User", null)
                        .WithMany("OrderProducts")
                        .HasForeignKey("UserID");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Corbae.Models.Product", b =>
                {
                    b.HasOne("Corbae.Models.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Corbae.Models.Cart", b =>
                {
                    b.Navigation("CartProducts");
                });

            modelBuilder.Entity("Corbae.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Corbae.Models.Product", b =>
                {
                    b.Navigation("CartProducts");

                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Corbae.Models.User", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("OrderProducts");

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
