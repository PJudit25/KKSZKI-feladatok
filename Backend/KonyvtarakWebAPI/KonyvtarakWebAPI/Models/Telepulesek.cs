using System;
using System.Collections.Generic;

namespace KonyvtarakWebAPI.Models
{
    public partial class Telepulesek
    {
        public Telepulesek()
        {
            Konyvtaraks = new HashSet<Konyvtarak>();
        }

        public string Irsz { get; set; } = null!;
        public string TelepNev { get; set; } = null!;
        public int MegyeId { get; set; }

        public virtual Megyek Megye { get; set; } = null!;
        public virtual ICollection<Konyvtarak> Konyvtaraks { get; set; }
    }
}
