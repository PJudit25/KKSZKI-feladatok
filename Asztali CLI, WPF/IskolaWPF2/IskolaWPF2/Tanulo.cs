using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IskolaWPF2
{
    internal class Tanulo
    {
        public int ev { get; private set; }
        public string osztaly { get; private set; }
        public string nev { get; private set; }
        public string vnev { get; private set; }
        public string knev { get; private set; }

        public Tanulo(string sor)
        {
            string[] darabok = sor.Split(';');
            ev = Convert.ToInt32(darabok[0]);
            osztaly = darabok[1];
            nev = darabok[2];
            string[] nevdarabok = darabok[2].Split(' ');
            vnev = nevdarabok[0];
            knev = nevdarabok[1];
        }

        public string Azonosito()
        {
            int evUtolsoSzamjegy = ev % 10;
            return evUtolsoSzamjegy + osztaly + vnev.Substring(0, 3).ToLower() + knev.Substring(0, 3).ToLower();
        }

        public override string ToString()
        {
            return ev+";"+osztaly+";"+nev;
        }

    }
}
