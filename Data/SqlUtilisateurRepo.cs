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

        public IEnumerable<Utilisateur> GetAllUtilisateur()
        {
            return _context.Utilisateurs.ToList();
        }

        public Utilisateur GetUtilisateurById(int id)
        {
            return _context.Utilisateurs.FirstOrDefault(p => p.Id == id);
        }

        public void CreateUtilisateur(Utilisateur Utilisateur)
        {
            if(Utilisateur == null){
                throw new ArgumentNullException(nameof(Utilisateur));
            }
            _context.Utilisateurs.Add(Utilisateur);
        }

        public void UpdateUtilisateur(Utilisateur Utilisateur)
        {
            
        }

        public void DeleteUtilisateur(Utilisateur Utilisateur)
        {
            if(Utilisateur == null){
                throw new ArgumentNullException(nameof(Utilisateur));
            }
            _context.Utilisateurs.Remove(Utilisateur);
        }
    }
}