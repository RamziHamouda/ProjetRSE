using System;
using System.Collections.Generic;
using System.Linq;
using RSEBack.Data;
using RSEBack.Models;

namespace RSEBack.data {
    public class SqlProjetRepo : IProjetRepo
    {
        private readonly RSEContext _context;

        public SqlProjetRepo(RSEContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Projet> GetAllProjet()
        {
            return _context.Projets.ToList();
        }

        public Projet GetProjetById(int idProjet)
        {
            return _context.Projets.FirstOrDefault(p => p.Id == idProjet);
        }

        public IEnumerable<Projet> GetProjetParCategorie(string categorie)
        {
            return _context.Projets.Where(p => p.Categorie.Equals(categorie));
        }

        public void CreateProjet(Projet Projet)
        {
            if(Projet == null){
                throw new ArgumentNullException(nameof(Projet));
            }
            Projet.DateCreation = DateTime.Now;
            _context.Projets.Add(Projet);
        }

        public void UpdateProjet(Projet Projet)
        {
            Projet.DateCreation = DateTime.Now;
        }

        // Ajouter + 1 aux nombres de vues d'un projet
        public void UpdateVuesProjet(Projet projet)
        {
            projet.NombreDeVues += 1;
        }

        public void DeleteProjet(Projet Projet)
        {
            if(Projet == null){
                throw new ArgumentNullException(nameof(Projet));
            }
            _context.Projets.Remove(Projet);
        }
    }
}