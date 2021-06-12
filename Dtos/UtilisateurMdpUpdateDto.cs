using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Models{
    public class UtilisateurMdpUpdateDto { // pour la mise à jour de mot de passe uniquement
        [Required]
        public int Id {get;set;}
        [Required]
        public string Email {get; set;}
        [Required]
        public string MotDePasse {get; set;}
    }
}