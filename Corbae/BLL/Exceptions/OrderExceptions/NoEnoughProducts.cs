namespace Corbae.BLL.Exceptions.OrderExceptions
{
    /// <summary>
    /// Исключение, если у пользователя не достаточно денег для покупки
    /// </summary>
    public class NoEnoughProductsException:Exception
    {
        public NoEnoughProductsException(string name) : base($"Недостаточно продукта {name} на складе. ") { }
    }
}
