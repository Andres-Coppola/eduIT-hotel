namespace Hotel_Alumnos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agrega_reservas_con_fechas : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Habitaciones", t => t.Habitacion_Id)
                .ForeignKey("dbo.Huespedes", t => t.Huesped_Id)
                .Index(t => t.Habitacion_Id)
                .Index(t => t.Huesped_Id);
                        
            AddColumn("dbo.Pagos", "Reserva_Id", c => c.Int());
            CreateIndex("dbo.Pagos", "Reserva_Id");
            AddForeignKey("dbo.Pagos", "Reserva_Id", "dbo.Reservas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagos", "Reserva_Id", "dbo.Reservas");
            DropForeignKey("dbo.Reservas", "Huesped_Id", "dbo.Huespedes");
            DropForeignKey("dbo.Reservas", "Habitacion_Id", "dbo.Habitaciones");
            DropIndex("dbo.Reservas", new[] { "Huesped_Id" });
            DropIndex("dbo.Reservas", new[] { "Habitacion_Id" });
            DropIndex("dbo.Pagos", new[] { "Reserva_Id" });
            DropColumn("dbo.Pagos", "Reserva_Id");
            DropTable("dbo.Reservas");
        }
    }
}
