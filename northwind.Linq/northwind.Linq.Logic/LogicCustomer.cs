using northwind.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.Linq.Logic
{
    public class LogicCustomer:LogicBase
    {
        #region Constructor
        public LogicCustomer() : base() 
        {
        }
        #endregion

        #region MethodPublic

        public List<Customers> GetAllObjectCustomers()
        {
            var query1 = from customer in context.Customers
                         select customer;
            return query1.ToList();
        }
        public List<Customers> GetAllCustomersRegionWa()
        {
            var query4= context.Customers.Where(x => x.Region == "WA")
                                         .ToList();
            return query4;
        }

        public List<String> GetAllCustomersNameToUpperAndLower()
        {
            var queryToUpper = context.Customers.Select(x => x.CompanyName.ToUpper());

            var queryToLower = context.Customers.Select(x => x.ContactName.ToLower());

            var query6 = queryToUpper.Concat(queryToLower);

            return query6.ToList();

        }

        public Object JoinCustomerOrder()
        {
            var orders = context.Orders.Select(x => x);

            var customers = context.Customers.Select(x => x);

            var query7 = from order in orders
                         join customer in customers
                         on order.CustomerID equals customer.CustomerID
                         where customer.Region == "WA"
                         && order.OrderDate > new DateTime(1997, 1, 1)
                         select new
                         {
                             order.OrderID,
                             customer.ContactName,
                             customer.Region,
                             order.OrderDate
                         };
            return query7;
        }

        public List<Customers> FirstThreeCustomer()
        {
            var query8 = from cust in context.Customers
                         where cust.Region == "WA"
                         select cust;
            return query8.Take(3).ToList();
        }


        #endregion
    }

}
