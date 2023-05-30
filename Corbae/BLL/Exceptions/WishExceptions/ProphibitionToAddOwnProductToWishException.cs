namespace Corbae.BLL.Exceptions.WishExceptions
{
    /// <summary>
    /// Исключение при добавлении своего товара в свою желаемое
    /// </summary>
    public class ProphibitionToAddOwnProductToWishException : Exception
    {
        public ProphibitionToAddOwnProductToWishException() : base("Невозможно добавить свой товар в желаемое") { }
    }
}
