using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Corbae.Models
{
    public class CartProduct
    {
        //[Key]
        public string CartProductID { get; set; } = null!;
        public string ProductID { get; set; } = null!;
        public string CartID { get; set; } = null!;

        [JsonIgnore]
        public Product? Product { get; set; }

        [JsonIgnore]
        public Cart? Cart { get; set; }

    }
}
