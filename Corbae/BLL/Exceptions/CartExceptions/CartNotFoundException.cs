namespace Corbae.BLL.Exceptions.UserExceptions
{
    public class CartNotFoundException:Exception
    {
        public CartNotFoundException() : base("Корзина не найдена.") { }
    }
}
