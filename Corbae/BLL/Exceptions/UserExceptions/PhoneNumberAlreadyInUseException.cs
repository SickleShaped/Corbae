namespace Corbae.BLL.Exceptions.UserExceptions
{
    /// <summary>
    /// Исключение о том, что номер телефона уже используется
    /// </summary>
    public class PhoneNumberAlreadyInUseException:Exception
    {
        public PhoneNumberAlreadyInUseException(string phoneNumber) : base($"Номер телефона {phoneNumber} уже используется.") { }
    }
}
