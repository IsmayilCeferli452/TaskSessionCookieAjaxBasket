using FiorelloAsp.Data;
using FiorelloAsp.Models;
using FiorelloAsp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorelloAsp.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        public SliderService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Slider>> GetAllAsync()
        {
            return await _context.Sliders.ToListAsync();
        }

        public async Task<SliderInfo> GetSliderInfoAsync()
        {
            return await _context.SliderInfos.FirstOrDefaultAsync(m => !m.SoftDeleted);
        }
    }
}
