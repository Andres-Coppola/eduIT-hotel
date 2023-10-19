namespace Hotel_Alumnos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agrega_Excursion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Excursiones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Apellido = c.String(nullable: false, maxLength: 100),
                        NombreExcursion = c.String(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        EstaPagado = c.Boolean(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Excursiones");
        }
    }
}
