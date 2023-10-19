using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Alumnos.Models
{
	[Table("Excursiones")]
	public class Excursion
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Nombre { get; set; }
		
		[Required]
		[StringLength(100)]
		public string Apellido { get; set; }

		[Required]
		public string NombreExcursion { get; set; }

		[Required]
		public DateTime FechaInicio { get; set; }

		[Required]
		public bool EstaPagado { get; set; }

		[Range(1,50000)]
		public decimal Precio { get; set; }
	}
}