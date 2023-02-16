using System.ComponentModel.DataAnnotations;

namespace Corbae.Models
{
    public class Product
    {
        //[Key]
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public uint QuantityInStock { get; set; }
        public string Category { get; set; }


        public string UserID { get; set; }
        public User User { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public List<Cart> Carts { get; set; } = new List<Cart>();

        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();


    }
}
