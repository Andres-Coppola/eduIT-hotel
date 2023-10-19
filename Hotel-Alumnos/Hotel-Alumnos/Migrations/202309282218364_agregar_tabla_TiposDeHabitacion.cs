namespace Hotel_Alumnos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregar_tabla_TiposDeHabitacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TiposDeHabitacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descripcion = c.String(),
                        ImagenNombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TiposDeHabitacion");
        }
    }
}
