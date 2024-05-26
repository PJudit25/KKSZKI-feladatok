using System;
using System.Collections.Generic;

namespace WebvillWebAPI.Models
{
    public partial class Termekek
    {
        public Termekek()
        {
            Rendeleseks = new HashSet<Rendelesek>();
        }

        public int Tazon { get; set; }
        public int Kazon { get; set; }
        public string Tnev { get; set; } = null!;
        public string Fesz { get; set; } = null!;
        public double Telj { get; set; }
        public string Foglalat { get; set; } = null!;
        public int Elettartam { get; set; }
        public int Ar { get; set; }

        public virtual Kategoriak KazonNavigation { get; set; } = null!;
        public virtual ICollection<Rendelesek> Rendeleseks { get; set; }
    }
}
