namespace Corbae.BLL.Exceptions.CartExceptions
{
    /// <summary>
    /// Исключение при добавлении своего товара в свою корзину
    /// </summary>
    public class ProhibitionToAddOwnProductToCartException : Exception
    {
        public ProhibitionToAddOwnProductToCartException() : base("Невозможно добавить свой товар в корзину") { }
    }
}
