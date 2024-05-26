using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celloveszetCLI
{
    public class Cellovo
    {
        public string nev { get; private set; }
        public int elsoloves { get; private set; }
        public int masodikloves { get; private set; }
        public int harmadikloves { get; private set; }
        public int negyedikloves { get; private set; }

        public Cellovo(string sor)
        {
            string[] darabok = sor.Split(';');
            nev = darabok[0];
            elsoloves = Convert.ToInt32(darabok[1]);
            masodikloves = Convert.ToInt32(darabok[2]);
            harmadikloves = Convert.ToInt32(darabok[3]);
            negyedikloves = Convert.ToInt32(darabok[4]);

        }

        public int legnagyobb()
        {
            return Math.Max(Math.Max(elsoloves, masodikloves), Math.Max(harmadikloves, negyedikloves));

        }
       
        public double atlag()
        {
            return ((elsoloves + masodikloves + harmadikloves + negyedikloves) / 4);
        }
    }
}
