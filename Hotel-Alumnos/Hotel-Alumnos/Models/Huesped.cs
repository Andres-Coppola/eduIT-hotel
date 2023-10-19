using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel_Alumnos.Models
{
	[Table("Huespedes")]
	public class Huesped
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		
		[Range(1, 9999999999)]
		public int Telefono { get; set; }
	}
}