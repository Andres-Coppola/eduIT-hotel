using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Hotel_Alumnos.Models
{
	public partial class hotelDbContext : DbContext
	{
		public hotelDbContext()
			: base("name=MiConexion")
		{
								
		}

		public DbSet<Excursion> Excursiones { get; set; }
		public DbSet<Habitacion> Habitaciones { get; set; }
		public DbSet<Huesped> Huespedes { get; set; }
		public DbSet<Pago> Pagos { get; set; }
		public DbSet<Reserva> Reservas { get; set; }
		public DbSet<TipoHabitacion> TiposDeHabitacion { get; set; }
		public DbSet<DiarioDeReservas> DiarioDeReservas { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
