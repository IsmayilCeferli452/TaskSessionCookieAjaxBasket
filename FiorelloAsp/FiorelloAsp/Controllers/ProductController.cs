using FiorelloAsp.Models;
using FiorelloAsp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloAsp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) 
            {
                return BadRequest();
            }
            Product product = await _productService.GetByIdAsync((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
