using System;
using System.Collections.Generic;
using System.Linq;
using RSEBack.Data;
using RSEBack.Models;

namespace RSEBack.data {
    public class SqlSuggestionRepo : ISuggestionRepo
    {
        private readonly RSEContext _context;

        public SqlSuggestionRepo(RSEContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Suggestion GetSuggestionById(int id)
        {
            return _context.Suggestions.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Suggestion> GetAllSuggestion(int idUtilisateur)
        {
            Utilisateur utilisateur = _context.Utilisateurs.FirstOrDefault(p => p.Id == idUtilisateur);
            if(utilisateur == null){
                throw new ArgumentNullException(nameof(utilisateur));
            }
            if(utilisateur.Role == 1) //admin
                return _context.Suggestions.ToList(); // Si admin, on retourne tous les suggestions
            else
                return utilisateur.Suggestions.ToList(); // on retourne que les suggestions de l'employé
        }

        public void CreateSuggestion(Suggestion Suggestion)
        {
            if(Suggestion == null){
                throw new ArgumentNullException(nameof(Suggestion));
            }
            Suggestion.DateCreation = DateTime.Now;
            _context.Suggestions.Add(Suggestion);
        }

        public void DeleteSuggestion(Suggestion Suggestion)
        {
            if(Suggestion == null){
                throw new ArgumentNullException(nameof(Suggestion));
            }
            _context.Suggestions.Remove(Suggestion);
        }
    }
}