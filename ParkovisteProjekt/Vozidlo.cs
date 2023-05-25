using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParovisteProjekt
{
    public class Vozidlo
    {

        public string ZnackaVozu;
        public string ModelVozu;
        public string IdStani;
        public string TypVozu;
        public string IdVozu;



        public Vozidlo(string znackaVozu, string modelVozu, string typVozu, string idStani, string idVozu)
        {

            ZnackaVozu = znackaVozu;
            ModelVozu = modelVozu;
            IdStani = idStani;
            TypVozu = typVozu;
            IdVozu = idVozu;
        }





    }
}
