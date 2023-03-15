using Corbae.DAL.Models.DBModels;
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
        public ProductDB? Product { get; set; }

        [JsonIgnore]
        public CartDB? Cart { get; set; }
        

    }
}
