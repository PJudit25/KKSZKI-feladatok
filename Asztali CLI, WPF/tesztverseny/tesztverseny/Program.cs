using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tesztverseny
{
    public class Program
    {
        static string megoldas;
        static void Main(string[] args)
        {
            List<versenyzo> versenyzolista = new List<versenyzo>();
            StreamReader sr = new StreamReader("valaszok.txt");
            string elsosor=sr.ReadLine();
            megoldas = elsosor;
            //Console.WriteLine(  megoldas);
            Console.WriteLine("2. feladat");

            while (!sr.EndOfStream)
            {
                string sor=sr.ReadLine();
                versenyzo v=new versenyzo(sor);
                versenyzolista.Add(v);
                Console.WriteLine("Kód: " + v.kod + " Valaszok: " + v.valaszok);
            }
            sr.Close();
            Console.WriteLine("4.feladat: Telitalálatos versenyző(k) kódja: ");
            foreach (var item in versenyzolista)
            {
                if(f_telitalalat(item.valaszok,megoldas))
                {                
                    Console.WriteLine(item.kod);
                }
            }

            Console.WriteLine("6.feladat");
            foreach(var item in versenyzolista)
            {
                Console.WriteLine(item.kod + " " + f_szazalek(item.valaszok, megoldas)+"%");
            }
            Console.ReadLine();
        }

        public static bool f_telitalalat(string valaszok, string megoldas)
        {
            return valaszok == megoldas;
        }

        public static int f_szazalek(string valaszok, string megoldas)
        {
            int helyesValaszokSzama = 0;
            for (int i = 0; i < megoldas.Length; i++)
            {
                if (valaszok[i] == megoldas[i])
                {
                    helyesValaszokSzama++;
                }
            }
            double szazalek = (double)helyesValaszokSzama / megoldas.Length * 100;
            return (int)Math.Round(szazalek);
        }
    }
}
