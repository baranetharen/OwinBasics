using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Owin.Basics.Controller
{
    public class SecretController : System.Web.Mvc.Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }       
    }
}