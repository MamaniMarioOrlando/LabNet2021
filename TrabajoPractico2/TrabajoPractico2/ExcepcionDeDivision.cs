using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrabajoPractico2
{
    public class ExcepcionDeDivision
    {
        public static void PedirUnValor() 
        {
            Console.WriteLine("***Ejercicio 1 capturando Exepcion***\n");
            
            Console.Write("Ingrese un numero: ");
            try
            {
                int numero = Convert.ToInt32(Console.ReadLine());
                Division(numero);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("\n Message: {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("\nLa operacion a finalizado!");
            }

        }
        private static void Division(int valor)
        {
            int resultado;

            try
            {
                resultado = valor /0;
                Console.WriteLine("El resultado de la divisio es: {0}", resultado);
            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine("\n Message: {0}", ex.Message);
            }
            finally 
            {
                Console.WriteLine("\nLa operacion a finalizado!");
            }
        }
    }
}
