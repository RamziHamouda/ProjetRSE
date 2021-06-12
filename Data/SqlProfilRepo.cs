using System;
using System.Collections.Generic;
using System.Linq;
using RSEBack.Data;
using RSEBack.Models;

namespace RSEBack.data {
    public class SqlProfilRepo : IProfilRepo
    {
        private readonly RSEContext _context;

        public SqlProfilRepo(RSEContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Projet> GetProjets(Utilisateur utilisateur)
        {
            return _context.Projets.Where(i => i.Impacts.Where(i => i.IdUtilisateur == utilisateur.Id).Any());
        }

        public void UpdateMotDePasse(int IdUtilisateur, string motDePasse)
        {
            Utilisateur utilisateur = _context.Utilisateurs.Where(u => u.Id == IdUtilisateur).First();
            utilisateur.MotDePasse = motDePasse;
        }

        public void UpdateUtilisateur(Utilisateur utilisateur)
        {
            
        }
    }
}