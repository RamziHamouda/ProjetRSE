using System;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Dtos{
    public class LogInUpdateDto{
        [Required]
        public int id {get; set;}
        [Required]
        public string email {get; set;}
        [Required]
        public string motDePasse {get; set;}
    }
}