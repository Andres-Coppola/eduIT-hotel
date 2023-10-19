using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel_Alumnos.Models
{
	[Table("Habitaciones")]
	public class Habitacion
	{
		public int Id { get; set; }
		public int Numero { get; set; }
		public int Estado { get; set; }
		public int TipoHabitacion { get; set; }

	}
}