using System.ComponentModel.DataAnnotations;

namespace Corbae.Models
{
    public class Cart
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();



    }
}
