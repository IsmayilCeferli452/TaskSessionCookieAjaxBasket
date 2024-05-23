using System.ComponentModel.DataAnnotations;

namespace FiorelloAsp.ViewModels.Blog
{
    public class BlogCreateVM
    {
        [Required(ErrorMessage = "Input's can't be empty")]
        [StringLength(10, ErrorMessage = "The blog title must not exceed 10 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The blog description must not exceed 10 characters.")]
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
