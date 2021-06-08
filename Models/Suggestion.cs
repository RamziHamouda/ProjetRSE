using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSEBack.Models{
    public class Suggestion {
        [Key]
        public int Id {get; set;}
        public string Sujet {get; set;}
        public string Description {get; set;}
        public DateTime DateCreation {get; set;}
        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}