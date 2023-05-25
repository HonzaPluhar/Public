using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParovisteProjekt
{
    public class Parkoviste
    {

        public List<Vozidlo> zaparkovanaVozidla;

        public Parkoviste()
        {
            zaparkovanaVozidla = new List<Vozidlo>();
        }


        public void Zaparkuj(Vozidlo vozidlo)
        {
            if (zaparkovanaVozidla.Any(v => v.IdVozu == vozidlo.IdVozu))
            {
                Console.WriteLine("Vozidlo s tímto ID je již zaparkované.");
            }
            else if (zaparkovanaVozidla.Any(v => v.IdStani == vozidlo.IdStani))
            {
                Console.WriteLine("Toto parkovací místo je již obsazené.");
            }
            else

            {
                Console.WriteLine($"Vozidlo {vozidlo.IdVozu} bylo přidáno do systému parkoviště");
                zaparkovanaVozidla.Add(vozidlo);
            }
        }

        public void Odparkuj(Vozidlo vozidlo)
        {
            if (zaparkovanaVozidla.Contains(vozidlo))
            {
                Console.WriteLine($"Vozidlo {vozidlo.IdVozu} bylo odstraněno z garáže.");
                zaparkovanaVozidla.Remove(vozidlo);
            }
            else
            {
                Console.WriteLine("Toto vozidlo se na parkovišti nenachází.");
            }
        }



        public void Vypis()
        {

            Console.WriteLine("Výpis vozidel: ");
            if (zaparkovanaVozidla.Count > 0
                )
            {
                Console.WriteLine("ID - Značka - Model - Typ - Umístění");
                foreach (Vozidlo vozidlo in zaparkovanaVozidla)
                {

                    Console.WriteLine($"{vozidlo.IdVozu} | {vozidlo.ZnackaVozu} | {vozidlo.ModelVozu} | {vozidlo.TypVozu} | {vozidlo.IdStani} ");


                }
            }
            else
            {
                Console.WriteLine("V garáži se nenacházejí žádná vozidla.");
            }
            Oddelovac(30);
        }


        public void Oddelovac(int delka, char znamenko = '-')
        {
            Console.WriteLine();
            Console.WriteLine(new string(znamenko, delka));

        }

        public Vozidlo NajdiVozidloPodleId(string idVozidla)
        {
            Vozidlo vozidlo = zaparkovanaVozidla.Find(v => v.IdVozu == idVozidla);
            return vozidlo;
        }



    }
}
