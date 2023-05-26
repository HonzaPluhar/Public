using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CestovniKancelarProjekt
{
    public class Zajezd
    {

        public string NazevZajezdu;
        public string Destinace;
        public string DatumOdjezdu;
        public string DatumPrijezdu;
        public string IdZajezdu;


        public Zajezd(string nazevZajezdu, string destinace, string datumOdjezdu, string datumPrijezdu, string idZajezdu)
        {
            NazevZajezdu = nazevZajezdu;
            Destinace = destinace;
            DatumOdjezdu = datumOdjezdu;
            DatumPrijezdu = datumPrijezdu;
            IdZajezdu = idZajezdu;
        }

    }
}
