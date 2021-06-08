using System;

namespace RSEBack.Models{
    public class ActualiteReadDto {
        public int Id {get;set;}
        public string Titre {get; set;}
        public string Description {get; set;}
        public string Image {get; set;}
        public DateTime DateCreation {get; set;}
    }
}