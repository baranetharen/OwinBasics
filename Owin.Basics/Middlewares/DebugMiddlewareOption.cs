using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Basics.Middlewares
{
    public class DebugMiddlewareOption
    {
        public Action<IOwinContext> OnIncomingRequest;
        public Action<IOwinContext> OnOutGoingRequest;
    }
}