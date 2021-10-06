using Newtonsoft.Json;
using Northwind.Linq.MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Linq.MVC.Controllers
{
    public class ProvinciasController : Controller
    {
        // GET: Provincias
        public ActionResult Index()
        {
            string respuesta = getHttp();
            Example pais = JsonConvert.DeserializeObject<Example>(respuesta);
            return View(pais);
        }

        public static string getHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://apis.datos.gob.ar/georef/api/provincias");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
    }
}