namespace RejestrOsobProjekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Humen", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Humen", "Image");
        }
    }
}
