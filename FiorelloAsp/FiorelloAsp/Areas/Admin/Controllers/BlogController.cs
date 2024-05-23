using FiorelloAsp.Data;
using FiorelloAsp.Extentions;
using FiorelloAsp.Services;
using FiorelloAsp.Services.Interfaces;
using FiorelloAsp.ViewModels.Blog;
using FiorelloAsp.ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace FiorelloAsp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public BlogController(IBlogService blogService,
                              AppDbContext appDbContext,
                              IWebHostEnvironment environment)
        {
            _blogService = blogService;
            _context = appDbContext;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _blogService.GetAllAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCreateVM blog)
        {
            var blogs = await _blogService.GetAllAsync();

            bool existCategory = blogs.Any(m => m.Title.Trim() == blog.Title.Trim() && m.Description.Trim() == blog.Description.Trim());

            if (existCategory)
            {
                ModelState.AddModelError("Title", "This blog already exists");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (blog.Image == null)
            {
                ModelState.AddModelError("Image", "Image required");
                return View(blog);
            }

            //Extension
            if (!blog.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Format is wrong");
                return View();
            }

            //Extension
            if (!blog.Image.CheckFileSize(200))
            {
                ModelState.AddModelError("Image", "Max image size is 200 KB");
                return View();
            }

            //Unique file adi yaratmaq
            string fileName = Guid.NewGuid().ToString() + "-" + blog.Image.FileName;

            //Path-i tapmaq
            string path = Path.Combine(_environment.WebRootPath, "img", fileName);

            //Extension
            await blog.Image.SaveFileToLocalAsync(path);

            await _context.Blogs.AddAsync(new Models.Blog { Image = fileName, Title = blog.Title, Description = blog.Description });
            await _context.SaveChangesAsync();

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

            var category = await _blogService.GetByIdAsync((int)id);

            if (category == null)
            {
                return NotFound();
            }

            await _blogService.Delete((int)id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var blog = await _blogService.GetAllWithIdAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var blog = await _context.Blogs.FindAsync((int)id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(new BlogEditVM { Image = blog.Image, Title = blog.Title, Description = blog.Description });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BlogEditVM request)
        {
            var blog = await _context.Blogs.FindAsync((int)id);

            var blogs = await _blogService.GetAllAsync();

            if (id == null)
            {
                return BadRequest();
            }

            if (blog == null)
            {
                return NotFound();
            }

            bool existCategory = blogs.Any(m => m.Title.Trim() == request.Title.Trim() &&
                    m.Description.Trim() == request.Description.Trim());

            if (existCategory)
            {
                return RedirectToAction(nameof(Index));
            }

            if (request.NewImage != null)
            {
                //Extension
                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Image", "Format is wrong");
                    request.Image = blog.Image;
                    return View(request);
                }

                //Extension
                if (!request.NewImage.CheckFileSize(200))
                {
                    ModelState.AddModelError("Image", "Max image size is 200 KB");
                    request.Image = blog.Image;
                    return View(request);
                }

                string oldPath = Path.Combine(_environment.WebRootPath, "img", blog.Image);

                if (System.IO.File.Exists(oldPath))
                    System.IO.File.Delete(oldPath);

                string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

                string newPath = Path.Combine(_environment.WebRootPath, "img", fileName);

                await request.NewImage.SaveFileToLocalAsync(newPath);

                blog.Image = fileName;
            }

            blog.Title = request.Title;
            blog.Description = request.Description;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
