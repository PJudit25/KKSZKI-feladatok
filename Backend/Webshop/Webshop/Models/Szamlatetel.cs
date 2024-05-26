using System;
using System.Collections.Generic;

namespace Webshop.Models
{
    public partial class Szamlatetel
    {
        public int Id { get; set; }
        public int Szamlafejid { get; set; }
        public int Termekid { get; set; }
        public int Mennyiseg { get; set; }
        public string Mennyisegiegyseg { get; set; } = null!;
        public float Bruttoegysegar { get; set; }
        public int Afaszazalek { get; set; }

        public virtual Szamlafej Szamlafej { get; set; } = null!;
        public virtual Termekek Termek { get; set; } = null!;
    }
}
