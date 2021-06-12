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

        public Impact GetImpactById(int idImpact)
        {
            return _context.Impacts.FirstOrDefault(p => p.IdImpact == idImpact);
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
            // On vérifie si l'impact existe déja dans la base
            Impact impactBase = _context.Impacts.FirstOrDefault(i => i.IdProjet == Impact.IdProjet && i.IdUtilisateur == Impact.IdUtilisateur);
            if(impactBase == null)
            {
                _context.Impacts.Add(Impact);
            }
            else {
                impactBase.Dons = Impact.Dons;
                impactBase.Commentaire = Impact.Commentaire;
                impactBase.HeureTravail = Impact.HeureTravail;
                Impact = impactBase;
            }
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