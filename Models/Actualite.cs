using System;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Models{
    public class Actualite{
        [Key]
        public int Id {get;set;}
        public string Titre {get; set;}
        public string Description {get; set;}
        public string Image {get; set;}
        public DateTime DateCreation {get; set;}
    }
}