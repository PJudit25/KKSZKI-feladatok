using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haromszogekWPF
{
    class haromszog
    {
        public int a { get; private set; }
        public int b { get; private set; }
        public int c { get; private set; }

        public haromszog(string sor)
        {
            string[] darabok = sor.Split(' ');
            this.a = Convert.ToInt32(darabok[0]);
            this.b = Convert.ToInt32(darabok[1]);
            this.c = Convert.ToInt32(darabok[2]);
        }

        public haromszog(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
}
