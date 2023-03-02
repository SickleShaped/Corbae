using Corbae.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Corbae.Configure
{
    public class ConfigureUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.UserID);
            builder.HasIndex(u => u.UserID).IsUnique();

            builder.Property(u => u.IsAdmin).HasDefaultValue(false);
            builder.Property(u => u.IsSeller).HasDefaultValue(false);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(128);
            builder.Property(u=>u.Name).IsRequired().HasMaxLength(128);
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.CreationDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(u => u.Company).HasMaxLength(128);
            dd
            builder
                   .HasOne(u => u.Cart)
                   .WithOne(c => c.User)
                   .HasForeignKey<Cart>(c => c.CartID)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
