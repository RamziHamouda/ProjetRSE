using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSEBack.Models{
    public class Impact{
        [Key]
        public int IdImpact {get; set;}
        public float Dons {get; set;}
        public float HeureTravail {get; set;}
        public bool Aime {get; set;}    
        public string Commentaire {get; set;}    
        [ForeignKey("Projet")]
        public int IdProjet { get; set; }
        public virtual Projet Projet { get; set; }
        
        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }

    }
}