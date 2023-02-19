using Corbae.Models;

namespace Corbae.BLL.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        Task<Product> GetById(string id);
        Task<Product> Create(Product product);
    }
}
