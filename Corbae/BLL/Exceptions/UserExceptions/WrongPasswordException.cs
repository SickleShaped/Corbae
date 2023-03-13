namespace Corbae.BLL.Exceptions.UserExceptions
{
    public class WrongPasswordException:Exception
    {
        public WrongPasswordException() : base($"Неправильный пароль") { }
    }
}
