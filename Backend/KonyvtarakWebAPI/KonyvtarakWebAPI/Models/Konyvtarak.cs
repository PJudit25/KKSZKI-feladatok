using System;
using System.Collections.Generic;

namespace KonyvtarakWebAPI.Models
{
    public partial class Konyvtarak
    {
        public int Id { get; set; }
        public string KonyvtarNev { get; set; } = null!;
        public string Irsz { get; set; } = null!;
        public string Cim { get; set; } = null!;

        public virtual Telepulesek IrszNavigation { get; set; } = null!;
    }
}
