using FiorelloAsp.Data;
using FiorelloAsp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloAsp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArchiveController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly AppDbContext _context;

        public ArchiveController(ICategoryService categoryService,
                                 AppDbContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }
        public async Task<IActionResult> CategoryArchive()
        {
            return View(await _categoryService.GetAllArchivesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> RestoreFromArchive(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var category = await _categoryService.GetByIdAsync((int)id);

            if (category == null)
            {
                return NotFound();
            }

            category.SoftDeleted = false;

            await _context.SaveChangesAsync();

            return Ok(category);
        }
    }
}
