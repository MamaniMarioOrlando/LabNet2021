using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico2.Exceptions;

namespace TrabajoPractico2
{
    class Logic
    {
        public int Division(int dividendo, int divisor)
        {
            int resultado;
            try
            {
                return resultado = dividendo / divisor;
            }
            catch (DivideByZeroException ex)
            {

                throw new DivisionPorCeroExcepcion(ex.Message);
            }
        }

        public int  ConvertirUnaCadenaAEntero(String dato)
        {
            try
            {
                return Convert.ToInt32(dato);
            }
            catch (FormatException ex)
            {

                throw new FormatoIncorrectoExcepcion(ex.Message);
            }
        }
    }
}
