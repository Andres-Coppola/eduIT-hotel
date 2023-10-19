using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hotel_Alumnos
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);

			routes.MapRoute(
			   name: "Huespedes",
			   url: "Huespedes/Index",
			   defaults: new { controller = "Huespedes", action = "Index" }
		   );

			routes.MapRoute(
				 name: "Pagos",
				url: "Pagoes/Index",
				defaults: new { controller = "Pagoes", action = "Index" }
			);

			routes.MapRoute(
				name: "Habitaciones",
				url: "Habitacions/Index",
				defaults: new { controller = "Habitacions", action = "Index" }
			);

		}
	}
}
