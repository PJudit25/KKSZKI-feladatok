using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Fogado.Models
{
    public partial class Szobak
    {
        public Szobak()
        {
            Foglalasoks = new HashSet<Foglalasok>();
        }

        public int Szazon { get; set; }
        public string Sznev { get; set; } = null!;
        public int Agy { get; set; }
        public int Potagy { get; set; }
        [JsonIgnore] 
        public virtual ICollection<Foglalasok> Foglalasoks { get; set; }
    }
}
