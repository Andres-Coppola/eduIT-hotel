namespace Hotel_Alumnos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agrega_descripcion_habitacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Habitaciones", "Descripcion", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Habitaciones", "Descripcion");
        }
    }
}
