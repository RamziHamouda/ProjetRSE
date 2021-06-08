using System.Collections.Generic;
using RSEBack.Models;

namespace RSEBack.Data{
    public interface IActualiteRepo{

        bool SaveChanges();
        IEnumerable<Actualite> GetAllActualite();
        Actualite GetActualiteById(int id);
        void CreateActualite(Actualite actualite);
        void UpdateActualite(Actualite actualite);
        void DeleteActualite(Actualite actualite);
    }
}