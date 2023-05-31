namespace Corbae.DAL.Models.Auxiliary_Models
{
    /// <summary>
    /// Класс содержащший поля для возврата при логине
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// jwt-токен
        /// </summary>
        public string Jwt { get; set; } = null!;
        /// <summary>
        /// ID пользователя
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// время жизни токена
        /// </summary>
        public long Expires { get; set; }
    }
}
