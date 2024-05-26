using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Autoverseny.Models
{
    public partial class Versenyzo
    {
        public Versenyzo()
        {
            Koridos = new HashSet<Korido>();
        }

        public int Id { get; set; }
        public string Nev { get; set; } = null!;
        public int Eletkor { get; set; }
        public int Csapatid { get; set; }

        public virtual Csapat Csapat { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Korido> Koridos { get; set; }
    }
}
