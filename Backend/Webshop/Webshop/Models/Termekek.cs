using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webshop.Models
{
    public partial class Termekek
    {
        public Termekek()
        {
            Szamlatetels = new HashSet<Szamlatetel>();
        }

        public int Id { get; set; }
        public string Megnevezes { get; set; } = null!;
        public float Ar { get; set; }

        [JsonIgnore]
        public virtual ICollection<Szamlatetel> Szamlatetels { get; set; }
    }
}
