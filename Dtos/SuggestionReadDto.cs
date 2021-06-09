using System;

namespace RSEBack.Dtos{
    public class SuggestionReadDto {
        public int Id {get; set;}
        public string Sujet {get; set;}
        public string Description {get; set;}
        public DateTime DateCreation {get; set;}
    }
}