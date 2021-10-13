using northwind.Linq.Entities;
using northwind.Linq.Logic;
using Northwind.Linq.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Northwind.Linq.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        LogicProduct productLogic = new LogicProduct();
        // GET: api/Product
        [HttpGet]
        public IHttpActionResult Get()
        {

            try
            {
                List<Products> products = productLogic.GetAll();
                IEnumerable<ResponseModel> reponseProducts = products.Select(x =>
                new ResponseModel()
                {
                    Id = x.ProductID,
                    NameProduct = x.ProductName,
                    CantidadPorUnidad = x.QuantityPerUnit,
                }).ToList();

                return Ok(reponseProducts);
            }
            catch (Exception)
            {

                return InternalServerError();
            }

        }

        // GET: api/Product/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var producto = productLogic.GetByID(id);
                if (producto == null)
                {
                    return NotFound();
                }
                var responseProducto = new ResponseModel()
                {
                    NameProduct = producto.ProductName,
                    CantidadPorUnidad = producto.QuantityPerUnit
                };
                return Ok(responseProducto);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        // POST: api/Product
        [HttpPost]
        public IHttpActionResult Post([FromBody] RequestModel requestProduct)
        {
            try
            {
                Products producto = new Products();
                producto.ProductName = requestProduct.NameProduct;
                producto.QuantityPerUnit = requestProduct.CantidadPorUnidad;
                productLogic.Add(producto);

                return Ok(producto);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT: api/Product/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] RequestModel productRequest)
        {
            try
            {
                var producto = productLogic.GetByID(productRequest.Id);
                if (producto == null)
                {
                    return NotFound();
                }
                producto.ProductName = productRequest.NameProduct;
                producto.QuantityPerUnit = productRequest.CantidadPorUnidad;
                productLogic.UpDate(producto);

                return Ok(productRequest);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        // DELETE: api/Product/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var producto = productLogic.GetByID(id);
                productLogic.Delet(id);

                return Ok(producto);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
    }
}
