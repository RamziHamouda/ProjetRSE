using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Dtos{
    public class StatistiqueContribution {
        public string TitreProjet {get; set;}
        public int Contribution {get; set;}
    }
}