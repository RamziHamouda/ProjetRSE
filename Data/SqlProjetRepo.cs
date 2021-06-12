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

        // Mise à jour du champs 'aime' de la table Projets
        public void UpdateAimeProjet(Projet projet, Utilisateur utilisateur)
        {
            Impact impact = utilisateur.Impacts.Where(I => I.IdProjet == projet.Id).FirstOrDefault();
            if(impact != null)
            {
                impact.Aime = !impact.Aime;  //on l'initialise avec la valeur opposée
                if(impact.Aime == false && impact.Dons == 0 && impact.HeureTravail == 0)
                    _context.Impacts.Remove(impact);
            }
            else {
                Impact impact1 = new Impact(){ Aime = true };
                impact1.IdUtilisateur = utilisateur.Id;
                impact1.IdProjet = projet.Id;
                _context.Impacts.Add(impact1);
            }
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