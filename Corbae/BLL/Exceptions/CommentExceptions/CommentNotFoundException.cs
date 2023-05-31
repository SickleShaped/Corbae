using Microsoft.AspNetCore.Server.IIS.Core;

namespace Corbae.BLL.Exceptions.CommentExceptions
{
    /// <summary>
    /// Комментарий не найден
    /// </summary>
    public class CommentNotFoundException:Exception
    {
        public CommentNotFoundException() : base($"Комментарий не найден") { }
    }
}
