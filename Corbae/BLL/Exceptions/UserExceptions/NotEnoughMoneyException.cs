namespace Corbae.BLL.Exceptions.UserExceptions
{
    /// <summary>
    /// Исключение о том, что на счету пользователя недостаточно средств для списания
    /// </summary>
    public class NotEnoughMoneyException:Exception
    {
        public NotEnoughMoneyException():base("Недостаточно средств для списания"){}
    }
}
