using System.ComponentModel.DataAnnotations;

namespace Corbae.Models
{
    public class User
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public string UserID { get; set; } = null!;

        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Хэш и Соль пароля
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Компания, в которой работает пользователь, если есть
        /// </summary>
        public string? Company { get; set; }

        /// <summary>
        /// Адрес пользователя
        /// </summary>
        public string? Adress { get; set; }

        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Дата создания пользователя
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Баланс пользователя
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// Рейтинг пользователя
        /// </summary>
        public ulong Rating { get; set; }

        /// <summary>
        /// Является ли пользователь Админом
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Является ли пользователь Продавцом
        /// </summary>
        public bool IsSeller { get; set; }

        /// <summary>
        /// Является ли пользователь Покупателем
        /// </summary>
        public bool IsCustomer { get; set; }

        /// <summary>
        /// Корзина пользователя
        /// </summary>
        public Cart Cart { get; set; } = null!;

        /// <summary>
        /// Товары, добавленные пользователем
        /// </summary>
        public List<Product> Products { get; set; } = new List<Product>();
        
        /// <summary>
        /// Заказы пользователя
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();


    }
}
