using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DBModels.Intermediate_Models;
using Corbae.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corbae.DAL.Configure
{
    public class ConfigureWish:IEntityTypeConfiguration<WishDB>
    {
        /// <summary>
        /// Конфигурация Корзины в БД
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<WishDB> builder)
        {
            builder.ToTable("Wishes");

            builder.HasKey(c => c.UserID);
            builder.HasIndex(c => c.UserID);

            builder
                   .HasMany(s => s.Products)
                   .WithMany(s => s.Wishes)
                   .UsingEntity<WishProduct>(
                cp => cp
                    .HasOne(cp => cp.Product)
                    .WithMany(p => p.WishProducts)
                    .HasForeignKey(cp => cp.ProductID)
                    .OnDelete(DeleteBehavior.Cascade),
                cp => cp
                    .HasOne(cp => cp.Wish)
                    .WithMany(c => c.WishProducts)
                    .HasForeignKey(cp => cp.UserID)
                    .OnDelete(DeleteBehavior.Cascade),
                cp =>
                {
                    cp.HasKey(cp => cp.WishProductID);
                    cp.HasIndex(cp => cp.WishProductID).IsUnique();
                    cp.ToTable("WishProducts");

                });

        }
    }
}
