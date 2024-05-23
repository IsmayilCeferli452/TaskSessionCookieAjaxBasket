using System.ComponentModel.DataAnnotations;

namespace FiorelloAsp.Models
{
    public class SliderInfo : BaseEntity
    {
        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public string Image { get; set; }

    }
}
