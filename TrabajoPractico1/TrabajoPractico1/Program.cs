using System;
using System.Collections.Generic;

namespace TrabajoPractico1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TransportePublico> vehiculos = new List<TransportePublico>();
            Titulo();
            ArmandoDotacionesDeTransportes(vehiculos);
            MostrarCantidadDePasajeros(vehiculos);
            Console.WriteLine();
        }

        private static void Titulo()
        {
            Console.WriteLine("************************************************************************\n" +
                "*************************Transporte Publico*****************************\n"
                + "************************************************************************\n");
        }

        private static void ArmandoDotacionesDeTransportes(List<TransportePublico> vehiculos)
        {
            Console.Write("\t\t*Solo se agregan 10 transportes\n\n");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Que Transporte desea creaar? Taxi presione (T), Omnibus presione (O): ");
                Char caracter = Convert.ToChar(Console.ReadLine());
                while (!ValidandoCaracter(caracter))
                {
                    Console.Write("ErrorDeCaracterInvalido. Que Transporte desea creaar? Taxi presione (T), Omnibus presione (O): ");
                    caracter = Convert.ToChar(Console.ReadLine());
                }
                if (caracter == 'T')
                {
                    Console.Write("ingrese la cantidad de 1 a 4 pasajeros: ");
                    int cantidadPasajeros = Convert.ToInt32(Console.ReadLine());
                    while (!ValidandoCantidaDePasajerosDelTaxi(cantidadPasajeros))
                    {
                        Console.Write("ERROR ingrese una cantidad de 1 a 4 pasajeros: ");
                        cantidadPasajeros = Convert.ToInt32(Console.ReadLine());
                    }
                    TransportePublico transporte = new Taxi(cantidadPasajeros);
                    vehiculos.Add(transporte);
                }
                if (caracter == 'O')
                {
                    Console.Write("ingrese la cantidad de pasajeros: ");
                    int cantidadPasajeros = Convert.ToInt32(Console.ReadLine());
                    while (!ValidandoCantidaDePasajerosDelOmnibus(cantidadPasajeros))
                    {
                        Console.Write("ERROR ingrese una cantidad de 1 a 100 pasajeros: ");
                        cantidadPasajeros = Convert.ToInt32(Console.ReadLine());
                    }
                    TransportePublico transporte = new Omnibus(cantidadPasajeros);
                    vehiculos.Add(transporte);
                }
            }
        }
        private static void MostrarCantidadDePasajeros(List<TransportePublico> vehiculos)
        {
            int contadorTaxi = 1;
            int contadorOmnibus = 1;
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("****************************Detalle*************************************\n");
            foreach (TransportePublico transporte in vehiculos)
            {
                if (transporte.GetType().Name == "Omnibus")
                {
                    Console.WriteLine("{0} {1}: {2} pasajeros", transporte.GetType().Name, contadorOmnibus++, transporte.Pasajeros);
                }
            }
            Console.WriteLine();
            foreach (TransportePublico transporte in vehiculos)
            {
                if (transporte.GetType().Name == "Taxi")
                {
                    Console.WriteLine("{0} {1}: {2} pasajeros", transporte.GetType().Name, contadorTaxi++, transporte.Pasajeros);
                }
            }
        }
        public static bool ValidandoCantidaDePasajerosDelTaxi(int valor)
        {
            if (valor > 0 && valor <= 4)
            {
                return true;
            }
            return false;
        }
        public static bool ValidandoCantidaDePasajerosDelOmnibus(int valor)
        {
            if (valor > 0 && valor <= 100)
            {
                return true;
            }
            return false;
        }
        public static bool ValidandoCaracter(int caracter)
        {
            if (caracter == 'T' || caracter == 'O')
            {
                return true;
            }
            return false;
        }

    }
}