using System;

namespace RSEBack.Dtos{
    public class UtilisateurReadDto{
        public int Id {get;set;}
        public string Nom {get; set;}
        public string Prenom {get; set;}
        public string Telephone {get; set;}
        public string Email {get; set;}
        public string PhotoProfil {get; set;}
        public string Profession {get; set;}
        public DateTime DateNaissance {get; set;}
        public string Description {get; set;}
        public bool MembreEquipeRSE {get; set;}
        public int Role {get; set;}
    }
}