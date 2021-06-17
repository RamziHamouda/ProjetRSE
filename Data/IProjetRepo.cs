using System.Collections.Generic;
using RSEBack.Models;


namespace RSEBack.Data{
    public interface IProjetRepo{

        bool SaveChanges();
        IEnumerable<Projet> GetAllProjet();
        IEnumerable<Projet> GetProjetParCategorie(string categorie);
        Projet GetProjetById(int idProjet);
        void CreateProjet(Projet Projet);
        void UpdateProjet(Projet Projet);
        void UpdateVuesProjet(Projet projet);
        void DeleteProjet(Projet Projet);
    }
}
