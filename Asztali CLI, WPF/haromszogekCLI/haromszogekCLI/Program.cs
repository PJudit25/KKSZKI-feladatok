using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haromszogekCLI
{
    public class Program
    {
        static List<haromszog>haromszogeklista=new List<haromszog>();

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("haromszogek2.csv");
            while (!sr.EndOfStream)
            {
                string sor=sr.ReadLine();
                haromszog h=new haromszog(sor);
                haromszogeklista.Add(h);
            }
            sr.Close();

            int maxterulet = 0;
            haromszog maxTeruletuHaromszog = null;

            Console.WriteLine( "Derékszögű háromszögek adatai:" );
            foreach (var item in  haromszogeklista)
            {
                if (derekszogu(item.a, item.b, item.c))
                {
                    Console.WriteLine("a: " + item.a + " b: " + item.b + " c: " + item.c);
                    int terulet = (item.a * item.b)/ 2;
                    if (terulet > maxterulet ) 
                    {
                      maxterulet=terulet;
                        maxTeruletuHaromszog=item;
                    }
                }
            }
            Console.WriteLine("A legnagyobb területű derékszögű háromszög adatai:");
            Console.WriteLine("a: " + maxTeruletuHaromszog.a + " b: " + maxTeruletuHaromszog.b + " c: " + maxTeruletuHaromszog.c);

            Console.ReadLine();

        }

        public static bool derekszogu(int a,int b, int c)
        {
            if (a * a + b * b == c * c)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
