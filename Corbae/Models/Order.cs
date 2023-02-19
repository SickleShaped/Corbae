using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Corbae.Models
{
    public class Order
    {
        public string OrderID { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public string DeliveryPlace { get; set; } = null!;

        public User User { get; set; } = null!;
        public string UserID { get; set; } = null!;
        public List<Product> Products { get; set; } = new List<Product>();

        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    }
}
