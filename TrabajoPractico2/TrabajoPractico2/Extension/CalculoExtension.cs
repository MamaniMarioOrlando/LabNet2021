using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico2.Extension
{
    public static class CalculoExtension
    {
        public static int Division(this int valor, int valor2)
        {
            int resultado;
            try
            {
                return resultado = valor / valor2;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
