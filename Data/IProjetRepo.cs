using System.Collections.Generic;
using RSEBack.Models;


namespace RSEBack.Data{
    public interface IProjetRepo{

        bool SaveChanges();
        IEnumerable<Projet> GetAllProjet();
        Projet GetProjetById(int idProjet);
        void CreateProjet(Projet Projet);
        void UpdateProjet(Projet Projet);
        void UpdateAimeProjet(Projet projet, int idUtilisateur);
        void UpdateVuesProjet(Projet projet);
        void DeleteProjet(Projet Projet);
    }
}
