using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel_Alumnos.Models
{
	[Table("Reservas")]
	public class Reserva
	{
		public int Id { get; set; }
		public int Estado { get; set; }
		public Habitacion Habitacion { get; set; }
		public Huesped Huesped { get; set; }
		public List<Pago> Pagos { get; set; } = new List<Pago>();
		public DateTime FechaIngreso { get; set; }
		public DateTime FechaEgreso { get; set; }

	}
}