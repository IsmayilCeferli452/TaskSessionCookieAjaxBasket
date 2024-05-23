using FiorelloAsp.Models;
using FiorelloAsp.ViewModels.Blog;
using FiorelloAsp.ViewModels.Categories;

namespace FiorelloAsp.Services.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogVM>> GetAllAsync(int? take = null);
        Task<Blog> GetByIdAsync(int id);
        Task Delete(int id);
        Task Create(BlogCreateVM blog);
        Task<Blog> GetAllWithIdAsync(int? id);
    }
}
