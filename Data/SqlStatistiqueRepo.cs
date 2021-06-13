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
            int NombreImpact = _context.Impacts.Count();
            int NombreUtilisateurs = _context.Utilisateurs.Count();
            StatistiquePourcentageImpact statistiquePourcentageImpact = new StatistiquePourcentageImpact(){
                NombreUtilisateurs = NombreUtilisateurs,
                NombreImpactParUtilisateur = NombreImpact / NombreUtilisateurs
            };
            return statistiquePourcentageImpact;
        }

        public IEnumerable<StatistiqueContribution> GetStatistiqueContribution()
        {
            IEnumerable<StatistiqueContribution> statistiqueContributions = new List<StatistiqueContribution>();
            foreach(Projet projet in _context.Projets){
                statistiqueContributions.Append(new StatistiqueContribution{
                    TitreProjet = projet.Titre,
                    Contribution = projet.Impacts.Count()
                });
            }
            return statistiqueContributions;
        }
    }
}
