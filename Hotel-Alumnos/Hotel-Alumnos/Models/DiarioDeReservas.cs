using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel_Alumnos.Models
{
	[Table("DiarioDeReservas")]
	public class DiarioDeReservas
	{
		public int Id { get; set; }
		public DateTime Fecha { get; set; }
		public int HabitacionId { get; set; }
		public int ReservaId { get; set; }

	}
}