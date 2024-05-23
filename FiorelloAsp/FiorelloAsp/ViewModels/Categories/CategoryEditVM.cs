using System.ComponentModel.DataAnnotations;

namespace FiorelloAsp.ViewModels.Categories
{
    public class CategoryEditVM
    {
        [Required(ErrorMessage = "This input can't be empty")]
        public string Name { get; set; }
    }
}
