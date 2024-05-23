using FiorelloAsp.Data;
using FiorelloAsp.Extentions;
using FiorelloAsp.ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace FiorelloAsp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SliderController(AppDbContext context,
                                IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.Select(m => new SliderVM { Image = m.Image, Id = m.Id })
                                                .ToListAsync();
            return View(sliders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            foreach (var item in request.Images)
            {
                if (!item.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Image", "Format is wrong");
                    return View();
                }

                //Extension
                if (!item.CheckFileSize(200))
                {
                    ModelState.AddModelError("Image", "Max image size is 200 KB");
                    return View();
                }
            }

            //Extension

            foreach(var image in request.Images)
            {
                //Unique file adi yaratmaq
                string fileName = Guid.NewGuid().ToString() + "-" + image.FileName;

                //Path-i tapmaq
                string path = Path.Combine(_environment.WebRootPath, "img", fileName);

                //Extension
                await image.SaveFileToLocalAsync(path);

                await _context.Sliders.AddAsync(new Models.Slider { Image = fileName });
                await _context.SaveChangesAsync();
            }

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

            var slider = await _context.Sliders.FindAsync((int)id);

            if (slider == null)
            {
                return NotFound();
            }

            //Sekilin ozunude project-den silmek ucun
            string path = Path.Combine(_environment.WebRootPath, "img", slider.Image);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            //Normal
            _context.Sliders.Remove(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var slider = await _context.Sliders.FindAsync((int)id);

            if (slider == null)
            {
                return NotFound();
            }

            return View(new SliderEditVM { Image = slider.Image });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SliderEditVM request)
        {
            var slider = await _context.Sliders.FindAsync((int)id);

            if (!request.NewImage.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Format is wrong");
                request.Image = slider.Image;
                return View(request);
            }

            //Extension
            if (!request.NewImage.CheckFileSize(200))
            {
                ModelState.AddModelError("Image", "Max image size is 200 KB");
                request.Image = slider.Image;
                return View(request);
            }

            if (id == null)
            {
                return BadRequest();
            }

            if (slider == null)
            {
                return NotFound();
            }

            if (request.NewImage is null) return RedirectToAction(nameof(Index));

            string oldPath = Path.Combine(_environment.WebRootPath, "img", slider.Image);

            if (System.IO.File.Exists(oldPath))
                System.IO.File.Delete(oldPath);

            string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

            string newPath = Path.Combine(_environment.WebRootPath, "img", fileName);

            await request.NewImage.SaveFileToLocalAsync(newPath);

            slider.Image = fileName;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
