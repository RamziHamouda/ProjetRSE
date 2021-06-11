using System;
using System.Collections.Generic;
using System.Linq;
using RSEBack.Data;
using RSEBack.Models;

namespace RSEBack.data {
    public class SqlUtilisateurRepo : IUtilisateurRepo
    {
        private readonly RSEContext _context;

        public SqlUtilisateurRepo(RSEContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Utilisateur GetUtilisateurById(int id)
        {
            return _context.Utilisateurs.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Utilisateur> GetAllUtilisateur()
        {
            return _context.Utilisateurs.ToList(); //liste des employés
        }

        public IEnumerable<Utilisateur> GetAllUtilisateurEquipeRSE()
        {
            return _context.Utilisateurs.Where(p => p.MembreEquipeRSE == true).ToList(); // Les membres de l'équipe RSE
        }

        public void UpdateUtilisateur(Utilisateur Utilisateur)
        {
            if(Utilisateur.MembreEquipeRSE == true) Utilisateur.MembreEquipeRSE = false;
            else Utilisateur.MembreEquipeRSE = true;
        }
    }
}