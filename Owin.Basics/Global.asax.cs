using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Mvc;
namespace Owin.Basics
{
    public class Global : System.Web.HttpApplication
    { 

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapRoute("About",
                url: "{controller}/{action}/{id}",
                defaults: new { Controller = "About", action = "Index" , id = UrlParameter.Optional});
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}