using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanHangOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CategoryProduct",
                url: "san-pham",
                defaults: new { controller = "Products", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] {"WebBanHangOnline.Controllers"}
            );
            routes.MapRoute(
                name: "CategoryProduct132",
                url: "san-pham-chu-dao",
                defaults: new { controller = "Products", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            routes.MapRoute(
               name: "About",
               url: "ve-chung-toi",
               defaults: new { controller = "Home", action = "About", alias = UrlParameter.Optional },
               namespaces: new[] { "WebBanHangOnline.Controllers" }
           ); 
            routes.MapRoute(
               name: "Vision",
               url: "tam-nhin",
               defaults: new { controller = "Home", action = "Vision", alias = UrlParameter.Optional },
               namespaces: new[] { "WebBanHangOnline.Controllers" }
           );
            routes.MapRoute(
               name: "News",
               url: "tin-tuc",
               defaults: new { controller = "News", action = "Index", alias = UrlParameter.Optional },
               namespaces: new[] { "WebBanHangOnline.Controllers" }
           );
            routes.MapRoute(
              name: "ProductWebsite",
              url: "san-pham-website",
              defaults: new { controller = "Products", action = "ProductWebsite", alias = UrlParameter.Optional },
              namespaces: new[] { "WebBanHangOnline.Controllers" }
          );
            routes.MapRoute(
               name: "Solution",
               url: "giai-phap",
               defaults: new { controller = "Home", action = "Solution", alias = UrlParameter.Optional },
               namespaces: new[] { "WebBanHangOnline.Controllers" }
           );routes.MapRoute(
               name: "Headquarter",
               url: "tru-so",
               defaults: new { controller = "Home", action = "Headquarter", alias = UrlParameter.Optional },
               namespaces: new[] { "WebBanHangOnline.Controllers" }
           );
            routes.MapRoute(
               name: "Payment",
               url: "gio-hang",
               defaults: new { controller = "ShoppingCart", action = "Index", alias = UrlParameter.Optional },
               namespaces: new[] { "WebBanHangOnline.Controllers" }
           );
            routes.MapRoute(
             name: "ShoppingCart",
             url: "thanh-toan",
             defaults: new { controller = "ShoppingCart", action = "CheckOut", alias = UrlParameter.Optional },
             namespaces: new[] { "WebBanHangOnline.Controllers" }
         );
            routes.MapRoute(
                name: "CategoryProduct1",
                url: "danh-muc-san-pham/{alias}-{id}",
                defaults: new { controller = "Products", action = "ProductCategory", alias = UrlParameter.Optional },
                namespaces: new[] {"WebBanHangOnline.Controllers"}
            );
            routes.MapRoute(
                name: "DetailProduct",
                url: "chi-tiet-san-pham/{alias}-p{id}",
                defaults: new { controller = "Products", action = "Details", alias = UrlParameter.Optional },
                namespaces: new[] {"WebBanHangOnline.Controllers"}
            );
            routes.MapRoute(
                name: "Home",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] {"WebBanHangOnline.Controllers"}
            );
            routes.MapRoute(
               name: "Contact",
               url: "lien-he",
               defaults: new { controller = "Contact", action = "Index", alias = UrlParameter.Optional },
               namespaces: new[] { "WebBanHangOnline.Controllers" }
           );
          
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"WebBanHangOnline.Controllers"}
            );


        }
    }
}
