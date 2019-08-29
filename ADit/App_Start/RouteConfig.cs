using System.Web.Mvc;
using System.Web.Routing;

namespace ADit
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "Sitemap",
                "ADitClientLogin.sitemap",
                new { controller = "Printing", action = "Index" }
            );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
           
        }
    }
}
