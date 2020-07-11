using Owin.Basics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Owin.Basics.Controller
{
    public class AuthController : System.Web.Mvc.Controller
    {

        // GET: Auth
        public ActionResult Login()
        {
            var loginModel = new LoginViewModel();
            var provides = HttpContext.GetOwinContext().Authentication.GetAuthenticationTypes(x => !string.IsNullOrEmpty(x.Caption));
            loginModel.AuthProviders = provides.ToList();
            return View(loginModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "barane" && model.Password.Equals("12345"))
                {
                    var idenity = new ClaimsIdentity("CookieAuthendication");
                    idenity.AddClaims(new List<Claim>()
                    {
                         new Claim(ClaimTypes.Name , model.UserName),
                         new Claim(ClaimTypes.NameIdentifier , model.UserName)
                    });
                    HttpContext.GetOwinContext().Authentication.SignIn(idenity);
                }
            }
            return View();
        }


        [Authorize]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "About", null);
        }

        public ActionResult SocialLogin(string id)
        {
            HttpContext.GetOwinContext().Authentication.Challenge(new Microsoft.Owin.Security.AuthenticationProperties()
            {
                RedirectUri = "/secret"
            }, id);

            return new HttpUnauthorizedResult(); //pick up by cookie auth
        }
    }
}