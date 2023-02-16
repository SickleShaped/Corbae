using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Corbae.Models
{
    public class CartProduct
    {
        //[Key]
        public string CartProductID { get; set; }
        public string ProductID { get; set; }
        public string CartID { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }

        [JsonIgnore]
        public Cart? Cart { get; set; }

    }
}
