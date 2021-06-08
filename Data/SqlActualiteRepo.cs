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
            actualite.DateCreation = DateTime.Now;
            _context.Actualites.Add(actualite);
        }

        public void UpdateActualite(Actualite actualite)
        {
            actualite.DateCreation = DateTime.Now;
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