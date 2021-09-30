using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.Linq.Logic
{
    interface IABMLogic <T>
    {
         List<T> GetAll();

        void Add(T newElem);
        void Delet(int elem);
        void UpDate(T newElem);
    }
}
