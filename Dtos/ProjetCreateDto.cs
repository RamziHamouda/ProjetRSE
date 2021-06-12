using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Dtos{
    public class ProjetCreateDto{
        [Required]
        public string Titre {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public string Categorie {get; set;}
        public string Image1 {get; set;}
        public string Image2 {get; set;}
        public string Image3 {get; set;}
        public string Image4 {get; set;}
        public int NombreDeVues {get; set;}
    }
}