using System.Collections.Generic;
using RSEBack.Models;

namespace RSEBack.Data{
    public interface IUtilisateurRepo{

        bool SaveChanges();
        IEnumerable<Utilisateur> GetAllUtilisateur();
        Utilisateur GetUtilisateur(string Email, string Mdp);
        Utilisateur GetUtilisateurById(int id);
        void UpdateUtilisateur(Utilisateur utilisateur);
        IEnumerable<Utilisateur> GetAllUtilisateurEquipeRSE();
    }
}