namespace Hotel_Alumnos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elimina_tabla_reservas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservas", "Habitacion_Id", "dbo.Habitaciones");
            DropForeignKey("dbo.Reservas", "Huesped_Id", "dbo.Huespedes");
            DropForeignKey("dbo.Pagos", "Reserva_Id", "dbo.Reservas");
            DropIndex("dbo.Pagos", new[] { "Reserva_Id" });
            DropIndex("dbo.Reservas", new[] { "Habitacion_Id" });
            DropIndex("dbo.Reservas", new[] { "Huesped_Id" });
            DropColumn("dbo.Pagos", "Reserva_Id");
            DropTable("dbo.Reservas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estado = c.Int(nullable: false),
                        Habitacion_Id = c.Int(),
                        Huesped_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pagos", "Reserva_Id", c => c.Int());
            CreateIndex("dbo.Reservas", "Huesped_Id");
            CreateIndex("dbo.Reservas", "Habitacion_Id");
            CreateIndex("dbo.Pagos", "Reserva_Id");
            AddForeignKey("dbo.Pagos", "Reserva_Id", "dbo.Reservas", "Id");
            AddForeignKey("dbo.Reservas", "Huesped_Id", "dbo.Huespedes", "Id");
            AddForeignKey("dbo.Reservas", "Habitacion_Id", "dbo.Habitaciones", "Id");
        }
    }
}
