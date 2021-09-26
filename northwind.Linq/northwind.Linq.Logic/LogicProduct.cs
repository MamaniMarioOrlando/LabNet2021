using northwind.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.Linq.Logic
{
    public class LogicProduct:LogicBase
    {
        #region Constructor
        public LogicProduct() : base()
        {
        }
        #endregion

        #region MethodPublic
        public List<Products> GetAllProductsOutOfStock()
        {
            var query2 = context.Products.Where(x => x.UnitsInStock == 0).ToList();

            return query2;
        }

        public List<Products> GetAllProductsWithStock()
        {
            var query3 = from product in context.Products
                         where product.UnitsInStock != 0 && product.UnitsOnOrder > 3
                         select product;
            return query3.ToList();
        }

        public Products FirtsNullProduct(int idProduct)
        {
            var productById = context.Products.FirstOrDefault(x => x.ProductID == idProduct);
            return productById;
        }

        public List<Products> GetListOrderByName()
        {
            var query9 = from producto in context.Products
                         orderby producto.ProductName ascending
                         select producto;
            return query9.ToList();
        }

        public List<Products> GetListOrderByUnitInStock()
        {
            var query10 = from producto in context.Products
                          orderby producto.UnitsInStock ascending
                          select producto;
            return query10.ToList();
        }

        #endregion
    }
}
