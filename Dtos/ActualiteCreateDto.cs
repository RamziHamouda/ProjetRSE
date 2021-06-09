using System;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Dtos{
    public class ActualiteCreateDto{
        [Required]
        public string Titre {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public string Image {get; set;}
    }
}