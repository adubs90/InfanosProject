using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using Infanos.Models;
using Infanos.Logic;

namespace Infanos
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Initialize games database
            Database.SetInitializer(new GamesDBInit());

          // Create the custom role and user.
          RoleActions roleActions = new RoleActions();
          roleActions.AddUserAndRole();

                      RegisterCustomRoutes(RouteTable.Routes);
        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
          routes.MapPageRoute(
              "GamesByConsoleRoute",
              "Consoles/{consoleName}",
              "~/GamesList.aspx"
          );
          routes.MapPageRoute(
              "GamesByNameRoute",
              "Games/{gameName}",
              "~/GameDetails.aspx"
          );
        
        }        
    }
}