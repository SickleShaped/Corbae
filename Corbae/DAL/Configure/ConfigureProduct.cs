using Corbae.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace Corbae.Configure
{
    public class ConfigureProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.ProductID);
            builder.HasIndex(p => p.ProductID).IsUnique();

            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(2047).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.QuantityInStock).IsRequired();

            builder
                   .HasOne(p => p.User)
                   .WithMany(u => u.Products)
                   .HasForeignKey(p=>p.UserID)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}