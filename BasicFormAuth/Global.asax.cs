using BasicFormAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace BasicFormAuth
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported)
            {
                HttpCookie cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie == null) return;
                var ticket = FormAuthendicationManager.Autherize(cookie.Value);
                if (ticket == null) return;
                if (!string.IsNullOrEmpty(ticket.UserData))
                {
                    Context.User = new GenericPrincipal(new FormsIdentity(ticket), new string[] { "admin" });
                }
            }
        }
    }
}
