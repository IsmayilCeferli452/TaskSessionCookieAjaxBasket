using FiorelloAsp.Data;
using FiorelloAsp.Models;
using FiorelloAsp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorelloAsp.Services
{
    public class ExpertService : IExpertService
    {
        private readonly AppDbContext _context;
        public ExpertService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Expert>> GetAllAsync()
        {
            return await _context.Experts.ToListAsync();
        }
    }
}
