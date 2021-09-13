using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico2.Exceptions;
using TrabajoPractico2.Extension;

namespace TrabajoPractico2
{
    public class Helper
    {
        public static void PedirUnValor() 
        {
            Console.WriteLine("***Primer Metodo capturando Exepcion***\n");
            
            Console.Write("Por favor ingrese un numero para realizar la division: ");
            try
            {
                int resultado;
                int divisor=0;
                int dividendo = Convert.ToInt32(Console.ReadLine());
                resultado= dividendo.Division(divisor);

                MostrarMensajeResultadoDeDivision(resultado);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("\n El tipo de excepcion: {0} \n Message: {1}",ex.GetType().Name, ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\n El tipo de excepcion: {0} \n Message: {1}", ex.GetType().Name, ex.Message);
            }
            finally
            {
                Console.WriteLine("\nLa operacion del primer metodo a finalizado!\n\n");
            }

        }
        

        public static void PedirDosValores()
        {
            Console.WriteLine("\n\n***Segundo Metodo capturando Exepcion***\n");
            Logic logica = new Logic();
            int resultado;
            try
            {
                Console.Write("Ingrese el dividendo: ");
                int dividendo = logica.ConvertirUnaCadenaAEntero(Console.ReadLine());
                Console.Write("Ingrese el divisor: ");
                int divisor = logica.ConvertirUnaCadenaAEntero(Console.ReadLine());
                
                resultado=logica.Division(dividendo,divisor);

                MostrarMensajeResultadoDeDivision(resultado);
            }
            catch (FormatoIncorrectoExcepcion ex)
            {
                Console.WriteLine("\n El tipo de excepcion: {0} \n Message: {1}", ex.GetType().Name, ex.Message);
            }
            catch (DivisionPorCeroExcepcion ex)
            {
                Console.WriteLine("\n El tipo de excepcion: {0} \n Message: {1}", ex.GetType().Name, ex.Message);

            }
            finally 
            {
                Console.WriteLine("\nLa operacion del segundo metodo a finalizado!");
            }
        }

        public static void MostrarMensajeResultadoDeDivision(int resultado)
        {
            Console.WriteLine("El resultado de la division es: {0}", resultado);
        }
    }
}
