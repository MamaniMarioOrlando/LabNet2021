using System;
using System.Collections.Generic;

namespace TrabajoPractico1
{
    class Program
    {
        List<TransportePublico> vehiculos;
        static void Main(string[] args)
        {
            Titulo();
            MostrarCantidadDePasajeros(ArmandoDotacionesDeTransportes());
            Console.WriteLine();
        }

        private static void Titulo()
        {
            Console.WriteLine("***********Transporte Publico***********\n\n");
        }



        public static List<TransportePublico> ArmandoDotacionesDeTransportes()
        {
            List<TransportePublico> vehiculos = new List<TransportePublico>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("que Transporte desea creaar Taxi presione T o Omnibus presione O: ");
                Char palabra = Convert.ToChar(Console.ReadLine());
                if (palabra == 'T')
                {
                    Console.WriteLine("ingrese la cantidad de pasajeros: ");
                    int cantidadPasajeros = Convert.ToInt32(Console.ReadLine());
                    TransportePublico transporte = new Taxi(cantidadPasajeros);
                    vehiculos.Add(transporte);

                }
                if (palabra == 'O')
                {
                    Console.WriteLine("ingrese la cantidad de pasajeros: ");
                    int cantidadPasajeros = Convert.ToInt32(Console.ReadLine());
                    TransportePublico transporte = new Omnibus(cantidadPasajeros);
                    vehiculos.Add(transporte);
                }
            }


            return vehiculos;
        }
        private static void MostrarCantidadDePasajeros(List<TransportePublico> vehiculos)
        {
            int contadorTaxi = 1;
            int contadorOmnibus = 1;
            Console.WriteLine();
            Console.WriteLine();
            foreach (TransportePublico item in vehiculos)
            {
                if (item.GetType().Name == "Omnibus")
                {
                    Console.WriteLine("{0} {1}: {2} pasajeros", item.GetType().Name, contadorOmnibus++, item.Pasajeros);
                }
                if (item.GetType().Name == "Taxi")
                {
                    Console.WriteLine("{0} {1}: {2} pasajeros", item.GetType().Name, contadorTaxi++, item.Pasajeros);
                }
            }
        }

    }
}