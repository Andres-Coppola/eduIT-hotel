using Hotel_Alumnos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Enum = Hotel_Alumnos.Enumerations.Enum;
using Newtonsoft.Json;


namespace Hotel_Alumnos.Controllers
{
	public class HomeController : Controller
	{

		private hotelDbContext db = new hotelDbContext();

		public ActionResult Index()
		{

			var miModelo = new Excursion();

			#region Lista de Excursiones

			var ListaDeExcursiones = new List<SelectListItem>();
			ListaDeExcursiones.Add(new SelectListItem { Value = "1", Text = "Alta Montaña" });
			ListaDeExcursiones.Add(new SelectListItem { Value = "2", Text = "Cabalgata" });
			ListaDeExcursiones.Add(new SelectListItem { Value = "3", Text = "Rafting" });
			var TipoExcursiones = new SelectList(ListaDeExcursiones, "Value", "Text");

			ViewBag.ListaDeExcursiones = TipoExcursiones;

			#endregion

			#region Tipos de Habitaciones

			var tipos = db.TiposDeHabitacion.Where(x => true).ToList();

			var listaTipos = new List<SelectListItem>();

			foreach (var tipo in tipos)
			{
				listaTipos.Add(new SelectListItem { Value = tipo.Id.ToString(), Text = tipo.Nombre });
			}
			
			ViewBag.tipos = new SelectList(listaTipos, "Value", "Text"); ;

			#endregion

			var miVari = 156;
			var MiotraVar = 152;
			

			return View(miModelo);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Reservas()
		{
			ViewBag.Message = "Mi pagina de reservas";

			return View();
		}

		[HttpPost]
		public JsonResult GetTipoHabitacion(string idTipoHabitacion)
		{
			var idHab = int.Parse(idTipoHabitacion);

			var tipoDeHabitacion = db.TiposDeHabitacion.FirstOrDefault(x => x.Id == idHab);

			var jsonResponse = JsonConvert.SerializeObject(tipoDeHabitacion);
			

			return Json(tipoDeHabitacion, JsonRequestBehavior.AllowGet);
		}


		[HttpPost]
		public JsonResult GuardarExcursion(Excursion modelo)
		{

			var respuesta = new Dictionary<string, string>
			{
				{ "msg", "La excursion se guardo correctamente" }
			};

			ModelState.Remove("FechaInicio");


			if (!ModelState.IsValid)
			{
				respuesta = new Dictionary<string, string>
				{
					{ "msg", "Revise los datos de la excursion" }
				};

				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				
				return Json(respuesta, JsonRequestBehavior.AllowGet);

			}
			
			if (modelo.NombreExcursion == ((int)Enum.ExcursionTipo.AltaMontaña).ToString())
			{
				modelo.NombreExcursion = "Alta Montaña";

			}else if (modelo.NombreExcursion == ((int)Enum.ExcursionTipo.Cabalgata).ToString())
			{
				modelo.NombreExcursion = "Cabalgata";
			}
			else
			{
				modelo.NombreExcursion = "Rafting";
			}
			
			if (modelo.Precio == 0)
			{
				respuesta = new Dictionary<string, string>
				{
					{ "msg", "Se ha producido un error" }
				};

				Response.StatusCode = (int)HttpStatusCode.InternalServerError;

				return Json(respuesta, JsonRequestBehavior.AllowGet);
			}

			using (var ctx = new hotelDbContext())
			{
				ctx.Excursiones.Add(modelo);
				ctx.SaveChanges();
			}
			
			return Json(respuesta, JsonRequestBehavior.AllowGet);
		}

	}
}