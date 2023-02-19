using Corbae.Models;

namespace Corbae.BLL.Interfaces
{
    public interface ICartService
    {
        Task<Cart?> GetCartByUserID(string userID);
        Task<Cart?> AddToCart(Cart cart, Product product);
        Task<Cart?> RemoveFromCart(Cart cart, Product product);
    }
}
