﻿using Corbae.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Corbae.DAL.Models.DBModels;

namespace Corbae.Configure
{
    public class ConfigureOrder : IEntityTypeConfiguration<OrderDB>
    {
        public void Configure(EntityTypeBuilder<OrderDB> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.OrderID);
            builder.HasIndex(o => o.OrderID).IsUnique();
            

            builder
                   .HasOne(p => p.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(p => p.UserID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder
                   .HasMany(o => o.Products)
                   .WithMany(p => p.Orders)
                   .UsingEntity<OrderProduct>(
                op => op
                    .HasOne(op => op.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(op => op.ProductID)
                    .OnDelete(DeleteBehavior.Cascade),
                op => op
                    .HasOne(op => op.Order)
                    .WithMany(o => o.OrderProducts)
                    .HasForeignKey(op => op.ProductID)
                    .OnDelete(DeleteBehavior.Cascade),
                op =>
                {
                    op.HasKey(op => op.OrderProductID);
                    op.HasIndex(op => op.OrderProductID).IsUnique();
                    op.ToTable("OrderProducts");
                }) ;


        }
    }
}
