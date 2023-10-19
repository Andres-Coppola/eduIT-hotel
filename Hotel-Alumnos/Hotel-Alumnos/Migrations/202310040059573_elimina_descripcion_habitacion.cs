namespace Hotel_Alumnos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elimina_descripcion_habitacion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Habitaciones", "Descripcion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Habitaciones", "Descripcion", c => c.String(maxLength: 400));
        }
    }
}
