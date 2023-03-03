namespace Corbae.Exceptions.UserExceptions
{
    public class GuidDuplicateException:Exception
    {
        public GuidDuplicateException() : base($"Произошла ошибка при создании уникального идентификатора Guid. Попробуйте еще раз") { }
    }
}
