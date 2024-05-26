using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace celloveszetCLI
{
    internal class Program
    {
        static List<Cellovo> cellovolista=new List<Cellovo>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("lovesek (1).csv");
            while (!sr.EndOfStream)
            {
                string sor=sr.ReadLine();
                Cellovo cellovo = new Cellovo(sor);
                cellovolista.Add(cellovo);
            }
            sr.Close();
            Console.WriteLine("9.feladat");
            Console.WriteLine("A játékosok és legnagyobb pontszámaik:");
            int maxloves = 0;
            string maxlovesNev = "";
            int maxloves1= 0;
            int maxloves2= 0;
            int maxloves3= 0;
            int maxloves4= 0;
            foreach(var item in  cellovolista)
            {
                Console.WriteLine(item.nev +" "+item.legnagyobb());
                if(item.legnagyobb()>maxloves)
                {
                    maxloves = item.legnagyobb();
                    maxlovesNev = item.nev;
                    maxloves1 = item.elsoloves;
                    maxloves2=item.masodikloves;
                    maxloves3 = item.harmadikloves;
                    maxloves4 = item.negyedikloves;
                }
            }
                       
            Console.WriteLine("10. feladat");
            Console.WriteLine("A legnagyobb találatot lövő eredményei:");
            Console.WriteLine( maxlovesNev+" "+maxloves1+" "+maxloves2+" "+maxloves3+" "+maxloves4);
            //Console.WriteLine($"{maxlovesNev} {maxloves}");

            Console.WriteLine("11.feladat");
            Console.WriteLine("A leggyengébb átlagú találatot lövő eredménye:");
            string leggyengebb = "";
            double leggyengebbAtlag = 100;
            foreach (var item in cellovolista)
            {
                if (item.atlag() < leggyengebbAtlag)
                {
                    leggyengebbAtlag = item.atlag();
                    leggyengebb = item.nev;
                }
            }
            Console.WriteLine(leggyengebb + " " + leggyengebbAtlag);

            Console.ReadLine();
        }

       
    }
}
