namespace Hotel_Alumnos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agrega_fechas_a_tabla_reserva : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservas", "FechaIngreso", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservas", "FechaEgreso", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservas", "FechaEgreso");
            DropColumn("dbo.Reservas", "FechaIngreso");
        }
    }
}
