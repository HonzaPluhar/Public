
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CestovniKancelarProjekt
{
    public class CestovniKancelar
    {

        public List<Zajezd> seznamZajezdu;

        public CestovniKancelar()
        {

            seznamZajezdu = new List<Zajezd>();
        }


        public void PridatZajezd(Zajezd zajezd)
        {

            if (seznamZajezdu.Any(v => v.IdZajezdu == zajezd.IdZajezdu))
            {
                Console.WriteLine("Tento zájezd je již zadán.");
            }
            else
            {
                seznamZajezdu.Add(zajezd);
            }
        }

        public void OdebratZajezd(Zajezd zajezd)
        {
            if (seznamZajezdu.Contains(zajezd))
            {
                seznamZajezdu.Remove(zajezd);
                Console.WriteLine($"Zájezd ID {zajezd.IdZajezdu} s názvem {zajezd.NazevZajezdu} byl úspěšně odstraněn.");

            }
            else
            {
                Console.WriteLine("Zájezd nebyl nalezen.");

            }
        }

        public void Vypis()
        {
            if (seznamZajezdu.Count > 0)
            {

                Console.WriteLine("Název zájezdu - Destinace - Odjezd - Příjezd - ID zájezdu");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine();
                foreach (Zajezd zajezd in seznamZajezdu)
                {

                    Console.WriteLine($"{zajezd.NazevZajezdu} | {zajezd.Destinace} | {zajezd.DatumOdjezdu} | {zajezd.DatumPrijezdu} | {zajezd.IdZajezdu}");
                }
            }
            else
            {
                Console.WriteLine("Nejsou zde žádné zájezdy.");
            }

        }

        public Zajezd NajdiZajezdPodleId(string idZajezdu)
        {

            Zajezd zajezd = seznamZajezdu.Find(v => v.IdZajezdu == idZajezdu);
            return zajezd;

        }
    }
}
