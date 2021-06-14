using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Models{
    public class UtilisateurMdpReadDto { // pour la mise à jour de mot de passe uniquement
        public string Email {get; set;}
        public string MotDePasse {get; set;}
    }
}