using Hotel_Alumnos.CustomExceptions;
using Hotel_Alumnos.Models;
using Hotel_Alumnos.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Hotel_Alumnos.Controllers
{
	public class ReservasController : Controller
    {

		private hotelDbContext db = new hotelDbContext();

		// GET: Reservas
		public ActionResult Index()
        {


			#region Bloque de Pruebas

			var miId = db.Habitaciones.Where(x => x.Numero == 101).FirstOrDefault()?.Id ?? 4;
			
			var hab104 = db.Habitaciones.Where(x => x.Numero == 104).FirstOrDefault();

			var miVariable = hab104 ?? new Habitacion { Numero = 104};

			var miOtroId = hab104?.Id;


			var miReserva = new Reserva { 
				Habitacion = new Habitacion { 
					Id = 1,
				}
			};

			var test01 = miReserva.Habitacion.Id;

			var test02 = miReserva?.Huesped?.Nombre;

			int? miEntero = 4;

			miEntero = null;

			var miHuesped1 = new Huesped { Nombre = "pp" };

			var miHuesped2 = miHuesped1;

			miHuesped2.Nombre = "pablo";


			#endregion

			if (!miEntero.HasValue)
			{
				var temporal = 2;
			}

			var modelo = new Reserva();

			try{
				var miHuesped3 = miHuesped1;

				//algo
			}
			catch (DivideByZeroException ex)
			{

			}

			var OtraVariable = 0;
			
			#region Tipos de Habitaciones

			var tipos = db.TiposDeHabitacion.Where(x => true).ToList();

			var listaTipos = new List<SelectListItem>();

			foreach (var tipo in tipos)
			{
				listaTipos.Add(new SelectListItem { Value = tipo.Id.ToString(), Text = tipo.Nombre });
			}

			ViewBag.tipos = new SelectList(listaTipos, "Value", "Text"); ;

			#endregion

			return View(modelo);
        }


		[HttpPost]
		public JsonResult ConteoDeReservas(int tipoHab, DateTime fechaIngreso, DateTime fechaEgreso)
		{

			var miVariable = 0;

			return Json(6, JsonRequestBehavior.AllowGet);
		}


		[HttpPost]
		public JsonResult ConsultarHabitacionesPorTipo(int tipoHab, DateTime fechaIngreso, DateTime fechaEgreso)
		{
			var habitaciones = db.Habitaciones.Where(x => x.TipoHabitacion == tipoHab).ToList();
			var tipoSeleccionado = db.TiposDeHabitacion.FirstOrDefault(x => x.Id == tipoHab);

			var diario = db.DiarioDeReservas.Where(x => 
				x.Fecha >= fechaIngreso
				&& x.Fecha <= fechaEgreso
			).ToList();

			var HabitacionesOcupadas = new List<Habitacion>();

			foreach (var dia in diario)
			{
				var habOcupada = db.Habitaciones.FirstOrDefault(x => x.Id == dia.Id);

				HabitacionesOcupadas.Add(habOcupada);
			}

			var habitacionesDesocupadas = new List<Habitacion>();

			foreach (var hab in habitaciones)
			{
				if (!HabitacionesOcupadas.Contains(hab)) {
					habitacionesDesocupadas.Add(hab);
				}
			}

			var datos = new DtoReservaHabitacion();

			datos.Habitaciones = habitacionesDesocupadas;
			datos.TipoHabitacion = tipoSeleccionado;

			return Json(datos, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult GuardarReserva(Reserva reserva) {

			var hab= db.Habitaciones.FirstOrDefault(x => x.Id == 5);
			
			if(hab == null)
			{

				var respuesta = new Dictionary<string, string>
				{
					{ "msg", "La Habitacion no existe" }
				};

				Response.StatusCode = (int)HttpStatusCode.InternalServerError;

				return Json(respuesta, JsonRequestBehavior.AllowGet);
			}

			reserva.Habitacion = hab;

			db.Reservas.Add(reserva);
			db.SaveChanges();

			var fechaActual = reserva.FechaIngreso;

			while (fechaActual < reserva.FechaEgreso)
			{

				db.DiarioDeReservas.Add(
					new DiarioDeReservas
					{
						Fecha = fechaActual,
						HabitacionId = reserva.Id,
						ReservaId = reserva.Id
					}
				);

				fechaActual = fechaActual.AddDays(1);
			}

			db.SaveChanges();

			return Json(string.Empty, JsonRequestBehavior.AllowGet);
		}


	}
}