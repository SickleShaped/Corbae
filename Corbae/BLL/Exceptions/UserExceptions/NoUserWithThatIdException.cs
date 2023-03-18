namespace Corbae.Exceptions.UserExceptions
{
    /// <summary>
    /// Исключение о том, что не найден пользователь с данным ID
    /// </summary>
    public class NoUserWithThatIdException:Exception
    {
        public NoUserWithThatIdException(Guid id) : base($"Пользователь с ID {id} не найден") { }
    }
}
