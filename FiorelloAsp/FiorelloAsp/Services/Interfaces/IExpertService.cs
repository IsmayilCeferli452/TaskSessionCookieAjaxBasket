using FiorelloAsp.Models;
using FiorelloAsp.ViewModels.Blog;

namespace FiorelloAsp.Services.Interfaces
{
    public interface IExpertService
    {
        Task<IEnumerable<Expert>> GetAllAsync();
    }
}
