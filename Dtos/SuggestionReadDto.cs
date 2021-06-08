using System;

namespace RSEBack.Models{
    public class SuggestionReadDto {
        public int Id {get; set;}
        public string Sujet {get; set;}
        public string Description {get; set;}
        public DateTime DateCreation {get; set;}
        public int IdUtilisateur { get; set; }
    }
}