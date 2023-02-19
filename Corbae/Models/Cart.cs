using System.ComponentModel.DataAnnotations;

namespace Corbae.Models
{
    public class Cart
    {
        public string CartID { get; set; } = null!;
        public User User { get; set; } = null!;

        public List<Product> Products { get; set; } = new List<Product>();
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();



    }
}
