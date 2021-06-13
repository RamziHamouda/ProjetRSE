using System.Collections.Generic;
using RSEBack.Dtos;
using RSEBack.Models;

namespace RSEBack.Data{
    public interface IProfilRepo{

        bool SaveChanges();
        IEnumerable<Projet> GetProjets(Utilisateur utilisateur);
        ProfilStatistique GetStatistique(Utilisateur utilisateur);
        void UpdateMotDePasse(int IdUtilisateur, string motDePasse);
        void UpdateUtilisateur(Utilisateur utilisateur);
    }
}