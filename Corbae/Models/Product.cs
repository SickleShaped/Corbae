using System.ComponentModel.DataAnnotations;

namespace Corbae.Models
{
    public class Product
    {
        //[Key]
        public string ProductID { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public uint QuantityInStock { get; set; }
        public string Category { get; set; } = null!;


        public string UserID { get; set; } = null!;
        public User User { get; set; } = null!;

        public List<Order> Orders { get; set; } = new List<Order>();

        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public List<Cart> Carts { get; set; } = new List<Cart>();

        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();


    }
}
