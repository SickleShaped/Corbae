using Corbae.DAL.Models;
using Corbae.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Corbae.DAL.Models.DBModels;

namespace Corbae.DAL.Configure
{
    /// <summary>
    /// Класс, описывающий конфигурацию комментариев в БД
    /// </summary>
    public class ConfigureComment : IEntityTypeConfiguration<CommentDB>
    {   
        /// <summary>
        /// Конфигурация комментариев в базе данных
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CommentDB> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(p => p.CommentID);
            builder.HasIndex(p => p.CommentID).IsUnique();

            builder.Property(c => c.Text).HasMaxLength(1023);
            builder
                   .HasOne(p => p.User)
                   .WithMany(u => u.Comments)
                   .HasForeignKey(p => p.UserID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder
                  .HasOne(p => p.Product)
                  .WithMany(u => u.Comments)
                  .HasForeignKey(p => p.ProductID)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
