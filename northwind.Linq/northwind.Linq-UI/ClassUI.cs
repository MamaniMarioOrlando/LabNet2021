using northwind.Linq.Entities;
using northwind.Linq.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.Linq_UI
{
    static class ClassUI
    {
        public static void ShowQueryesCustomers()
        {
            LogicCustomer customer = new LogicCustomer();

            foreach (String custom in customer.GetAllCustomersNameToUpperAndLower())
            {
                Console.WriteLine(custom);
            }
        }

        public static void ShowQueryesProducts()
        {
            LogicProduct product = new LogicProduct();

            foreach (Products prod in product.GetAllProductsWithStock())
            {
                Console.WriteLine($"{prod.ProductName}, {prod.UnitsInStock}");
            }
        }
    }
}
