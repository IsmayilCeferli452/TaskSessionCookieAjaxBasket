using FiorelloAsp.Services.Interfaces;
using FiorelloAsp.ViewModels;
using FiorelloAsp.ViewModels.Baskets;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FiorelloAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IExpertService _expertService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _accessor;

        public HomeController(ISliderService sliderService,
                              IBlogService blogService,
                              IExpertService expertService,
                              ICategoryService categoryService,
                              IProductService productService,
                              IHttpContextAccessor accessor)
        {
            _blogService = blogService;
            _expertService = expertService;
            _categoryService = categoryService;
            _productService = productService;
            _accessor = accessor;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM()
            {
                Blogs = await _blogService.GetAllAsync(3),
                Experts = await _expertService.GetAllAsync(),
                Categories = await _categoryService.GetAllAsync(),
                Products = await _productService.GetAllAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(int? id)
        {
            if (id == null) return BadRequest();

            var product = await _productService.GetByIdForBasket((int)id);

            if (product == null) return NotFound();

            List<BasketVM> basketDatas;

            if (_accessor.HttpContext.Request.Cookies["basket"] is not null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }
            else
            {
                basketDatas = new List<BasketVM>();
            }

            var existData = basketDatas.FirstOrDefault(m => m.Id == id);

            if (existData is not null)
            {
                existData.Count++;
            }
            else
            {
                basketDatas.Add(new BasketVM
                {
                    Id = (int)id,
                    Price = product.Price,
                    Count = 1
                });
            }

            _accessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketDatas));

            int count = basketDatas.Sum(m => m.Count);
            decimal totalPrice = basketDatas.Sum(m => m.Count * m.Price);
            
            return Ok(new { count, totalPrice });
        }

        [HttpGet]
        public IActionResult BasketDetails()
        {
            List<BasketVM> basketDatas = new List<BasketVM>();

            if (_accessor.HttpContext.Request.Cookies["basket"] is not null)
            {
                basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }

            return View(basketDatas);
        }








        //Serialize&Deserialize

        //Book book1 = new()
        //{
        //    Id = 1,
        //    Name = "Test"
        //};

        //var serializedData = JsonConvert.SerializeObject(book1);

        //_accessor.HttpContext.Response.Cookies.Append("book",serializedData);


        //public IActionResult GetCookieData()
        //{
        //    var data = JsonConvert.DeserializeObject<Book>(_accessor.HttpContext.Request.Cookies["book"]);

        //    return Json(data);
        //}
    }
}
