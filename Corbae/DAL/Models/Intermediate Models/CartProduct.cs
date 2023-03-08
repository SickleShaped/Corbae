using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Corbae.Models
{
    public class CartProduct
    {
        //[Key]
        public Guid CartProductID { get; set; }
        public Guid ProductID { get; set; }
        public Guid CartID { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }

        [JsonIgnore]
        public Cart? Cart { get; set; }

    }
}
