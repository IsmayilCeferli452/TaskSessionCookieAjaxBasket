using FiorelloAsp.Data;
using FiorelloAsp.Services.Interfaces;
using FiorelloAsp.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloAsp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly AppDbContext _context;

        public CategoryController(ICategoryService categoryService,
                                  AppDbContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllWithProductCountAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM category)
        {
            var categories = await _categoryService.GetAllWithProductCountAsync();

            bool existCategory = categories.Any(m => m.CategoryName.Trim() == category.Name.Trim());

            if (existCategory)
            {
                ModelState.AddModelError("Name", "This category already exists");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            await _categoryService.Create(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
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

            await _categoryService.Delete((int)id);

            if (category.SoftDeleted)
            {
                return RedirectToAction("CategoryArchive", "Archive");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var category = await _categoryService.GetWithProductsAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var category = await _categoryService.GetWithProductsAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(new CategoryEditVM { Name = category.Name });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CategoryEditVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id == null)
            {
                return BadRequest();
            }

            var categories = await _categoryService.GetAllAsync();

            bool existCategory = categories.Any(m => m.Name.Trim().ToLower() == request.Name.Trim().ToLower());

            if (existCategory)
            {
                return RedirectToAction(nameof(Index));
            }

            var category = await _categoryService.GetByIdAsync((int)id);

            if (category == null)
            {
                return NotFound();
            }

            await _categoryService.Edit((int)id, request);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SetToArchive(int? id)
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

            category.SoftDeleted = true;

            await _context.SaveChangesAsync();

            return Ok(category);
        }
    }
}
