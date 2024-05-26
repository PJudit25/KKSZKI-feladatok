using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Autoverseny.Models
{
    public partial class Palya
    {
        public Palya()
        {
            Koridos = new HashSet<Korido>();
        }

        public int Id { get; set; }
        public string Nev { get; set; } = null!;
        public double Hossz { get; set; }
        public string Orszag { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Korido> Koridos { get; set; }
    }
}
