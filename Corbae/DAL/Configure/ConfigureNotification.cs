using Corbae.DAL.Models.DBModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Corbae.DAL.Configure
{
    /// <summary>
    /// Класс, описывающий конфигурацию комментариев в БД
    /// </summary>
    public class ConfigureNotification : IEntityTypeConfiguration<NotificationDB>
    {
        /// <summary>
        /// Конфигурация Уведомлений в базе данных
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<NotificationDB> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(p => p.NotificationID);
            builder.HasIndex(p => p.NotificationID).IsUnique();

            builder.Property(c => c.Text).HasMaxLength(1023);
            builder
                   .HasOne(p => p.User)
                   .WithMany(u => u.Notifications)
                   .HasForeignKey(p => p.UserID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
