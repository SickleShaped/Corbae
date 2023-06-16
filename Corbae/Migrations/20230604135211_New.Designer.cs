﻿// <auto-generated />
using System;
using Corbae.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Corbae.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230604135211_New")]
    partial class New
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.CartDB", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("UserID");

                    b.HasIndex("UserID");

                    b.ToTable("Carts", (string)null);
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.CommentDB", b =>
                {
                    b.Property<Guid>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .HasMaxLength(1023)
                        .HasColumnType("character varying(1023)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("CommentID");

                    b.HasIndex("CommentID")
                        .IsUnique();

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.Intermediate_Models.WishProduct", b =>
                {
                    b.Property<Guid>("WishProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("WishProductID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.HasIndex("WishProductID")
                        .IsUnique();

                    b.ToTable("WishProducts", (string)null);
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.NotificationDB", b =>
                {
                    b.Property<Guid>("NotificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("NotificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Text")
                        .HasMaxLength(1023)
                        .HasColumnType("character varying(1023)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("NotificationID");

                    b.HasIndex("NotificationID")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("Notifications", (string)null);
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.OrderDB", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeliveryPlace")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("OrderID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.ProductDB", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
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

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("ProductID");

                    b.HasIndex("ProductID")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.UserDB", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<string>("Company")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

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

                    b.HasKey("UserID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.WishDB", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("UserID");

                    b.HasIndex("UserID");

                    b.ToTable("Wishes", (string)null);
                });

            modelBuilder.Entity("Corbae.Models.CartProduct", b =>
                {
                    b.Property<Guid>("CartProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("CartProductID");

                    b.HasIndex("CartProductID")
                        .IsUnique();

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("CartProducts", (string)null);
                });

            modelBuilder.Entity("Corbae.Models.OrderProduct", b =>
                {
                    b.Property<Guid>("OrderProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserDBUserID")
                        .HasColumnType("uuid");

                    b.HasKey("OrderProductID");

                    b.HasIndex("OrderProductID")
                        .IsUnique();

                    b.HasIndex("ProductID");

                    b.HasIndex("UserDBUserID");

                    b.ToTable("OrderProducts", (string)null);
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.CartDB", b =>
                {
                    b.HasOne("Corbae.DAL.Models.DBModels.UserDB", "User")
                        .WithOne("Cart")
                        .HasForeignKey("Corbae.DAL.Models.DBModels.CartDB", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.CommentDB", b =>
                {
                    b.HasOne("Corbae.DAL.Models.DBModels.ProductDB", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Corbae.DAL.Models.DBModels.UserDB", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.Intermediate_Models.WishProduct", b =>
                {
                    b.HasOne("Corbae.DAL.Models.DBModels.ProductDB", "Product")
                        .WithMany("WishProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Corbae.DAL.Models.DBModels.WishDB", "Wish")
                        .WithMany("WishProducts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Wish");
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.NotificationDB", b =>
                {
                    b.HasOne("Corbae.DAL.Models.DBModels.UserDB", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.OrderDB", b =>
                {
                    b.HasOne("Corbae.DAL.Models.DBModels.UserDB", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.ProductDB", b =>
                {
                    b.HasOne("Corbae.DAL.Models.DBModels.UserDB", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.WishDB", b =>
                {
                    b.HasOne("Corbae.DAL.Models.DBModels.UserDB", "User")
                        .WithOne("Wish")
                        .HasForeignKey("Corbae.DAL.Models.DBModels.WishDB", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Corbae.Models.CartProduct", b =>
                {
                    b.HasOne("Corbae.DAL.Models.DBModels.ProductDB", "Product")
                        .WithMany("CartProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Corbae.DAL.Models.DBModels.CartDB", "Cart")
                        .WithMany("CartProducts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Corbae.Models.OrderProduct", b =>
                {
                    b.HasOne("Corbae.DAL.Models.DBModels.OrderDB", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Corbae.DAL.Models.DBModels.ProductDB", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Corbae.DAL.Models.DBModels.UserDB", null)
                        .WithMany("OrderProducts")
                        .HasForeignKey("UserDBUserID");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.CartDB", b =>
                {
                    b.Navigation("CartProducts");
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.OrderDB", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.ProductDB", b =>
                {
                    b.Navigation("CartProducts");

                    b.Navigation("Comments");

                    b.Navigation("OrderProducts");

                    b.Navigation("WishProducts");
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.UserDB", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("Comments");

                    b.Navigation("Notifications");

                    b.Navigation("OrderProducts");

                    b.Navigation("Orders");

                    b.Navigation("Products");

                    b.Navigation("Wish");
                });

            modelBuilder.Entity("Corbae.DAL.Models.DBModels.WishDB", b =>
                {
                    b.Navigation("WishProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
