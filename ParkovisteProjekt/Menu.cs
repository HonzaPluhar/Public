using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ParovisteProjekt
{
    public class Menu
    {
        Parkoviste parkoviste = new Parkoviste();
        public void HlavniMenu()
        {
            bool ukonceni = false;

            while (!ukonceni)
            {
                Console.WriteLine("1 - Přidat vozidlo");
                Console.WriteLine("2 - Odebrat vozidlo");
                Console.WriteLine("3 - Zobrazit všecna vozidla");
                Console.WriteLine("4 - Vyhledat vozidlo");
                Console.WriteLine("0 - Ukončit program");

                string volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        PridatVozidlo();
                        break;
                    case "2":
                        OdebratVozidlo();
                        break;
                    case "3":
                        ZobrazitVsechnaVozidla();
                        break;
                    case "4":
                        VyhledatVozidlo();
                        break;
                    case "0":
                        ukonceni = true;
                        break;

                    default:
                        Console.WriteLine("Neplatné zadání, zkuste to znovu.");
                        break;
                }
            }
        }


        public void PridatVozidlo()
        {
            parkoviste.Oddelovac(30);
            Console.WriteLine("Zadejte značu vozidla:");
            string znacka = Console.ReadLine();

            Console.WriteLine("Zadej model vozidla:");
            string model = Console.ReadLine();

            Console.WriteLine("Zadej typ vozidla:");
            string typ = Console.ReadLine();

            Console.WriteLine("Zadej místo na parkovišti:");
            string idStani = Console.ReadLine().ToUpper();

            string idVozida = Guid.NewGuid().ToString().Substring(0, 4).ToLower();

            Vozidlo vozidlo = new Vozidlo(znacka, model, typ, idStani, idVozida);
            parkoviste.Zaparkuj(vozidlo);
            Console.WriteLine();
        }



        public void OdebratVozidlo()
        {
            parkoviste.Oddelovac(30);
            Console.WriteLine("Zadejte id vozidla k odebrání:");
            string idVozidla = Console.ReadLine().ToLower();

            Vozidlo vozidlo = parkoviste.zaparkovanaVozidla.Find(v => v.IdVozu == idVozidla);
            if (vozidlo != null)
            {
                parkoviste.Odparkuj(vozidlo);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Vozidlo s tímto ID nebylo nlezeno.");
                Console.WriteLine();
            }
        }

        public void ZobrazitVsechnaVozidla()
        {
            parkoviste.Oddelovac(30);
            parkoviste.Vypis();
        }

        public void VyhledatVozidlo()
        {
            parkoviste.Oddelovac(30);
            Console.WriteLine("Zadejte ID vozidla k vyhledání: ");
            string idVozidla = Console.ReadLine().ToLower();

            Vozidlo vozidlo = parkoviste.NajdiVozidloPodleId(idVozidla);

            if (vozidlo != null)
            {
                Console.WriteLine($"\nVozidlo id {vozidlo.IdVozu}");
                Console.WriteLine($"\nZnačka vozu: {vozidlo.ZnackaVozu} \nModel vozu: {vozidlo.ModelVozu} \nTyp vozu: {vozidlo.TypVozu} \nPozice na parkovišti: {vozidlo.IdStani}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Vozidlo s tímto ID nebylo nalezeno");
                Console.WriteLine();
            }



        }



    }
}
