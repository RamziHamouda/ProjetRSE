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

        public IEnumerable<Suggestion> GetAllSuggestion()
        {
            return _context.Suggestions.ToList();
        }

        public Suggestion GetSuggestionById(int id)
        {
            return _context.Suggestions.FirstOrDefault(p => p.Id == id);
        }

        public void CreateSuggestion(Suggestion Suggestion)
        {
            if(Suggestion == null){
                throw new ArgumentNullException(nameof(Suggestion));
            }
            _context.Suggestions.Add(Suggestion);
        }

        public void UpdateSuggestion(Suggestion Suggestion)
        {
            
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