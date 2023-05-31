using Corbae.DAL.Models;
using Corbae.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Corbae.DAL.Models.DBModels
{
    /// <summary>
    /// Класс, содержащий поля пользователя, получаемого из БД 
    /// </summary>
    public class UserDB
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public Guid UserID { get; set; }

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
        /// Баланс пользователя
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// Является ли пользователь Админом
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Является ли пользователь Продавцом
        /// </summary>
        public bool IsSeller { get; set; }

        /// <summary>
        /// Корзина пользователя
        /// </summary>
        public CartDB? Cart { get; set; }

        /// <summary>
        /// Желаемое пользователя
        /// </summary>
        public WishDB? Wish { get; set; }

        /// <summary>
        /// Товары, добавленные пользователем
        /// </summary>
        public List<ProductDB> Products { get; set; } = new List<ProductDB>();

        /// <summary>
        /// Заказы пользователя
        /// </summary>
        public List<OrderDB> Orders { get; set; } = new List<OrderDB>();

        /// <summary>
        /// Вспомогательное поле для связи МкМ
        /// </summary>
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        /// <summary>
        /// Комментарии пользователя
        /// </summary>
        public List<CommentDB> Comments { get; set; } = new List<CommentDB>();

        /// <summary>
        /// Уведомления пользователя
        /// </summary>
        public List<NotificationDB> Notifications { get; set; } = new List<NotificationDB>();


    }
}
