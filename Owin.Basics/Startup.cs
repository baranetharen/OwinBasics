using Microsoft.Owin;
using Owin.Basics.Middlewares;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;

namespace Owin.Basics
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.Use<DebugMiddlewareGeneric>(new DebugMiddlewareOption()
            {
                OnIncomingRequest = new Action<IOwinContext>(DebugIn),
                OnOutGoingRequest = new Action<IOwinContext>(DebugOut)
            });

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
            {
                AuthenticationType = "CookieAuthendication",
                LoginPath = new PathString("/auth/login")
            });

            app.UseFacebookAuthentication(new Microsoft.Owin.Security.Facebook.FacebookAuthenticationOptions()
            {
                 AppId = "2597505943847908",
                 AppSecret = "ed33463bc6a08cc25023856749262276",
                 SignInAsAuthenticationType = "CookieAuthendication" //ApplicationCookie
            });

            app.UseTwitterAuthentication(new Microsoft.Owin.Security.Twitter.TwitterAuthenticationOptions()
            {
                ConsumerKey="",
                ConsumerSecret ="",
                SignInAsAuthenticationType = "CookieAuthendication",
                BackchannelCertificateValidator = null
            });

            app.Use(async (ctx, next) =>
            {
                if(ctx.Authentication.User.Identity.IsAuthenticated)
                    Debug.WriteLine($"User {ctx.Authentication.User.Identity.Name} is Authendicated");
                else
                    Debug.WriteLine($"Use not Authendicated");
                await next();
            });

            //app.UseNancy();
            app.Map("/nancy", x => x.UseNancy());

            var httpapiconfig = new HttpConfiguration();
            httpapiconfig.MapHttpAttributeRoutes();
            app.UseWebApi(httpapiconfig);


            //app.UseNancy(otp => otp.PassThroughWhenStatusCodesAre(Nancy.HttpStatusCode.NotFound));

         
            //app.Use(async (ctx, next) => 
            //{
            //    await ctx.Response.WriteAsync("<html><head></head><body><p>Hello World</p></body></html>");
            //});
        }

        public static void DebugIn(IOwinContext context)
        {
            Debug.WriteLine(context.Request.Headers.First().ToString());
        }

        public static void DebugOut(IOwinContext context)
        {
            Debug.WriteLine(context.Response.Headers.First().ToString());
        }
    }
}