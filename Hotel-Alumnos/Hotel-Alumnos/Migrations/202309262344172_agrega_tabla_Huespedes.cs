namespace Hotel_Alumnos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agrega_tabla_Huespedes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Huespedes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
   
        }
        
        public override void Down()
        {
            DropTable("dbo.Huespedes");
        }
    }
}
