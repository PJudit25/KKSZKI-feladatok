using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webshop.Models
{
    public partial class Szamlafej
    {
        public Szamlafej()
        {
            Szamlatetels = new HashSet<Szamlatetel>();
        }

        public int Id { get; set; }
        public string Szamlaszam { get; set; } = null!;
        public DateTime Kelt { get; set; }
        public DateTime Teljesites { get; set; }
        public int Vevoid { get; set; }

        public virtual Vevok Vevo { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Szamlatetel> Szamlatetels { get; set; }
    }
}
