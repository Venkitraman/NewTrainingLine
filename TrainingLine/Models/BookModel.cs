﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrainingLine.Models
{
    public class BookModel
    {
        [Key]        
        public int Id { get; set; }
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
        //[DisplayName("Choose a Cover Photo")]
        //[Required]
        //public string CoverPhoto { get; set; }
    }
}
