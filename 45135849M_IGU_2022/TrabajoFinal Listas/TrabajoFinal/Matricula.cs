using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinal
{
    public class Matricula
    {
        public string letras { get; set; }
        public string numeros { get; set; }


        public Matricula( string numeros, string letras)
        {
            this.letras = letras;
            this.numeros = numeros;
        }

        public string TostringGuion()
        {

            return numeros + "-" + letras;
        }
    }
}
