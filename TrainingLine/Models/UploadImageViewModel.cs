using System.ComponentModel.DataAnnotations;

namespace TrainingLine.Models
{
    public class UploadImageViewModel
    {
        [Required]
        [Display(Name = "Cover Photo")]
        public IFormFile CoverPhoto { get; set; }
    }
}
