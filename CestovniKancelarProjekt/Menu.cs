using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CestovniKancelarProjekt
{
    public class Menu
    {

        CestovniKancelar cestovniKancelar = new CestovniKancelar();

        public void HlavniMenu()
        {
            bool pokracovat = true;

            while (pokracovat)
            {
                Console.WriteLine("Cestovní kancelář C# projekt ");
                Console.WriteLine("Jan Pluhar - github.com/HonzaPluhar ");
                Console.WriteLine();
                Console.WriteLine("1 - Přidat zájezd");
                Console.WriteLine("2 - Odebrat zájezd");
                Console.WriteLine("3 - Zobrazit všechny zájezdy");
                Console.WriteLine("4 - Vyhledat zájezd podle ID");
                Console.WriteLine("0 - Ukončit program");


                string volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        ZajezdAdd();
                        break;
                    case "2":
                        ZajezdRemove();
                        break;
                    case "3":
                        ZajezdAll();
                        break;
                    case "4":
                        ZajezdSearch();
                        break;
                    case "0":
                        pokracovat = false;
                        break;

                    default:
                        Console.WriteLine("Neexistující příkaz.");
                        PokracujKlavesou();
                        break;

                }

            }
        }

        public void ZajezdAdd()
        {
            Console.Clear();
            Console.Write("Zadejte název zájezdu: ");
            string nazev = Console.ReadLine();


            Console.Write("Zadejte destinaci: ");
            string destinace = Console.ReadLine();


            Console.Write("Datum odjezdu: ");
            string datumOdjezdu = Console.ReadLine();


            Console.Write("Datum příjezdu: ");
            string datumPrijezdu = Console.ReadLine();

            string idZajezdu = Guid.NewGuid().ToString().ToLower().Substring(0, 5);

            Zajezd zajezd = new Zajezd(nazev, destinace, datumOdjezdu, datumPrijezdu, idZajezdu);
            cestovniKancelar.PridatZajezd(zajezd);

            Console.WriteLine($"Zájezd ID {zajezd.IdZajezdu} s názvem {zajezd.NazevZajezdu} byl úspěšně přidán do seznamu zájezdů.");
            PokracujKlavesou();



        }

        public void ZajezdRemove()
        {
            Console.Clear();
            Console.Write("Zadejte ID zájezdu který chcete odstranit: ");
            string idZajezdu = Console.ReadLine().ToLower();

            Zajezd zajezd = cestovniKancelar.seznamZajezdu.Find(v => v.IdZajezdu == idZajezdu);

            if (zajezd != null)
            {
                cestovniKancelar.OdebratZajezd(zajezd);
                PokracujKlavesou();
            }
            else
            {
                Console.WriteLine("Zájezd s tímto ID nebyl nalezen.");
                PokracujKlavesou();
            }

        }

        public void ZajezdAll()
        {
            Console.Clear();
            cestovniKancelar.Vypis();
            PokracujKlavesou();
        }

        public void ZajezdSearch()
        {
            Console.Clear();
            Console.Write("Zadejte ID zájezdu pro vyhledá: ");
            string idZajezdu = Console.ReadLine().ToLower();

            Zajezd zajezd = cestovniKancelar.NajdiZajezdPodleId(idZajezdu);

            {
                if (zajezd != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Zájezd ID {zajezd.IdZajezdu} byl nalezen.");
                    Console.WriteLine();
                    Console.WriteLine("Informace o zájezdu:");
                    Console.WriteLine($"Název zájezdu: {zajezd.NazevZajezdu}");
                    Console.WriteLine($"Destinace: {zajezd.Destinace}");
                    Console.WriteLine($"Od / Do: {zajezd.DatumOdjezdu} / {zajezd.DatumPrijezdu}");
                    PokracujKlavesou();
                }
                else
                {
                    Console.WriteLine("Zájezd s tímto ID nebyl nalezen.");
                    PokracujKlavesou();
                }
            }

        }


        public void PokracujKlavesou()
        {
            Console.WriteLine();
            Console.WriteLine("Pro pokračování stiskněte libovolnou klávesu.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
