using System;
using System.Collections.Generic;
using System.Linq;
using RSEBack.Data;
using RSEBack.Models;

namespace RSEBack.data {
    public class SqlPartenaireRepo : IPartenaireRepo
    {
        private readonly RSEContext _context;

        public SqlPartenaireRepo(RSEContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Partenaire> GetAllPartenaire()
        {
            return _context.Partenaires.ToList();
        }

        public Partenaire GetPartenaireById(int id)
        {
            return _context.Partenaires.FirstOrDefault(p => p.Id == id);
        }

        public bool IsExistListePartenaires(List<int> IDPartenaires){
            if( IDPartenaires.Except(_context.Partenaires.Select(e => e.Id)).Any())
                return false;
            return true;
        }

        public void CreatePartenaire(Partenaire Partenaire)
        {
            if(Partenaire == null){
                throw new ArgumentNullException(nameof(Partenaire));
            }
            Partenaire.DateCreation = DateTime.Now;
            _context.Partenaires.Add(Partenaire);
        }

        public void UpdatePartenaire(Partenaire Partenaire)
        {
            Partenaire.DateCreation = DateTime.Now;
        }

        public void DeletePartenaire(Partenaire Partenaire)
        {
            if(Partenaire == null){
                throw new ArgumentNullException(nameof(Partenaire));
            }
            _context.Partenaires.Remove(Partenaire);
        }
    }
}