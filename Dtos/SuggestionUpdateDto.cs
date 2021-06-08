using System;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Models{
    public class SuggestionUpdateDto {
        [Required]
        public string Sujet {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public DateTime DateCreation {get; set;}
        [Required]
        public int IdUtilisateur { get; set; }
    }
}