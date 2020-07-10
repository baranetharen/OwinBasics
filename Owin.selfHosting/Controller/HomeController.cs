
using System.Web.Http;

namespace Owin.selfHosting.Controller
{
    class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetIndex()
        {
            return Ok("Welcome to WebApi");
        }
    }
}
