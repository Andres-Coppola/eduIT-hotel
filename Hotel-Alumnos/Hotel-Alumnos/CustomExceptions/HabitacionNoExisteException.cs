using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Alumnos.CustomExceptions
{
	public class HabitacionNoExisteException : Exception
	{
		public HabitacionNoExisteException()
		{

		}

		public HabitacionNoExisteException(string mensaje) 
			: base(mensaje){ }

		public HabitacionNoExisteException(string mensaje, Exception inner)
			: base(mensaje, inner) { }

	}
}