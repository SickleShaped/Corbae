using Corbae.Configure;
using Corbae.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DBModels.Intermediate_Models;

namespace Corbae.DAL
{
    /// <summary>
    /// Класс, описывающий сущности БД
    /// </summary>
    public class ApiDbContext : DbContext
    {
        public ApiDbContext() => Database.EnsureCreated();

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        /// <summary>
        /// DbSet Пользователей в БД
        /// </summary>
        public DbSet<UserDB> Users { get; set; } = null!;

        /// <summary>
        /// DbSet Корзин в БД
        /// </summary>
        public DbSet<CartDB> Carts { get; set; } = null!;

        /// <summary>
        /// DbSet Желаемого в БД
        /// </summary>
        public DbSet<WishDB> Wishes { get; set; } = null!;

        /// <summary>
        /// DbSet Заказов в БД
        /// </summary>
        public DbSet<OrderDB> Orders { get; set; } = null!;

        /// <summary>
        /// DbSet Товаров в БД
        /// </summary>
        public DbSet<ProductDB> Products { get; set; } = null!;

        /// <summary>
        /// DbSet вспомогательной таблицы для связи МкМ между Товарами и Заказами
        /// </summary>
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;

        /// <summary>
        /// DbSet вспомогательной таблицы для связи МкМ между Товарами и Корзинами
        /// </summary>
        public DbSet<CartProduct> CartProducts { get; set; } = null!;

        /// <summary>
        /// DbSet вспомогательной таблицы для связи МкМ между Товарами и Желаемым
        /// </summary>
        public DbSet<WishProduct> WishProducts { get; set; } = null!;

        /// <summary>
        /// DbSet комментариев в БД
        /// </summary>
        public DbSet<CommentDB> Comments { get; set; } = null!;

        /// <summary>
        /// DbSet уведомлений в БД
        /// </summary>
        public DbSet<NotificationDB> Notifications { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}