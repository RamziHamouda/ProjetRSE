using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSEBack.Models{
    public partial class Projet{
        public int NombreImpact{
            get{
                return this.Impacts.Count;
            }
        }

    }
}