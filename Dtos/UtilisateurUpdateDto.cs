using System;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Models{
    public class UtilisateurUpdateDto {
        [Required]
        public string Nom {get; set;}
        [Required]
        public string Prenom {get; set;}
        [Required]
        public string Telephone {get; set;}
        [Required]
        public string Email {get; set;}
        [Required]
        public string PhotoProfil {get; set;}
        [Required]
        public string MotDePasse {get; set;}
        [Required]
        public string Profession {get; set;}
        [Required]
        public DateTime DateDeNaissance {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public bool MembreEquipeRSE {get; set;}
        [Required]
        public int Role {get; set;}
    }
}