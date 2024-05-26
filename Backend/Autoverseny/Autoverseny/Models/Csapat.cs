using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Autoverseny.Models
{
    public partial class Csapat
    {
        public Csapat()
        {
            Versenyzos = new HashSet<Versenyzo>();
        }

        public int Id { get; set; }
        public string Nev { get; set; } = null!;
        public int Alapitva { get; set; }
        [JsonIgnore]
        public virtual ICollection<Versenyzo> Versenyzos { get; set; }
    }
}
