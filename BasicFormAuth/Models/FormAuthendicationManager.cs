using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace BasicFormAuth.Models
{
    public class FormAuthendicationManager
    {
        private TimeSpan tokenValidity;
        private const int version = 1;
        public FormAuthendicationManager(TimeSpan token)
        {
            if (token == TimeSpan.MinValue)
            {
                this.tokenValidity = new TimeSpan(0, 0, 10, 0, 0);
            }
            else
            {
                this.tokenValidity = token;
            }
        }
        private FormsAuthenticationTicket CreateFromTicket(string username, string password)
        {
            return new FormsAuthenticationTicket(version, username, DateTime.Now, DateTime.Now.Add(tokenValidity), true, password);
        }

        public bool Authendicate(string username, string password)
        {
            var ticket = CreateFromTicket(username, password);
            var eenc = FormsAuthentication.Encrypt(ticket);
            if (!FormsAuthentication.CookiesSupported)
            {
                FormsAuthentication.SetAuthCookie(eenc, false);
            }
            else
            {
                HttpCookie cooike = new HttpCookie(FormsAuthentication.FormsCookieName, eenc)
                {
                    Expires = DateTime.Now.Add(tokenValidity)
                };
                HttpContext.Current.Response.Cookies.Add(cooike);
            }
            return true;
        }

        public static FormsAuthenticationTicket Autherize(string value)
        {
            FormsAuthenticationTicket ticker = null;
            if (string.IsNullOrEmpty(value))
            {
                try
                {
                    ticker = FormsAuthentication.Decrypt(value);
                }
                catch (Exception)
                {
                    return ticker;
                }
            }
            return ticker;
        }
    }
}