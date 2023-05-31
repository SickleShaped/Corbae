namespace Corbae.BLL.Exceptions.ProductExceptions
{
    /// <summary>
    /// Исключение о том, что не найден товар с данным ID
    /// </summary>
    public class NoProductWithThatIdException : Exception
    {
        public NoProductWithThatIdException(Guid id) : base($"Товар с ID {id} не найден") { }
    }
}
