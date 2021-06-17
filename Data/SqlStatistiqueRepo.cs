using System;
using System.Collections.Generic;
using System.Linq;
using RSEBack.Data;
using RSEBack.Dtos;
using RSEBack.Models;

namespace RSEBack.data {
    public class SqlStatistiqueRepo : IStatistiqueRepo
    {
        private readonly RSEContext _context;

        public SqlStatistiqueRepo(RSEContext context)
        {
            _context = context;
        }

        public StatistiqueComptage GetStatistiqueComptage()
        {
            StatistiqueComptage statistiqueComptage = new StatistiqueComptage(){
                NombreEmployes = _context.Utilisateurs.Count(),
                NombreProjets = _context.Projets.Count(),
                NombrePartenaires = _context.Partenaires.Count(),
                NombreSuggesstions = _context.Suggestions.Count()
            };
            return statistiqueComptage;
        }

        public StatistiquePourcentageImpact GetStatistiquePourcentageImpact()
        {
            int NombreImpactParUtilisateur = _context.Impacts.Select(i => i.IdUtilisateur).Distinct().Count();
            int NombreUtilisateurs = _context.Utilisateurs.Count();
            StatistiquePourcentageImpact statistiquePourcentageImpact = new StatistiquePourcentageImpact(){
                NombreUtilisateurs = NombreUtilisateurs - NombreImpactParUtilisateur,
                NombreImpactParUtilisateur = NombreImpactParUtilisateur
            };
            return statistiquePourcentageImpact;
        }

        public List<StatistiqueContribution> GetStatistiqueContribution()
        {
            List<StatistiqueContribution> statistiqueContributions = new List<StatistiqueContribution>();
            foreach(Projet projet in _context.Projets){
                statistiqueContributions.Add(new StatistiqueContribution{
                    TitreProjet = projet.Titre,
                    Contribution = projet.Impacts.Count()
                });
            }
            return statistiqueContributions;
        }

        public IEnumerable<StatistiqueCategorie> GetStatistiqueCategorie()
        {
            List<StatistiqueCategorie> statistiqueCategorie = new List<StatistiqueCategorie>();
            Dictionary<string, int> ListCategorie = new Dictionary<string, int>();
            foreach(Projet projet in _context.Projets){
                if(ListCategorie.Any(l => l.Key == projet.Categorie)){
                    ListCategorie[projet.Categorie] += 1;
                }
                else{
                    if(!string.IsNullOrEmpty(projet.Categorie)) ListCategorie[projet.Categorie] = 1;
                }
            }

            foreach(var couple in ListCategorie){
                statistiqueCategorie.Add(new StatistiqueCategorie{ Cateogire = couple.Key, nbrProjets = couple.Value});
            }
            return statistiqueCategorie;
        }
    }
}
