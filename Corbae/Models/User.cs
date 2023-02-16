using System.ComponentModel.DataAnnotations;

namespace Corbae.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? Company { get; set; }
        public string Adress { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Money { get; set; }
        public ulong Rating { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsSeller { get; set; }
        public bool IsCustomer { get; set; }


        public Cart Cart { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();


    }
}
