using Corbae.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Corbae.Configure
{
    public class ConfigureOrder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder
                   .HasOne(p => p.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(p => p.UserID);

            builder
                   .HasMany(o => o.Products)
                   .WithMany(p => p.Orders)
                   .UsingEntity<OrderProduct>(
                op => op
                    .HasOne(op => op.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(op => op.ProductID),
                op => op
                    .HasOne(op => op.Order)
                    .WithMany(o => o.OrderProducts)
                    .HasForeignKey(op => op.ProductID),
                op =>
                {
                    op.HasKey("OrderProductId");
                    op.ToTable("OrderProducts");
                }) ;
        }
    }
}
