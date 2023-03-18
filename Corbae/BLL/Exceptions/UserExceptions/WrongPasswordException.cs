namespace Corbae.BLL.Exceptions.UserExceptions
{
    /// <summary>
    /// Исключение неправильного пароля
    /// </summary>
    public class WrongPasswordException:Exception
    {
        public WrongPasswordException() : base($"Неправильный пароль") { }
    }
}
