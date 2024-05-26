using System;
using System.Collections.Generic;

namespace WebvillWebAPI.Models
{
    public partial class Kategoriak
    {
        public Kategoriak()
        {
            Termekeks = new HashSet<Termekek>();
        }

        public int Kazon { get; set; }
        public string Knev { get; set; } = null!;

        public virtual ICollection<Termekek> Termekeks { get; set; }
    }
}
