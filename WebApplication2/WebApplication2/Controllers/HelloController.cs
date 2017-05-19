using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult In()
        {
            return View();
        }

    }
}