using Corbae.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corbae.Configure
{
    public class ConfigureCart : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(c => c.CartID);
            builder.HasIndex(c => c.CartID).IsUnique();

            builder
                   .HasMany(s => s.Products)
                   .WithMany(s => s.Carts)
                   .UsingEntity<CartProduct>(
                cp => cp
                    .HasOne(cp => cp.Product)
                    .WithMany(p => p.CartProducts)
                    .HasForeignKey(cp => cp.ProductID)
                    .OnDelete(DeleteBehavior.SetNull),
                cp => cp
                    .HasOne(cp => cp.Cart)
                    .WithMany(c => c.CartProducts)
                    .HasForeignKey(cp => cp.CartID)
                    .OnDelete(DeleteBehavior.SetNull), 
                cp =>
                {
                    cp.HasKey(cp=>cp.CartProductID);
                    cp.HasIndex(cp => cp.CartProductID).IsUnique();
                    cp.ToTable("CartProducts");
                    
                });

        }
    }
}
