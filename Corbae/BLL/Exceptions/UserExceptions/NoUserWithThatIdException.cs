namespace Corbae.Exceptions.UserExceptions
{
    public class NoUserWithThatIdException:Exception
    {
        public NoUserWithThatIdException(Guid id) : base($"Пользователь с ID {id} не найден") { }
    }
}
