﻿using FiorelloAsp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloAsp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _blogService.GetAllAsync(6));
        }
    }
}
