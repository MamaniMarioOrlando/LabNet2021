using northwind.Linq.Entities;
using northwind.Linq.Logic;
using Northwind.Linq.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Northwind.Linq.MVC.Controllers
{
    public class ProductController : Controller
    {

        private LogicProduct logic = new LogicProduct();
        // GET: Product
        public ActionResult Index(String mensaje)
        {
            ViewBag.Mensaje = "";

            if (mensaje == null)
            {
                mensaje = "";
            }
            else
            {
                ViewBag.Mensaje = mensaje;
            }
            List<Products> products = logic.GetAll();
            List<ProductView> productView = products.Select(x => new ProductView() {
                IdProducto = x.ProductID,
                ProductName = x.ProductName,
            }).ToList();
            return View(productView);
        }


        public ActionResult Insert()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Insert(ProductView productoView)
        {

            try
            {
                Products producto = new Products();
                producto.ProductName = productoView.ProductName;
                logic.Add(producto);

                return RedirectToAction("Index", new { mensaje = $"Se inserto ok" });
            }
            catch (ObjectDisposedException e)
            {
                return View(e.Message);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "ErrorView");
            }
        }
        public ActionResult Delete(int id) 
        {
            
            try
            {
                logic.Delet(id);
                return RedirectToAction("Index", new { mensaje = $"Se borro OK" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { mensaje = $"El producto esta relacionado con ordenes no se puede borrar" });
            }
        }


    }
}