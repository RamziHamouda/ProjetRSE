using System.Collections.Generic;
using RSEBack.Models;

namespace RSEBack.Data{
    public interface IUtilisateurRepo{

        bool SaveChanges();
        IEnumerable<Utilisateur> GetAllUtilisateur();
        Utilisateur GetUtilisateurById(int id);
        void CreateUtilisateur(Utilisateur utilisateur);
        void UpdateUtilisateur(Utilisateur utilisateur);
        void DeleteUtilisateur(Utilisateur utilisateur);
    }
}