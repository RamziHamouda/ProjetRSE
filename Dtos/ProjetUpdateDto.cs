using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Dtos{
    public class ProjetUpdateDto{
        public int Id {get;set;}
        public string Titre {get; set;}
        public string Description {get; set;}
        public string Categorie {get; set;}
        public string Image1 {get; set;}
        public string Image2 {get; set;}
        public string Image3 {get; set;}
        public string Image4 {get; set;}
        public int NombreDeVues {get; set;}
        public List<int> Partenaires{get; set;}

    }
}