using System.ComponentModel.DataAnnotations;

namespace RSEBack.Dtos{
    public class ImpactCreateDto{
        [Required]
        public float Dons {get; set;}
        [Required]
        public float HeureTravail {get; set;}
        [Required]
        public string Commentaire {get; set;}
        [Required]
        public int IdProjet { get; set; }
        [Required]
        public int IdUtilisateur { get; set; }    
    }
}