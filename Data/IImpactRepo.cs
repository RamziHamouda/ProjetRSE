using System.Collections.Generic;
using RSEBack.Models;

namespace RSEBack.Data{
    public interface IImpactRepo{

        bool SaveChanges();
        Impact GetImpactById(int idImpact);
        IEnumerable<Impact> GetImpact(Utilisateur utilisateur, Projet projet);
        void CreateImpact(ref Impact Impact);
        void UpdateImpact(Impact Impact);
        void DeleteImpact(Impact Impact);
    }
}