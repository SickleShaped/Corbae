namespace Corbae.BLL.Exceptions.CommentExceptions
{
    /// <summary>
    /// Исключение при ошибке удаления комментария
    /// </summary>
    public class DeleteCommentErrorException:Exception
    {
        public DeleteCommentErrorException() : base($"Произошла ошибка при удалении комментария") { }
    }
}
