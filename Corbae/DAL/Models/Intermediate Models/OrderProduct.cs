using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Corbae.Models
{
    public class OrderProduct
    {
        //[Key]
        public Guid OrderProductID { get; set; }
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }

        [JsonIgnore]
        public Order? Order { get; set; }

        [JsonIgnore]
        public Product? Product { get;set; }

    }
}
