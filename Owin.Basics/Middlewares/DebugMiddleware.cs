using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoFuc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;
namespace Owin.Basics.Middlewares
{
    public class DebugMiddleware : OwinMiddleware //only work on Katana
    {
        DebugMiddlewareOption _option;
        public DebugMiddleware(OwinMiddleware next) : base(next)
        {

        }
        public DebugMiddleware(OwinMiddleware next, DebugMiddlewareOption option) : base(next)
        {
            this._option = option;
        }
        public override Task Invoke(IOwinContext context)
        {
            return Task.Run(() =>
            {
                Debug.WriteLine($"Request path:{context.Request.Path}");
                Next.Invoke(context);
                Debug.WriteLine($"responce length:{context.Request.Body.Length}");
            });
        }
    }

    public class DebugMiddlewareGeneric
    {
        AutoFuc _next;
        bool OptProvided;
        DebugMiddlewareOption _option;
        public DebugMiddlewareGeneric(AutoFuc next)
        {
            this._next = next;
        }
        public DebugMiddlewareGeneric(AutoFuc next, DebugMiddlewareOption options)
        {
            this._next = next;
            _option = options;
            InitOption();
        }

        private void InitOption()
        {
           if(_option != null)
            {
                OptProvided = _option.OnIncomingRequest != null && _option.OnOutGoingRequest != null;
            }
        }

        public async Task Invoke(IDictionary<string, object> con)
        {
            var context = new OwinContext(con);
            if (!OptProvided)
            {
                Debug.WriteLine($"Request path:{context.Request.Path}");
                await _next(con);
                Debug.WriteLine($"responce length:{context.Request.Path}");
            }
            else
            {
                _option.OnIncomingRequest(context);
                await _next(con);
                _option.OnOutGoingRequest(context);
            }
        }
    }
}