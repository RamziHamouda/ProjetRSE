using System;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Models{
    public class ActualiteUpdateDto{
        [Required]
        public string Titre {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public string Image {get; set;}
    }
}