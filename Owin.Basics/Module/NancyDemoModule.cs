using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Owin;
using Nancy.Security;
namespace Owin.Basics.Module
{
    public class NancyDemoModule :NancyModule
    { 
        public NancyDemoModule()
        {      
            Get["/nancyHome"] = x =>
            {
                this.RequiresMSOwinAuthentication();
                var eve = Context.GetOwinEnvironment();
                return $"<div> user :{Context.GetMSOwinUser()}";
            };
        }
    }
}