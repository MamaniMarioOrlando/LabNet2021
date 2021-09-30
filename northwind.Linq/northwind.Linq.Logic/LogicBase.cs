using northwind.Linq.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.Linq.Logic
{
    public class LogicBase
    {
        protected readonly northwindContext context;

        public LogicBase()
        {
            context = new northwindContext();
        }
    }
}
