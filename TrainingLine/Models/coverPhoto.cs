using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrainingLine.Models
{
    public class coverPhoto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter Author")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Total_Pages { get; set; }
        [Required(ErrorMessage = "Please enter Language")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Please enter Language")]
        public IFormFile CoverPhoto { get; set; }
    }
}
