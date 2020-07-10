using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Owin.selfHosting
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {

            //HttpConfiguration conf = new HttpConfiguration();

            //conf.Routes.MapHttpRoute("Default", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });

            //app.UseWebApi(conf);

            app.UseStaticFiles();

            app.Use(async (apx, next) =>
            {
                await apx.Response.WriteAsync("Welcome");
            });
        }
    }
}
