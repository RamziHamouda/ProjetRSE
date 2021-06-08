using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSEBack.Models{
    public class PartenaireProjet{
        [Key]
        public int Id {get;set;}
        public string DateCreation {get; set;}
        [ForeignKey("Projet")]
        public int IdProjet { get; set; }
        public Projet Projet { get; set; }
        [ForeignKey("Partenaire")]
        public int IdPartenaire { get; set; }
        public Partenaire Partenaire { get; set; }
    }
}