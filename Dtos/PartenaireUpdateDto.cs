using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Dtos{
    public class PartenaireUpdateDto {
        [Required]
        public string Nom {get; set;}
        [Required]
        public string Logo {get; set;}
    }
}