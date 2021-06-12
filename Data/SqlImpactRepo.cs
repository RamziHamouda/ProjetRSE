using System;
using System.Collections.Generic;
using System.Linq;
using RSEBack.Data;
using RSEBack.Models;

namespace RSEBack.data {
    public class SqlImpactRepo : IImpactRepo
    {
        private readonly RSEContext _context;

        public SqlImpactRepo(RSEContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Impact GetImpact(int idUtilisateur, int idProjet)
        {
            return _context.Impacts.FirstOrDefault(p => p.IdUtilisateur == idUtilisateur && p.IdProjet == idProjet);
        }

        public void CreateImpact(Impact Impact)
        {
            if(Impact == null){
                throw new ArgumentNullException(nameof(Impact));
            }
            _context.Impacts.Add(Impact);
        }

        public void UpdateImpact(Impact Impact)
        {
            
        }

        public void DeleteImpact(Impact Impact)
        {
            if(Impact == null){
                throw new ArgumentNullException(nameof(Impact));
            }
            _context.Impacts.Remove(Impact);
        }
    }
}