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

        public IEnumerable<Impact> GetImpact(Utilisateur utilisateur, Projet projet)
        {
            if(utilisateur.Role == 0) // si admin, on retourne tous le actualités
                return _context.Impacts;
            else
                return _context.Impacts.Where(p => p.IdUtilisateur == utilisateur.Id && p.IdProjet == projet.Id);
        }

        public void CreateImpact(ref Impact Impact)
        {
            if(Impact == null){
                throw new ArgumentNullException(nameof(Impact));
            }
            // On vérifie si l'impact existe déja dans la base
            int idProjet = Impact.IdProjet;
            int idUtilisateur = Impact.IdUtilisateur;
            Impact impactBase = _context.Impacts.FirstOrDefault(i => i.IdProjet == idProjet && i.IdUtilisateur == idUtilisateur);
            if(impactBase == null)
            {
                if(ImpactEstValide(Impact)){
                    _context.Impacts.Add(Impact);
                }
            }
            else {
                if(ImpactEstValide(Impact)){
                    impactBase.Dons = Impact.Dons;
                    impactBase.Commentaire = Impact.Commentaire;
                    impactBase.HeureTravail = Impact.HeureTravail;
                    impactBase.Aime = Impact.Aime;
                    Impact = impactBase; 
                }
                else{
                    _context.Impacts.Remove(impactBase); // L'objet ne contient pas des infos, donc on le supprime
                }
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

        private bool ImpactEstValide(Impact Impact){
            return Impact.Aime || !string.IsNullOrEmpty(Impact.Commentaire) || Impact.Dons != 0 || Impact.HeureTravail != 0;
        }
    }
}