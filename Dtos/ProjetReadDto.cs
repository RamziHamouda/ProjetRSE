using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Models{
    public class ProjetReadDto{
        public int Id {get;set;}
        public string Titre {get; set;}
        public string Description {get; set;}
        public string Image1 {get; set;}
        public string Image2 {get; set;}
        public string Image3 {get; set;}
        public string Image4 {get; set;}
        public DateTime DateCreation {get; set;}
    }
}