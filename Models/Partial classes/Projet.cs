using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RSEBack.Models{
    public partial class Projet{
        [NotMapped] // to tell entity framework that this field is not in the database
        private int _NombreImpact;
        [NotMapped]
        public int NombreImpact{
            get{
                if(this.Impacts != null){
                _NombreImpact = this.Impacts.Count;
                return _NombreImpact;
                }
                else{
                    _NombreImpact = 0;
                    return _NombreImpact;
                }
            }
            set{
                _NombreImpact = value;
            }
        }
        [NotMapped]
        private List<int> _Partenaires;
        [NotMapped]
        public List<int> Partenaires{
            get{
                _Partenaires = this.PartenaireProjet.Select(pp => pp.IdPartenaire).ToList();
                return _Partenaires;
            }
            set{
                _Partenaires = value;
            }
        }

    }
}