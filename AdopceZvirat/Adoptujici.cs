using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopceZvirat
{
    public class Adoptujici
    {

        public string JmenoAdoptujiciho;
        public List<Zvire> AdoptovanaZvirata { get; set; }

        public Adoptujici(string jmenoAdoptujiciho)
        {

            JmenoAdoptujiciho = jmenoAdoptujiciho;
            AdoptovanaZvirata = new List<Zvire>();

        }

    }
}
