namespace Corbae.Exceptions.UserExceptions
{
    public class EmailAlreadyInUseException:Exception
    {
        public EmailAlreadyInUseException(string email) : base($"Электронная почта {email} уже используется. Пожалуйста, используйте другую, либо войтите в аккаунт.") { }
    }
}
