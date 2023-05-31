namespace Corbae.BLL.Exceptions.ProductExceptions
{
    /// <summary>
    /// Исключение, при попытке купить товар, который закончился на складе
    /// </summary>
    public class ProductOutOfStockException:Exception
    {
        public ProductOutOfStockException(string productName) : base($"Товар {productName} закончился на складе. Заказ отменен.") { }
    }
}
