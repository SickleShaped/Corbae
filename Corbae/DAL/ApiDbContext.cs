using Corbae.Configure;
using Corbae.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Corbae.DAL.Models.DBModels;

namespace Corbae.DAL
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext() => Database.EnsureCreated();

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<UserDB> Users { get; set; } = null!;
        public DbSet<CartDB> Carts { get; set; } = null!;
        public DbSet<OrderDB> Orders { get; set; } = null!;
        public DbSet<ProductDB> Products { get; set; } = null!;
        public DbSet<OrderProduct> OrdersProducts { get; set; } = null!;
        public DbSet<CartProduct> CartProducts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*builder.ApplyConfiguration(new ConfigureUser());
            builder.ApplyConfiguration(new ConfigureCart());
            builder.ApplyConfiguration(new ConfigureOrder());
            builder.ApplyConfiguration(new ConfigureProduct());*/
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}