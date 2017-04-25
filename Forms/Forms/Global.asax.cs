﻿using DAO.itinsync.icom.BaseAS;
using Services.itinsync.icom.cache;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Forms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           
            BaseAS.Source = ConfigurationManager.ConnectionStrings["mysqlConnection"].ConnectionString;


            new CacheManagmentService().executeAsPrimary(null);


        }
    }
}