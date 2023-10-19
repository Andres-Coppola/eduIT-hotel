using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel_Alumnos.Models
{
	[Table("Pagos")]
	public class Pago
	{
		public int Id { get; set; }
		public decimal Monto { get; set; }
		public int FormaDePago { get; set; }
	}
}