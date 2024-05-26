using System;
using System.Collections.Generic;

namespace Autoverseny.Models
{
    public partial class Korido
    {
        public int Id { get; set; }
        public int Palyaid { get; set; }
        public int Versenyzoid { get; set; }
        public TimeSpan Korido1 { get; set; }
        public int Kor { get; set; }

        public virtual Palya Palya { get; set; } = null!;
        public virtual Versenyzo Versenyzo { get; set; } = null!;
    }
}
