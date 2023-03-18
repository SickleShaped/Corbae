using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Corbae.BLL.Implementations
{
    /// <summary>
    /// Класс, в котором реализованы методы взаимодействия с корзиной
    /// </summary>
    public class CartService:ICartService
    {
        private readonly ApiDbContext _dbContext;

        public CartService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       // public async Task<Cart?> GetCartByUserID(string userID)
        //{
           // return await _dbContext.Carts.Include(u=>u.Products).FirstOrDefaultAsync(u=>u.User==);
       // }
    }
}
