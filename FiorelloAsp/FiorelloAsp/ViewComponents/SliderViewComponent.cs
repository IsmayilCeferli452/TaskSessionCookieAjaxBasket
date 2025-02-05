﻿using FiorelloAsp.Models;
using FiorelloAsp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace FiorelloAsp.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;
        public SliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliderDatas = new SliderVMVC
            {
                Sliders = await _sliderService.GetAllAsync(),
                SliderInfo = await _sliderService.GetSliderInfoAsync()
            };
            return await Task.FromResult(View(sliderDatas));
        }

        public class SliderVMVC
        {
            public IEnumerable<Slider> Sliders { get; set; }
            public SliderInfo SliderInfo { get; set; }
        }
    }
}
