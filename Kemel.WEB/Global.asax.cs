﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Kemel.BLL;

namespace Kemel.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();
            AutoMapper.Initialize();
        }
    }
}
