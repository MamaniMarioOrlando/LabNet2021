using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public abstract class TransportePublico
    {
        private int pasajeros;
        protected TransportePublico(int pasajeros)
        {
            this.pasajeros = pasajeros;
        }

        public int Pasajeros
        {
            get { return pasajeros; }
            set
            {
                pasajeros = value;
                if (pasajeros < 0)
                {
                    throw new Exception("no se puede ingresar numeros negativos");
                }

            }
        }

        public abstract void avanzar();
        public abstract void detenerse();
    }
}
