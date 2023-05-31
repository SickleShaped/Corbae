namespace Corbae.DAL.Models.Auxiliary_Models
{
    /// <summary>
    /// Класс, содержащий поля пользователя, используемые для создания или изменения пользователя
    /// </summary>
    public class UserToCreate
    {
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
        /// Является ли пользователь Продавцом
        /// </summary>
        public bool IsSeller { get; set; }



    }
}
