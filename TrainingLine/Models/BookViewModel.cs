using System.ComponentModel.DataAnnotations;
namespace TrainingLine.Models
{
    public class BookViewModel : EditImageViewModel
    {
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter Title")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter Total Pages")]
        public int Total_Pages { get; set; }
        [Required(ErrorMessage = "Please enter Title")]
        public string Language { get; set; }
    }
}
