﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace DotVVM.Samples
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            //Customer notest sample
            routes.MapPageRoute("CustomerNotes", "CustomerNotes.aspx", "~/Pages/CustomerNotes.aspx");

            //Products sample
            routes.MapPageRoute("Products", "Products.aspx", "~/Pages/Products.aspx");
            routes.MapPageRoute("ProductsService", "ProductsService.aspx", "~/Pages/ProductsService.aspx");
        }
    }
}