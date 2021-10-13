﻿using northwind.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
            context.Products.Add(newElem);
            try
            {
                context.SaveChanges();
            }
            catch (ObjectDisposedException e)
            {
                throw new ObjectDisposedException($"Hubo un error en el estado actual del producto  {e.Message}");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public void Delet(int elem)
        {
            Products producto = context.Products.Find(elem);
            context.Products.Remove(producto);
            try
            {
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

        public Products GetByID(int id)
        {
            try
            { 
                return context.Products.Find(id);
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