using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using AdopceZvirat;

namespace Program
{


    public class Program
    {
        static void Main(string[] args)
        {
            Zvire pes = new Zvire("Rusty", "pes", 3);
            Zvire krecek = new Zvire("Eduard", "křeček", 1);
            Zvire kocka = new Zvire("Lea", "kočka", 4);


            Adoptujici jan = new Adoptujici("Jan Novák");

            Utulek utulek = new Utulek();

            utulek.Zvirata.Add(pes);
            utulek.Zvirata.Add(krecek);
            utulek.Zvirata.Add(kocka);






            Console.WriteLine("Seznam zvířat k adopci:");
            utulek.VypisDostupnaZvirata();
            Console.WriteLine();
            Console.Write("Celkový počet zvířat k adopci:" + utulek.Zvirata.Count);
            Console.WriteLine();


            Console.WriteLine("Stisknutím libovolné klávesy se provede adopce.");
            Console.ReadKey();

            Console.WriteLine();
            utulek.AdoptujZvire(pes, jan);
            Console.WriteLine("Stisknutím libovolné klávesy se provede aktuální výpis zvířat.");
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Seznam zvířat k adopci:");
            utulek.VypisDostupnaZvirata();
            Console.WriteLine();
            Console.Write("Celkový počet zvířat k adopci:" + utulek.Zvirata.Count);
            Console.WriteLine();

            Console.ReadKey();




        }
    }
}