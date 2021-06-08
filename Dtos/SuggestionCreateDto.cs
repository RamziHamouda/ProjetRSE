using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSEBack.Models{
    public class SuggestionCreateDto {
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