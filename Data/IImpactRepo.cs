using System.Collections.Generic;
using RSEBack.Models;

namespace RSEBack.Data{
    public interface IImpactRepo{

        bool SaveChanges();
        Impact GetImpactById(int idImpact);
        Impact GetImpact(int idUtilisateur, int idProjet);
        void CreateImpact(Impact Impact);
        void UpdateImpact(Impact Impact);
        void DeleteImpact(Impact Impact);
    }
}