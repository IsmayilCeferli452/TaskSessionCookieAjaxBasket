using System.ComponentModel.DataAnnotations;

namespace FiorelloAsp.ViewModels.Sliders
{
    public class SliderCreateVM
    {
        [Required]
        public List<IFormFile> Images { get; set; }
    }
}
