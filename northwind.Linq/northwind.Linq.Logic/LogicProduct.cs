using northwind.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace northwind.Linq.Logic
{
    public class LogicProduct:LogicBase, IABMLogic<Products>
    {
        #region Constructor
        public LogicProduct() : base()
        {
        }
        #endregion

        #region MethodPublic
        public void Add(Products newElem)
        {
            try
            {
                context.Products.Add(newElem);
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
                var regionDelete = context.Products.Find(elem);
                context.Products.Remove(regionDelete);
                context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Products> GetAll()
        {
            try
            {
                return context.Products.ToList();
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public void UpDate(Products newElem)
        {
            try
            {
                var productUpdate = context.Products.Find(newElem.ProductID);
                productUpdate.ProductName = newElem.ProductName;
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
