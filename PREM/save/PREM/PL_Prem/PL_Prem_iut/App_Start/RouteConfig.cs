using System.Web.Mvc;
using System.Web.Routing;

namespace RAMQ.PRE.PL_Prem_iut
{
    /// <summary>
    /// 
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "PLA9_Accueil",
                                id = UrlParameter.Optional }
            );
        }
    }
}