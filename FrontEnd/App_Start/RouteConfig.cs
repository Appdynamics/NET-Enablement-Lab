using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FrontEnd
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "All devices",
                url:"{userId}/devices",
                defaults: new {controller = "Device", action = "GetAllDevices" }
                );

            routes.MapRoute(
                name: "Device status",
                url: "{userId}/{deviceId}/status",
                defaults: new { controller = "Device", action = "GetDeviceStatus" }
                );

            routes.MapRoute(
                name: "Update device settings",
                url: "{userId}/{deviceId}/updatesettings",
                defaults: new { controller = "Device", action = "UpdateDeviceSettings" }
                );

            routes.MapRoute(
                name: "Get device settings",
                url: "{userId}/{deviceId}/settings",
                defaults: new { controller = "Device", action = "GetDeviceSettings" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
