using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSEBack.Dtos{
    public class ImpactReadDto{
        public int IdImpact {get; set;}
        public float Dons {get; set;}
        public float HeureTravail {get; set;}
        public bool Aime {get; set;}    
        public string Commentaire {get; set;}    
        public int IdProjet { get; set; }
        public int IdUtilisateur { get; set; }
    }
}