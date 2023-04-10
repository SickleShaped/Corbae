namespace Corbae.BLL.Exceptions.UserExceptions
{
    public class NoUserWithThatEmailException:Exception
    {
        public NoUserWithThatEmailException(string email) : base($"Пользователь с почтой {email} не найден.") { }
    }
}
