using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Dtos{
    public class PartenaireReadDto {
        public int Id {get; set;}
        public string Nom {get; set;}
        public string Logo {get; set;}
        public DateTime DateCreation {get; set;}
    }
}