using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Dtos{
    public class StatistiquePourcentageImpact{
        public int NombreUtilisateurs {get; set;}
        public float NombreImpactParUtilisateur {get; set;}
    }
}