namespace Corbae.DAL.Models.Auxiliary_Models
{
    /// <summary>
    /// Класс, содержащий поля пользователя, используемые для изменения пользователя
    /// </summary>
    public class UserToEdit
    {
        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; } = null!;

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


    }
}
