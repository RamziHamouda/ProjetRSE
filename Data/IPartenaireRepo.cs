using System.Collections.Generic;
using RSEBack.Models;

namespace RSEBack.Data{
    public interface IPartenaireRepo{

        bool SaveChanges();
        IEnumerable<Partenaire> GetAllPartenaire();
        Partenaire GetPartenaireById(int id);
        void CreatePartenaire(Partenaire Partenaire);
        void UpdatePartenaire(Partenaire Partenaire);
        void DeletePartenaire(Partenaire Partenaire);
    }
}