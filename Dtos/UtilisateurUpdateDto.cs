using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Models{
    public class UtilisateurUpdateDto{
        [Required]
        public int Id {get;set;}
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
        public string Profession {get; set;}
        [Required]
        public DateTime DateNaissance {get; set;}
        [Required]
        public string Description {get; set;}
    }
}