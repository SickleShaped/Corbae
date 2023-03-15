using System.ComponentModel.DataAnnotations;
using Corbae.DAL.Models.DBModels;
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
        public OrderDB? Order { get; set; }

        [JsonIgnore]
        public ProductDB? Product { get;set; }

    }
}
