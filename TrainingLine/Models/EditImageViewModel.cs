﻿namespace TrainingLine.Models
{
    public class EditImageViewModel : UploadImageViewModel
    {
        public int Id { get; set; } 
        public string ExistingImage { get; set; }
    }
}
