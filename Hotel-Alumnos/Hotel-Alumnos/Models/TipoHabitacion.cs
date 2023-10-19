using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel_Alumnos.Models
{
	[Table("TiposDeHabitacion")]
	public class TipoHabitacion
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public decimal Precio { get; set; }
		public string Descripcion { get; set; }
		public string ImagenNombre { get; set; }
	}
}