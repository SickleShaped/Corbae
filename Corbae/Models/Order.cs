using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Corbae.Models
{
    public class Order
    {
        public string OrderID { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public User User { get; set; }
        public string UserID { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    }
}
