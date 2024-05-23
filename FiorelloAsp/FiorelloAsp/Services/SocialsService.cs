using FiorelloAsp.Data;
using FiorelloAsp.Models;
using FiorelloAsp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorelloAsp.Services
{
    public class SocialsService : ISocialsService
    {
        private readonly AppDbContext _context;

        public SocialsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<FooterSocials>> GetAllAsync()
        {
            return await _context.Socials.ToListAsync();
        }
    }
}
