using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Dtos{
    public class StatistiqueComptage{
        public int NombreProjets {get; set;}
        public int NombreEmployes {get; set;}
        public int NombrePartenaires {get; set;}
        public int NombreSuggesstions {get; set;}
    }
}