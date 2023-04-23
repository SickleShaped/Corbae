namespace Corbae.BLL.Exceptions.OrderExceptions
{
    /// <summary>
    /// Исключение, если заказ не найден
    /// </summary>
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException():base("Заказ не найден."){}
    }
}
