using FiorelloAsp.Models;

namespace FiorelloAsp.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByIdForBasket(int id);
    }
}
