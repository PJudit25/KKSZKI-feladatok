using System;
using System.Collections.Generic;

namespace KonyvtarakWebAPI.Models
{
    public partial class Megyek
    {
        public Megyek()
        {
            Telepuleseks = new HashSet<Telepulesek>();
        }

        public int Id { get; set; }
        public string MegyeNev { get; set; } = null!;

        public virtual ICollection<Telepulesek> Telepuleseks { get; set; }
    }
}
