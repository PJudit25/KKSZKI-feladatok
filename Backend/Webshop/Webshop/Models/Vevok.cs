using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webshop.Models
{
    public partial class Vevok
    {
        public Vevok()
        {
            Szamlafejs = new HashSet<Szamlafej>();
        }

        public int Id { get; set; }
        public string Nev { get; set; } = null!;
        public string Iranyitoszam { get; set; } = null!;
        public string Telepules { get; set; } = null!;
        public string Utcahazszam { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Szamlafej> Szamlafejs { get; set; }
    }
}
