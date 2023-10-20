using System.ComponentModel.DataAnnotations;

namespace TrainingLine.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Total_Pages { get; set; }
        public string Language { get; set; }
    }
}
