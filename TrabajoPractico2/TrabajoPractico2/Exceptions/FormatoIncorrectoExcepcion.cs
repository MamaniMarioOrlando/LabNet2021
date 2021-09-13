using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico2.Exceptions
{
    class FormatoIncorrectoExcepcion : Exception
    {
        public FormatoIncorrectoExcepcion(string message) : base("Seguro Ingreso una letra o no ingreso nada!")
        {
        }
    }
}
