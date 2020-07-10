using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Owin.Basics.Controller
{
    public class AboutController : System.Web.Mvc.Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }
    }
}