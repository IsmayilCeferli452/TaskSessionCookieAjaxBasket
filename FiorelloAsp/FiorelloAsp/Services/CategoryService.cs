using FiorelloAsp.Data;
using FiorelloAsp.Models;
using FiorelloAsp.Services.Interfaces;
using FiorelloAsp.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;

namespace FiorelloAsp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<CategoryProductVM>> GetAllWithProductCountAsync()
        {
            IEnumerable<Category> categories = await _context.Categories.Include(m=>m.Products)
                                                                        .OrderByDescending(m=>m.Id)
                                                                        .ToListAsync();
            return categories.Select(m => new CategoryProductVM
            {
                Id = m.Id,
                CategoryName = m.Name,
                CreatedDate = m.CreateDate.ToString("MM.dd.yyyy"),
                ProductCount = m.Products.Count,
            }
            );
        }

        public async Task Create(CategoryCreateVM category)
        {
            await _context.Categories.AddAsync(new Category
            {
                Name = category.Name
            });
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.IgnoreQueryFilters().FirstOrDefaultAsync(m=> m.Id == id);
        }

        public async Task Delete(int id)
        {
            var category = await GetByIdAsync(id);

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetWithProductsAsync(int? id)
        {
            Category category = await _context.Categories.Include(m => m.Products)
                                                         .FirstOrDefaultAsync(m => m.Id == id);
            return category;
        }

        public async Task Edit(int id, CategoryEditVM request)
        {
            var category = await GetByIdAsync(id);

            category.Name = request.Name;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryArchiveVM>> GetAllArchivesAsync()
        {
            IEnumerable<Category> categories = await _context.Categories.IgnoreQueryFilters()
                                                                        .Where(m=> m.SoftDeleted)
                                                                        .OrderByDescending(m => m.Id)
                                                                        .ToListAsync();
            return categories.Select(m => new CategoryArchiveVM
            {
                Id = m.Id,
                CategoryName = m.Name,
                CreatedDate = m.CreateDate.ToString("MM.dd.yyyy")
            });
        }
    }
}
