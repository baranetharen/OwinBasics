
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Owin.Security;

namespace Owin.Basics.Model
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public List<AuthenticationDescription> AuthProviders { get; internal set; }
    }
}