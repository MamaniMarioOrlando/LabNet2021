﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Linq.WebAPI.Controllers
{
    public class HomeController : Controller
    {

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
