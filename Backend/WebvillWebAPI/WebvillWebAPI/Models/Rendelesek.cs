using System;
using System.Collections.Generic;

namespace WebvillWebAPI.Models
{
    public partial class Rendelesek
    {
        public int Razon { get; set; }
        public DateTime Rdatum { get; set; }
        public int Tazon { get; set; }
        public int Db { get; set; }

        public virtual Termekek TazonNavigation { get; set; } = null!;
    }
}
