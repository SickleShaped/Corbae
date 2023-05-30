namespace Corbae.DAL.Models.Auxiliary_Models
{
    /// <summary>
    /// Класс, содержащий поля пользователя, используемые для входа в аккаунт
    /// </summary>
    public class UserToLogin
    {
        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Хэш и Соль пароля
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
