namespace RejestrOsobProjekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Humen", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Humen", "Name", c => c.String());
        }
    }
}
