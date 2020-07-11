using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace Owin.Basics.Controller
{
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {
        [Route("index")]
        [HttpGet]
        public IHttpActionResult Index()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.Identity is System.Security.Claims.ClaimsIdentity)
                {
                    
                    return Content(System.Net.HttpStatusCode.OK, $"Hellow {HttpContext.Current.User.Identity.Name} from api wwith claim", new JsonMediaTypeFormatter());
                }
                return Content(System.Net.HttpStatusCode.OK, $"Hellow {HttpContext.Current.User.Identity.Name} from api wwith claim", new JsonMediaTypeFormatter());
            }
            else
            {
                return Content(System.Net.HttpStatusCode.OK, $"Hellow from api", new JsonMediaTypeFormatter());
            }
        }
    }
}