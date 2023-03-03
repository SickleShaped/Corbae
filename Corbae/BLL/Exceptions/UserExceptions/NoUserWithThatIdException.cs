namespace Corbae.Exceptions.UserExceptions
{
    public class NoUserWithThatIdException:Exception
    {
        public NoUserWithThatIdException(string id) : base($"Пользователь с ID {id} не найден") { }
    }
}
