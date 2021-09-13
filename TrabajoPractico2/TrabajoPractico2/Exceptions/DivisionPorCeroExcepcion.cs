using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico2.Exceptions
{
    public class DivisionPorCeroExcepcion : Exception
    {
        public DivisionPorCeroExcepcion(string message) : base("Solo Chuck Norris divide por cero!")
        {
        }
    }
}
