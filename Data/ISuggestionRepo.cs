using System.Collections.Generic;
using RSEBack.Models;

namespace RSEBack.Data{
    public interface ISuggestionRepo{

        bool SaveChanges();
        IEnumerable<Suggestion> GetAllSuggestion(int idUtilisateur);
        Suggestion GetSuggestionById(int id);
        void CreateSuggestion(Suggestion Suggestion);
        void DeleteSuggestion(Suggestion Suggestion);
    }
}