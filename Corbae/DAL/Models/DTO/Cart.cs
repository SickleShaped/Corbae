using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Corbae.DAL.Models.DBModels;

namespace Corbae.Models
{
    public class Cart
    {
        /// <summary>
        /// Id Корзины
        /// </summary>
        public Guid CartID { get; set; }

        /// <summary>
        /// Пользователь, к которому принадлежит корзина
        /// </summary>
        public UserDB User { get; set; } = null!;


        


    }
}
