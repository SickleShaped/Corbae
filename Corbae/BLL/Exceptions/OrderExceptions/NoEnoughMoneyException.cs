namespace Corbae.BLL.Exceptions.OrderExceptions
{
    /// <summary>
    /// Исключение, если у пользователя не достаточно денег для покупки
    /// </summary>
    public class NoEnoughMoneyException:Exception
    {
        public NoEnoughMoneyException(decimal userMoney, decimal orderPrice) : base($"Недостаточно денег для оплаты товара. Стоимость заказа: {orderPrice} рублей. Ваш баланс: {userMoney} рублей ") { }
    }
}
