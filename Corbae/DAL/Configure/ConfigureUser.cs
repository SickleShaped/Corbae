using Corbae.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Corbae.DAL.Models.DBModels;

namespace Corbae.Configure
{
    /// <summary>
    /// Класс, описывающий конфигурацию пользователя в БД
    /// </summary>
    public class ConfigureUser : IEntityTypeConfiguration<UserDB>
    {
        /// <summary>
        /// Конфигурация пользователя в БД
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserDB> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.UserID);
            builder.HasIndex(u => u.UserID).IsUnique();

            builder.Property(u => u.IsAdmin).HasDefaultValue(false);
            builder.Property(u => u.IsSeller).HasDefaultValue(false);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(128);
            builder.Property(u=>u.Name).IsRequired().HasMaxLength(128);
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Company).HasMaxLength(128);
            builder
                   .HasOne(u => u.Cart)
                   .WithOne(c => c.User)
                   .HasForeignKey<CartDB>(c => c.UserID)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
