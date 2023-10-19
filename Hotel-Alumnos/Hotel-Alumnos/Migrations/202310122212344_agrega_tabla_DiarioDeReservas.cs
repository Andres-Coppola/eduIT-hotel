namespace Hotel_Alumnos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agrega_tabla_DiarioDeReservas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiarioDeReservas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        HabitacionId = c.Int(nullable: false),
                        ReservaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DiarioDeReservas");
        }
    }
}
