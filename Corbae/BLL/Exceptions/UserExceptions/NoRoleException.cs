namespace Corbae.Exceptions.UserExceptions
{
    public class NoRoleException:Exception
    {
        public NoRoleException() : base($"Не выбраны роли пользователя. Выберете хотя бы одну - покупатель или продавец") { }
    }
}
