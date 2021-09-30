using northwind.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.Linq.Logic
{
    public class LogicCustomer:LogicBase, IABMLogic<Customers>
    {
        #region Constructor
        public LogicCustomer() : base() 
        {
        }

        #endregion

        #region MethodPublic
        public void Add(Customers newElem)
        {
            try
            {
                context.Customers.Add(newElem);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delet(int elem)
        {
            try
            {
                var customerDelete = context.Customers.Find(elem);
                context.Customers.Remove(customerDelete);
                context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Customers> GetAll()
        {
            try
            {
                return context.Customers.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpDate(Customers newElem)
        {
            try
            {
                var customerUpdate = context.Customers.Find(newElem.CustomerID);
                customerUpdate.CompanyName = newElem.CompanyName;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion
    }

}
