using System.Collections.Generic;
using RSEBack.Models;

namespace RSEBack.Data{
    public interface ISuggestionRepo{

        bool SaveChanges();
        IEnumerable<Suggestion> GetAllSuggestion();
        Suggestion GetSuggestionById(int id);
        void CreateSuggestion(Suggestion Suggestion);
        void UpdateSuggestion(Suggestion Suggestion);
        void DeleteSuggestion(Suggestion Suggestion);
    }
}