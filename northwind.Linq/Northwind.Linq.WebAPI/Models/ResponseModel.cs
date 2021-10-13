using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Linq.WebAPI.Models
{
    public class ResponseModel
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string CantidadPorUnidad { get; set; }
    }
}