namespace Corbae.Exceptions.UserExceptions
{
    /// <summary>
    /// Исключение о том, что данная электронная почта уже используется
    /// </summary>
    public class EmailAlreadyInUseException:Exception
    {
        public EmailAlreadyInUseException(string email) : base($"Электронная почта {email} уже используется. Пожалуйста, используйте другую, либо войтите в аккаунт.") { }
    }
}
