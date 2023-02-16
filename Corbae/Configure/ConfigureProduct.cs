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
            builder
                   .HasOne(p => p.User)
                   .WithMany(u => u.Products)
                   .HasForeignKey(p=>p.UserID);
        }
    }
}