using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdopceZvirat
{
    public class Utulek
    {

        public List<Zvire> Zvirata;



        public Utulek()
        {

            Zvirata = new List<Zvire>();


        }

        public void AdoptujZvire(Zvire zvire, Adoptujici adoptujici)
        {
            if (Zvirata.Contains(zvire))
            {
                Zvirata.Remove(zvire);
                adoptujici.AdoptovanaZvirata.Add(zvire);
                Console.WriteLine($"Adoptující {adoptujici.JmenoAdoptujiciho} adoptoval(a) {zvire.JmenoZvirete}");
            }
            else
            {
                Console.WriteLine("Toto zvíře již bylo adoptováno nebo neexistuje v útulku.");
            }
        }


        public void VypisDostupnaZvirata()
        {
            foreach (Zvire zvire in Zvirata)
            {
                Console.WriteLine($"Jméno: {zvire.JmenoZvirete} Druh: {zvire.DruhZvirete} Věk: {zvire.VekZvirete}");
            }
        }

    }
}
