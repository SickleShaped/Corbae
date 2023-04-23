namespace Corbae.BLL.Exceptions.UserExceptions
{
    public class UserNotFoundException:Exception
    {
        public UserNotFoundException() : base("Пользователь не найден.") { }
    }
}
