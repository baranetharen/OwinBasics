using BasicFormAuth.Models;
using System.Linq;
using System.Web.Mvc;

namespace BasicFormAuth.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        AccountRepository accountRepository = null;
        public AccountController()
        {
            accountRepository = new AccountRepository();
        }
        public ActionResult Register()
        {
            var loginmodel = new LoginViewModel();
            return View(loginmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                accountRepository.Add(model);
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Login()
        {
            var loginmodel = new LoginViewModel();
            return View(loginmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ele = accountRepository.FindAll().Where(x => x.Password == model.Password && x.UserName == model.UserName).SingleOrDefault();
                if (ele != null)
                {
                    var val = new FormAuthendicationManager(new System.TimeSpan(0, 10, 0));
                    if (val.Authendicate(model.UserName, model.Password))
                    {
                        return RedirectToAction("Contact", "Home", new { model.UserName  , model.Password});
                    }
                }
                else
                {
                    ModelState.AddModelError("ErrorMessage", "Please Enter correct username and password");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult SignOut()
        {
            return RedirectPermanent("/home/index");
        }

    }
}