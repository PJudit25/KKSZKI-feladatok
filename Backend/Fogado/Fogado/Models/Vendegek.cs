using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Fogado.Models
{
    public partial class Vendegek
    {
        public Vendegek()
        {
            Foglalasoks = new HashSet<Foglalasok>();
        }

        public int Vsorsz { get; set; }
        public string Vnev { get; set; } = null!;
        public int Irsz { get; set; }
        [JsonIgnore]
        public virtual ICollection<Foglalasok> Foglalasoks { get; set; }
    }
}
