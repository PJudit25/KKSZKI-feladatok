using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tesztverseny
{
    internal class versenyzo
    {
        public string kod { get; set; }
        public string valaszok { get; set; }

        public versenyzo(string sor)
        {
            string[] darabok = sor.Split(' ');
            this.kod = darabok[0];
            this.valaszok = darabok[1];

        }

    }
}
