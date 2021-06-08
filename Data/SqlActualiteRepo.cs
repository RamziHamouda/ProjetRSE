using System;
using System.Collections.Generic;
using System.Linq;
using RSEBack.Data;
using RSEBack.Models;

namespace RSEBack.data {
    public class SqlActualiteRepo : IActualiteRepo
    {
        private readonly RSEContext _context;

        public SqlActualiteRepo(RSEContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Actualite> GetAllActualite()
        {
            return _context.Actualites.ToList();
        }

        public Actualite GetActualiteById(int id)
        {
            return _context.Actualites.FirstOrDefault(p => p.Id == id);
        }

        public void CreateActualite(Actualite actualite)
        {
            if(actualite == null){
                throw new ArgumentNullException(nameof(actualite));
            }
            _context.Actualites.Add(actualite);
        }

        public void UpdateActualite(Actualite actualite)
        {
            Actualite actualiteItem = _context.Actualites.Where(p => p.Id == actualite.Id).FirstOrDefault();
            actualiteItem.Titre = actualite.Titre;
            actualiteItem.Image = actualite.Image;
            actualiteItem.DateCreation = actualite.DateCreation;
            actualiteItem.Description = actualite.Description;
        }

        public void DeleteActualite(Actualite actualite)
        {
            if(actualite == null){
                throw new ArgumentNullException(nameof(actualite));
            }
            _context.Actualites.Remove(actualite);
        }
    }
}