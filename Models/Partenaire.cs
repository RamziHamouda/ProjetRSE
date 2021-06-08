using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Models{
    public class Partenaire{
        [Key]
        public int Id {get; set;}
        public string Nom {get; set;}
        public string Logo {get; set;}
        public DateTime DateCreation {get; set;}
        public ICollection<PartenaireProjet> PartenaireProjet { get; set; }
    }
}