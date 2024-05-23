using FiorelloAsp.Data;
using FiorelloAsp.Models;
using FiorelloAsp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorelloAsp.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(m => m.ProductImages).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Where(m=> m.Id == id)
                                          .Include(m=> m.Category)
                                          .Include(m => m.ProductImages)
                                          .FirstOrDefaultAsync();
        }

        public async Task<Product> GetByIdForBasket(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
