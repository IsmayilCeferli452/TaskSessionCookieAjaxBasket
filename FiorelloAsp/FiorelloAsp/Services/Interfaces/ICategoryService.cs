using FiorelloAsp.Models;
using FiorelloAsp.ViewModels.Categories;

namespace FiorelloAsp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<CategoryProductVM>> GetAllWithProductCountAsync();
        Task Create(CategoryCreateVM category);
        Task<Category> GetByIdAsync(int id);
        Task Delete(int id);
        Task<Category> GetWithProductsAsync(int? id);
        Task Edit(int id, CategoryEditVM request);
        Task<IEnumerable<CategoryArchiveVM>> GetAllArchivesAsync();
    }
}
