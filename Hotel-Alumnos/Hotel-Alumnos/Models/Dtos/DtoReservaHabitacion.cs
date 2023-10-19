using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Alumnos.Models.Dtos
{
	public class DtoReservaHabitacion
	{
		public List<Habitacion> Habitaciones { get; set; }
		public TipoHabitacion TipoHabitacion { get; set; }
	}
}