using FiorelloAsp.Services;
using FiorelloAsp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloAsp.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISocialsService _socialsService;

        public FooterViewComponent(ISocialsService socialsService)
        {
            _socialsService = socialsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View(await _socialsService.GetAllAsync()));
        }
    }
}
