﻿using FiorelloAsp.Models;
using FiorelloAsp.ViewModels.Blog;

namespace FiorelloAsp.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }

        public SliderInfo SliderInfo { get; set; }

        public IEnumerable<BlogVM> Blogs { get; set; }

        public IEnumerable<Expert> Experts { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
