using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola2
{
    internal class Program
    {
        static List<tanulo> tanulolista=new List<tanulo>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("nevek (1).txt");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                tanulo t=new tanulo(sor);
                tanulolista.Add(t);
            }
            sr.Close();
            int tanulokszama =0;
            foreach(var item in tanulolista)
            {
            Console.WriteLine(item.ev+" "+item.osztaly + " " +item.nev);
            tanulokszama++;
            }
            Console.WriteLine("Tanulók száma: "+tanulokszama);

            var elsoAzonosito = tanulolista[0].Azonosito();
            var utolsoAzonosito = tanulolista[tanulolista.Count-1].Azonosito();
            Console.WriteLine(elsoAzonosito);
            Console.WriteLine(utolsoAzonosito);

            StreamWriter sw = new StreamWriter("azonositok.txt");
            foreach (var item in tanulolista)
            {
                sw.WriteLine(item.nev+" "+item.Azonosito());
            }
            Console.WriteLine("Azonosítók kiírva az azonositok.txt fájlba.");

            Console.ReadLine();

        }

    }
}
