﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebApi2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApi2.UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
        }
    }
}
