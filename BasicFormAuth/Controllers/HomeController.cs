using BasicFormAuth.Models;
using System.Web.Mvc;

namespace BasicFormAuth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact(LoginViewModel loginViewModel)
        {
            var u = User.Identity;
            if(loginViewModel!=null)
            ViewBag.Message = $"{loginViewModel.UserName} Contacts.";

            return View();
        }
    }
}