using System.ComponentModel.DataAnnotations;

namespace FiorelloAsp.ViewModels.Categories
{
    public class CategoryCreateVM
    {
        [Required(ErrorMessage = "This input can't be empty")]
        [StringLength(10, ErrorMessage = "The category name must not exceed 10 characters.")]
        public string Name { get; set; }
    }
}
