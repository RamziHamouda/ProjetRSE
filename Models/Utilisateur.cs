using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Models{
    public class Utilisateur{
        [Key]
        public int Id {get;set;}
        public string Nom {get; set;}
        public string Prenom {get; set;}
        public string Telephone {get; set;}
        public string Email {get; set;}
        public string PhotoProfil {get; set;}
        public string MotDePasse {get; set;}
        public string Profession {get; set;}
        public DateTime DateDeNaissance {get; set;}
        public string Description {get; set;}
        public bool MembreEquipeRSE {get; set;}
        public int Role {get; set;}
        public ICollection<Suggestion> Suggestions { get; set; }
        public ICollection<Impact> Impacts { get; set; }
    }
}