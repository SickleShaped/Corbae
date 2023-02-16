using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Corbae.Models
{
    public class OrderProduct
    {
        //[Key]
        public string OrderProductID { get; set; }
        public string OrderID { get; set; }
        public string ProductID { get; set; }

        [JsonIgnore]
        public Order? Order { get; set; }

        [JsonIgnore]
        public Product? Product { get;set; }

    }
}
