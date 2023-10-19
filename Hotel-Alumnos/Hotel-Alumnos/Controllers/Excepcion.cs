using System;
using System.Runtime.Serialization;

namespace Hotel_Alumnos.Controllers
{
	[Serializable]
	internal class Excepcion : Exception
	{
		public Excepcion()
		{
		}

		public Excepcion(string message) : base(message)
		{
		}

		public Excepcion(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected Excepcion(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}