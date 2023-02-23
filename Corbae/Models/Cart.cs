﻿using System.ComponentModel.DataAnnotations;

namespace Corbae.Models
{
    public class Cart
    {
        /// <summary>
        /// Id Корзины
        /// </summary>
        public string CartID { get; set; } = null!;

        /// <summary>
        /// Пользователь, к которому принадлежит корзина
        /// </summary>
        public User User { get; set; } = null!;

        /// <summary>
        /// Продукты, содержащиеся в корзине
        /// </summary>
        public List<Product> Products { get; set; } = new List<Product>();
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        


    }
}
