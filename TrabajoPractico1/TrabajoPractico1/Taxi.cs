using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Taxi : TransportePublico
    {
        public Taxi(int pasajeros) : base(pasajeros) { }
        public override void avanzar()
        {
            throw new NotImplementedException();
        }

        public override void detenerse()
        {
            throw new NotImplementedException();
        }
    }
}
