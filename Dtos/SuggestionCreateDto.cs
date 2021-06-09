using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSEBack.Dtos{
    public class SuggestionCreateDto {
        [Required]
        public string Sujet {get; set;}
        [Required]
        public string Description {get; set;}
    }
}